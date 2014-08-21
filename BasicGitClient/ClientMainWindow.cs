using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class ClientMainWindow : Form
    {
        private GitClientAccess gitClient;
        private string error, output;
        private string defaultDir;
        private string remoteName;
        private XmlHandler xmlHandler = new XmlHandler();

        public ClientMainWindow()
        {
            InitializeComponent();
            gitClient = new GitClientAccess();

            string d = xmlHandler.GetLastLocation();
            defaultDir = string.IsNullOrWhiteSpace(d) ?
                @"E:\Documents and Settings\Nikeah\My Documents\Python\Python_2014"
                : d;
            tbDirectory.Text = defaultDir;
            tbDirectory.SelectionStart = tbDirectory.TextLength;
            gitClient.SetDirectory(defaultDir);
            // set remote
            showOriginToolStripMenuItem_Click(null, new EventArgs());
        }

        #region UI Button Click Handlers

        private void btnStatus_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.STATUS, out output, out error);
            updateRtbOutput(output, error);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.ADD_ALL, out output, out error);

            if (String.Equals(String.Empty, output) && String.Equals(String.Empty, error))
            {
                output = Environment.NewLine + "Added all modified files.  Check status" + Environment.NewLine;
            }

            updateRtbOutput(output, error);
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
                updateRtbOutput(output, error);
            }
            else
            {
                rtbOutput.AppendText("\nNo comment added.  Not committed..");
            }
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string username, password;
            xmlHandler.GetCredentials(out username, out password);

            string command = String.Format(GitCommands.PUSH, username, password, remoteName);
            gitClient.RunGitCommand(command, out output, out error);

            updateRtbOutput(output, error);

            // push then pull required due to master/origin local mismatch
            btnPull_Click(null, new EventArgs());

            Cursor = DefaultCursor;
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.PULL, out output, out error);
            updateRtbOutput(output, error);
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

                gitClient.RunGitCommand(command, out output, out error);
                updateRtbOutput(output, error);
            }
        }

        private void initialiseNewRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.INIT, out output, out error);
            updateRtbOutput(output, error);
        }

        private void showOriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.SHOW_ORIGIN, out output, out error);

            if (!String.IsNullOrEmpty(output))
            {
                remoteName = output.Split('\n')[0].Split('\t')[1]
                .Split(new string[] { "(fetch)" }, StringSplitOptions.None)[0]
                .Split(new string[] { "github.com" }, StringSplitOptions.None)[1];
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
                gitClient.RunGitCommand(GitCommands.CLONE + cloneWindow.TextField, out output, out error);
                updateRtbOutput(output, error);
            }
        }

        private void resetToHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.RESET, out output, out error);
            updateRtbOutput(output, error);
        }

        private void pushAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(null, new EventArgs());
            btnCommit_Click(null, new EventArgs());
            btnPush_Click(null, new EventArgs());
        }

        private void changeRepoUsernameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SingleTextBoxDialogWindow emailDialogWindow = new SingleTextBoxDialogWindow("Set email...");
            emailDialogWindow.ShowDialog();

            if (!string.IsNullOrEmpty(emailDialogWindow.TextField))
            {
                gitClient.RunGitCommand(GitCommands.SET_EMAIL + emailDialogWindow.TextField, out output, out error);
                updateRtbOutput(output, error);
            }
        }

        #endregion

        #region Textbox Update Methods

        private void updateRtbOutput(string output, string error)
        {
            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void rtbOutput_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < rtbOutput.Lines.Length; ++i)
            {
                if (rtbOutput.Lines[i].Contains("modified: "))
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
    }
}
