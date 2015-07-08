using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class ClientMainWindow : Form
    {
        #region Private Data

        private string error;
        private string output;
        private string defaultDir;
        private string remoteName;
        private string treeViewSelectedDirectory;
        private XmlHandler xmlHandler;
        private TreeNode currentSelectedNode;
        private GitClientAccess gitClient;

        #endregion

        #region Constructors

        public ClientMainWindow()
        {
            InitializeComponent();

            try
            {
                xmlHandler = new XmlHandler();

                gitClient = new GitClientAccess();
                runCommand(GitCommands.VERSION);

                defaultDir = xmlHandler.GetLastLocation();
                tbDirectory.Text = defaultDir;
                tbDirectory.SelectionStart = tbDirectory.TextLength;
                gitClient.SetDirectory(defaultDir);

                // set remote
                showOriginToolStripMenuItem_Click(null, new EventArgs());

                // Populate tree view.
                populateTreeView();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Error with application.  Could not find Git.\nTerminating..");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(0);
            }
        }

        #endregion

        #region UI Button Click Handlers

        private void btnStatus_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.STATUS);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.ADD_ALL, out output, out error);

            if (String.Equals(String.Empty, output) && String.Equals(String.Empty, error))
            {
                output = Environment.NewLine + "Added all modified files.  Check status " + Environment.NewLine;
            }

            rtbOutput.AppendText(output);
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            CommitCommentWindow commitWindow = new CommitCommentWindow();
            commitWindow.ShowDialog();

            string comment = commitWindow.CommitComment;

            if (comment != String.Empty)
            {
                string command = GitCommands.COMMIT + " " + comment;
                gitClient.RunGitCommand(command, out output, out error);
            }
            else
            {
                output = "\nNo comment added.  Not committed..";
            }

            updateRtbOutput(output, error);
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            string username, password;
            xmlHandler.GetCredentials(out username, out password);

            string command = String.Format(GitCommands.PUSH, username, password, remoteName);
            runCommand(command);

            // push then pull required due to master/origin local mismatch
            runCommand(GitCommands.PULL);
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.PULL);
        }

        #endregion

        #region UI Toolstrip Menu Item Click Handlers

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (Directory.Exists(defaultDir))
            {
                fbd.SelectedPath = defaultDir;
            }

            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string directory = fbd.SelectedPath;
                tbDirectory.Text = directory;

                gitClient.SetDirectory(directory);
                // repopulate tree view
                populateTreeView();

                xmlHandler.SetLastLocation(directory);
                // get remote name
                showOriginToolStripMenuItem_Click(null, new EventArgs());
            }
        }

        private void configureEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CredentialConfigureWindow credentialWindow = new CredentialConfigureWindow();
            credentialWindow.ShowDialog();

            string username = credentialWindow.Username;
            string password = credentialWindow.Password;

            xmlHandler.SetCredentials(username, password);
        }

        private void setOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow setOriginWindow = new SingleTextBoxDialogWindow("Set Origin...");
            setOriginWindow.ShowDialog();

            if (!String.IsNullOrEmpty(setOriginWindow.TextField))
            {
                string command = GitCommands.SET_ORIGIN + setOriginWindow.TextField;
                runCommand(command);
            }
        }

        private void changeRepoUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow newUrlDialog = new SingleTextBoxDialogWindow("Set Repo URL");
            DialogResult dialogResult = newUrlDialog.ShowDialog();

            if (!String.IsNullOrEmpty(newUrlDialog.TextField))
            {
                runCommand(GitCommands.SET_URL + newUrlDialog.TextField);
            }

            showOriginToolStripMenuItem_Click(this, new EventArgs());
        }

        private void initialiseNewRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.INIT);
        }

        private void showOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.SHOW_ORIGIN, out output, out error);

            try
            {
                if (!String.IsNullOrEmpty(output))
                {
                    remoteName = output.Split('\n')[0].Split('\t')[1]
                    .Split(new string[] { "(fetch)" }, StringSplitOptions.None)[0]
                    .Split(new string[] { "github.com" }, StringSplitOptions.None)[1];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error getting origin data.  Check it is set.");
            }

            if (sender != null)
            {
                if (output == string.Empty && error == string.Empty)
                {
                    output = "Origin is not set." + Environment.NewLine;
                }

                updateRtbOutput(output, error);
            }
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow cloneWindow = new SingleTextBoxDialogWindow("Clone");
            cloneWindow.ShowDialog();

            if (!string.IsNullOrEmpty(cloneWindow.TextField))
            {
                runCommand(GitCommands.CLONE + cloneWindow.TextField);
            }
        }

        private void resetToHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.RESET);
        }

        private void pushAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(null, new EventArgs());
            btnCommit_Click(null, new EventArgs());
            btnPush_Click(null, new EventArgs());
        }

        private void configureRepoEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow emailDialogWindow = new SingleTextBoxDialogWindow("Set email...", "Email");
            emailDialogWindow.ShowDialog();

            if (!string.IsNullOrEmpty(emailDialogWindow.TextField))
            {
                runCommand(GitCommands.SET_EMAIL + emailDialogWindow.TextField);
            }
        }

        private void configureRepoUsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow userNameDialogWindow = new SingleTextBoxDialogWindow("Set Username...", "Name");
            userNameDialogWindow.ShowDialog();

            if (!string.IsNullOrEmpty(userNameDialogWindow.TextField))
            {
                runCommand(GitCommands.SET_USERNAME + userNameDialogWindow.TextField);
            }
        }

        private void revertLastChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.REVERT);
        }

        #endregion

        #region Helper Methods

        private void runCommand(string command)
        {
            Cursor = Cursors.WaitCursor;
            
            gitClient.RunGitCommand(command, out output, out error);
            updateRtbOutput(output, error);
            
            Cursor = Cursors.Default;
        }

        private void updateRtbOutput(string output, string error)
        {
            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void rtbOutput_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < rtbOutput.Lines.Length; ++i)
            {
                if (rtbOutput.Lines[i].Contains("modified: ") 
                    || rtbOutput.Lines[i].Contains("renamed: ") 
                    || rtbOutput.Lines[i].Contains("deleted: "))
                {
                    rtbOutput.Select(rtbOutput.GetFirstCharIndexFromLine(i), rtbOutput.Lines[i].Length);
                    rtbOutput.SelectionColor = Color.DarkRed;
                }

                if (rtbOutput.Lines[i].Contains("new file: "))
                {
                    rtbOutput.Select(rtbOutput.GetFirstCharIndexFromLine(i), rtbOutput.Lines[i].Length);
                    rtbOutput.SelectionColor = Color.DarkGreen;
                }
            }

            rtbOutput.SelectionStart = rtbOutput.TextLength;
            rtbOutput.ScrollToCaret();
        }

        #endregion

        #region Tree View File Viewer

        private void populateTreeView()
        {
            if (String.IsNullOrEmpty(gitClient.Directory))
            {
                return;
            }

            tvDirectoryList.Nodes.Clear();
            lbFileList.Items.Clear();

            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(gitClient.Directory);

            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                getDirectories(info.GetDirectories(), rootNode);
                tvDirectoryList.Nodes.Add(rootNode);
            }
        }

        private void getDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    getDirectories(subSubDirs, aNode);
                }
                
                if (!(subDir.Attributes.HasFlag(FileAttributes.Hidden)))
                {
                    nodeToAddTo.Nodes.Add(aNode);
                }
            }
        }

        private void tvDirectoryList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e != null)
            {
                currentSelectedNode = e.Node;
                tvDirectoryList.SelectedNode = e.Node;
            }

            lbFileList.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)currentSelectedNode.Tag;

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                lbFileList.Items.Add(file.Name);
            }
        }

        private void tvDirectoryList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvDirectoryList.SelectedNode != null)
            {
                int headNodeLength = tvDirectoryList.Nodes[0].Text.Length;
                string selectedNode = tvDirectoryList.SelectedNode.FullPath.Remove(0, headNodeLength);
                treeViewSelectedDirectory = gitClient.Directory + selectedNode;
            }
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow newFileWindow = new SingleTextBoxDialogWindow("File Name", "Name");
            newFileWindow.ShowDialog();

            if (!String.IsNullOrEmpty(newFileWindow.TextField))
            {
                File.Create(treeViewSelectedDirectory + "\\" + newFileWindow.TextField).Dispose();
                tvDirectoryList_NodeMouseClick(this, null);
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!lbFileListSelectedCheck())
            {
                return;
            }

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = treeViewSelectedDirectory + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message);
            }
        }

        private void renameFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!lbFileListSelectedCheck())
            {
                return;
            }

            string file = treeViewSelectedDirectory + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);
            
            SingleTextBoxDialogWindow newFileWindow = new SingleTextBoxDialogWindow("File Name", "Name");
            newFileWindow.ShowDialog();

            if (!String.IsNullOrEmpty(newFileWindow.TextField))
            {
                string newFile = treeViewSelectedDirectory + "\\" + newFileWindow.TextField;
                File.Move(file, newFile);

                tvDirectoryList_NodeMouseClick(this, null);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = treeViewSelectedDirectory + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);
            File.Delete(file);

            tvDirectoryList_NodeMouseClick(this, null);
        }

        private void DeleteDirectory(string path, bool recursive)
        {
            // Delete all files and sub-folders?
            if (recursive)
            {
                // Yep... Let's do this
                var subfolders = Directory.GetDirectories(path);
                foreach (var s in subfolders)
                {
                    DeleteDirectory(s, recursive);
                }
            }

            // Get all files of the folder
            var files = Directory.GetFiles(path);
            foreach (var f in files)
            {
                // Get the attributes of the file
                var attr = File.GetAttributes(f);

                // Is this file marked as 'read-only'?
                if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    // Yes... Remove the 'read-only' attribute, then
                    File.SetAttributes(f, attr ^ FileAttributes.ReadOnly);
                }

                // Delete the file
                File.Delete(f);
            }

            // When we get here, all the files of the folder were
            // already deleted, so we just delete the empty folder
            Directory.Delete(path);
        }

        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteDirectory(treeViewSelectedDirectory, true);
                populateTreeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool lbFileListSelectedCheck()
        {
            if (lbFileList.SelectedItem == null)
            {
                MessageBox.Show("No file selected");
                return false;
            }

            return true;
        }

        private void cMnuFileViewer_Opening(object sender, CancelEventArgs e)
        {
            cMnuFileViewer.Items["deleteToolStripMenuItem"].Enabled
                = cMnuFileViewer.Items["renameFileToolStripMenuItem"].Enabled
                = cMnuFileViewer.Items["openFileToolStripMenuItem"].Enabled
                = lbFileList.SelectedItem != null;
        }

        #endregion

        private void updategitignoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Have you committed outstanding code changes?",
                "Commit Changes", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                runCommand("rm -r --cached .");
                runCommand("add .");
                btnStatus_Click(this, null);
                runCommand("commit -m \"gitignore updated\"");

                btnPush_Click(this, null);
            }
        }

        private void tvDirectoryList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                populateTreeView();
            }
        }
    }
}
