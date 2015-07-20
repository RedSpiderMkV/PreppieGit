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

        private string error_m;
        private string output_m;
        private string defaultDir_m;
        private string remoteName_m;
        private string treeViewSelectedDirectory_m;
        private XmlHandler xmlHandler_m;
        private TreeNode currentSelectedNode_m;
        private GitClientAccessor gitClient_m;
        private UIEventManager eventManager_m;

        #endregion

        #region Constructors

        public ClientMainWindow()
        {
            InitializeComponent();

            try
            {
                eventManager_m = new UIEventManager();

                xmlHandler_m = new XmlHandler();
                gitClient_m = new GitClientAccessor();

                runCommand(GitCommands.VERSION);

                defaultDir_m = xmlHandler_m.GetLastLocation();
                tbDirectory.Text = defaultDir_m;
                tbDirectory.SelectionStart = tbDirectory.TextLength;
                gitClient_m.SetDirectory(defaultDir_m);

                ControlDirectoryBrowser directoryBrowser = new ControlDirectoryBrowser(eventManager_m, defaultDir_m, splitContainer2.Panel1.Height);
                directoryBrowser.Width = splitContainer2.Panel1.Width;
                directoryBrowser.Height = splitContainer2.Panel1.Height;
                directoryBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                
                splitContainer2.Panel1.Controls.Add(directoryBrowser);

                // set remote
                showOrigin();

                // Populate tree view.
                //populateTreeView();

                MenuStrip menuStrip = new MenuStrip();
                menuStrip.Items.Add("File");

                menuStrip.BackColor = this.BackColor;

                this.Controls.Add(menuStrip);
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

        private void btnStatus_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.STATUS);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addAll();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            commitChanges();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            pushCommits();
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.PULL);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (Directory.Exists(defaultDir_m))
            {
                fbd.SelectedPath = defaultDir_m;
            }

            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string directory = fbd.SelectedPath;
                tbDirectory.Text = directory;

                eventManager_m.TriggerDirectoryChangedEvent(directory);

                gitClient_m.SetDirectory(directory);
                // repopulate tree view
                //populateTreeView();

                xmlHandler_m.SetLastLocation(directory);
                // get remote name
                showOrigin();
            }
        }

        private void configureEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CredentialConfigureWindow credentialWindow = new CredentialConfigureWindow();
            credentialWindow.ShowDialog();

            string username = credentialWindow.Username;
            string password = credentialWindow.Password;

            xmlHandler_m.SetCredentials(username, password);
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

            showOrigin();
            displayGitOutput();
        }

        private void initialiseNewRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.INIT);
        }

        private void showOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOrigin();
            displayGitOutput();
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
            addAll();
            commitChanges();
            pushCommits();
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

        #region Helper Methods

        private void runCommand(string command)
        {
            Cursor = Cursors.WaitCursor;

            gitClient_m.RunGitCommand(command, out output_m, out error_m);
            updateRtbOutput(output_m, error_m);

            Cursor = Cursors.Default;
        }

        private void updateRtbOutput(string output, string error)
        {
            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void addAll()
        {
            gitClient_m.RunGitCommand(GitCommands.ADD_ALL, out output_m, out error_m);

            if (String.Equals(String.Empty, output_m) && String.Equals(String.Empty, error_m))
            {
                output_m = Environment.NewLine + "Added all modified files.  Check status " + Environment.NewLine;
            }

            displayGitOutput();
        } // end method

        private void commitChanges()
        {
            CommitCommentWindow commitWindow = new CommitCommentWindow();
            commitWindow.ShowDialog();

            string comment = commitWindow.CommitComment;

            if (comment != String.Empty)
            {
                string command = GitCommands.COMMIT + " " + comment;
                gitClient_m.RunGitCommand(command, out output_m, out error_m);
            }
            else
            {
                output_m = "\nNo comment added.  Not committed..";
            }

            displayGitOutput();
        } // end method

        private void pushCommits()
        {
            string username, password;
            xmlHandler_m.GetCredentials(out username, out password);

            string command = String.Format(GitCommands.PUSH, username, password, remoteName_m);
            runCommand(command);

            // push then pull required due to master/origin local mismatch
            runCommand(GitCommands.PULL);
        } // end method

        private void showOrigin()
        {
            gitClient_m.RunGitCommand(GitCommands.SHOW_ORIGIN, out output_m, out error_m);

            try
            {
                if (!String.IsNullOrEmpty(output_m))
                {
                    remoteName_m = output_m.Split('\n')[0].Split('\t')[1]
                    .Split(new string[] { "(fetch)" }, StringSplitOptions.None)[0]
                    .Split(new string[] { "github.com" }, StringSplitOptions.None)[1];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error getting origin data.  Check it is set.");
            }
        } // end method

        private void displayGitOutput()
        {
            if (output_m == string.Empty && error_m == string.Empty)
            {
                output_m = "Error running command..." + Environment.NewLine;
            }

            updateRtbOutput(output_m, error_m);
        } // end method

        /*private void populateFileList()
        {
            lbFileList.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)currentSelectedNode_m.Tag;

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                lbFileList.Items.Add(file.Name);
            } // end foreach
        } // end method*/

        /*private void populateTreeView()
        {
            if (String.IsNullOrEmpty(gitClient_m.RepoDirectory))
            {
                return;
            }

            tvDirectoryList.Nodes.Clear();
            lbFileList.Items.Clear();

            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(gitClient_m.RepoDirectory);

            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                addDirectoriesToNode(info.GetDirectories(), rootNode);
                tvDirectoryList.Nodes.Add(rootNode);
            }
        }*/

        /*private void addDirectoriesToNode(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
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
                    addDirectoriesToNode(subSubDirs, aNode);
                }

                if (!(subDir.Attributes.HasFlag(FileAttributes.Hidden)))
                {
                    nodeToAddTo.Nodes.Add(aNode);
                }
            }
        }*/

        private void deleteDirectory(string path, bool recursive)
        {
            // Delete all files and sub-folders?
            if (recursive)
            {
                // Yep... Let's do this
                var subfolders = Directory.GetDirectories(path);
                foreach (var s in subfolders)
                {
                    deleteDirectory(s, recursive);
                }
            }

            // Get all files of the folder
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                // Get the attributes of the file
                FileAttributes attr = File.GetAttributes(file);

                // Is this file marked as 'read-only'?
                if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    // Yes... Remove the 'read-only' attribute, then
                    File.SetAttributes(file, attr ^ FileAttributes.ReadOnly);
                }

                // Delete the file
                File.Delete(file);
            }

            // When we get here, all the files of the folder were
            // already deleted, so we just delete the empty folder
            Directory.Delete(path);
        }

        #endregion

        #region Tree View File Viewer

        /*private void tvDirectoryList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            currentSelectedNode_m = e.Node;
            tvDirectoryList.SelectedNode = e.Node;

            populateFileList();
        } // end method

        private void tvDirectoryList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvDirectoryList.SelectedNode != null)
            {
                int headNodeLength = tvDirectoryList.Nodes[0].Text.Length;
                string selectedNode = tvDirectoryList.SelectedNode.FullPath.Remove(0, headNodeLength);
                treeViewSelectedDirectory_m = gitClient_m.RepoDirectory + selectedNode;
            }
        }

        private void tvDirectoryList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                populateTreeView();
            }
        }*/

        #endregion

        #region Toolstrip Menu Click Handlers

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow newFileWindow = new SingleTextBoxDialogWindow("File Name", "Name");
            newFileWindow.ShowDialog();

            if (!String.IsNullOrEmpty(newFileWindow.TextField))
            {
                File.Create(treeViewSelectedDirectory_m + "\\" + newFileWindow.TextField).Dispose();
                //populateFileList();
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
                //process.StartInfo.FileName = treeViewSelectedDirectory_m + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file: " + ex.Message);
            }
        }

        private void renameFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (!lbFileListSelectedCheck())
            {
                return;
            }

            string file = treeViewSelectedDirectory_m + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);

            SingleTextBoxDialogWindow newFileWindow = new SingleTextBoxDialogWindow("File Name", "Name");
            newFileWindow.ShowDialog();

            if (!String.IsNullOrEmpty(newFileWindow.TextField))
            {
                string newFile = treeViewSelectedDirectory_m + "\\" + newFileWindow.TextField;
                File.Move(file, newFile);

                populateFileList();
            }*/
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*string file = treeViewSelectedDirectory_m + "\\" + lbFileList.GetItemText(lbFileList.SelectedItem);
            File.Delete(file);

            populateFileList();*/
        }

        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                deleteDirectory(treeViewSelectedDirectory_m, true);
                //populateTreeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private bool lbFileListSelectedCheck()
        {
            /*if (lbFileList.SelectedItem == null)
            {
                MessageBox.Show("No file selected");
                return false;
            }*/

            return true;
        }

        private void cMnuFileViewer_Opening(object sender, CancelEventArgs e)
        {
            /*cMnuFileViewer.Items["deleteToolStripMenuItem"].Enabled
                = cMnuFileViewer.Items["renameFileToolStripMenuItem"].Enabled
                = cMnuFileViewer.Items["openFileToolStripMenuItem"].Enabled
                = lbFileList.SelectedItem != null;*/
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

                pushCommits();
            }
        }

        private void cMenuOutputBox_Clear_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
        }
    }
}
