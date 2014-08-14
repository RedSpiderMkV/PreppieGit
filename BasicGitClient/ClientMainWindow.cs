using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BasicGitClient
{
    public partial class ClientMainWindow : Form
    {
        private GitClientAccess gitClient;
        private string error, output;
        // TODO: Make this come from a config file and not be hard coded..
        private static string defaultDir = @"E:\Documents and Settings\Nikeah\My Documents\Python\Python_2014";
        private string remoteName;

        public ClientMainWindow()
        {
            InitializeComponent();
            gitClient = new GitClientAccess();
        }

        private void btnSetDir_Click(object sender, EventArgs e)
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

                // get remote name
                btnShowOrigin_Click(null, new EventArgs());
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.STATUS, out output, out error);
            
            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.ADD_ALL, out output, out error);

            if (String.Equals(String.Empty, output) && String.Equals(String.Empty, error))
            {
                rtbOutput.AppendText(Environment.NewLine + "Added all modified files.  Check status" + Environment.NewLine);
            }
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

                rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
                rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
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
            getCredentials(out username, out password);

            string command = String.Format(GitCommands.PUSH, username, password, remoteName);
            gitClient.RunGitCommand(command, out output, out error);

            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));

            // push then pull required due to master/origin local mismatch
            btnPull_Click(null, new EventArgs());

            Cursor = DefaultCursor;
        }

        private void getCredentials(out string username, out string password)
        {
            username = password = "";

            string credentialFile = "credentials.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(credentialFile);

            foreach (XmlNode node in doc.FirstChild.ChildNodes)
            {
                switch(node.Name)
                {
                    case "username":
                        username = node.InnerText;
                        break;
                    case "password":
                        password = node.InnerText;
                        break;
                }
            }
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.PULL, out output, out error);

            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.RESET, out output, out error);

            rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void btnShowOrigin_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.SHOW_ORIGIN, out output, out error);

            if (!String.Equals(output, String.Empty))
            {
                remoteName = output.Split('\n')[0].Split('\t')[1]
                .Split(new string[] { "(fetch)" }, StringSplitOptions.None)[0]
                .Split(new string[] { "github.com" }, StringSplitOptions.None)[1];
            }

            if (sender != null)
            {
                rtbOutput.AppendText(output.Replace("\n", Environment.NewLine));
                rtbOutput.AppendText(error.Replace("\n", Environment.NewLine));
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSetDir_Click(this, new EventArgs());
        }

        private void configureEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CredentialConfigureWindow credentialWindow = new CredentialConfigureWindow();
            credentialWindow.ShowDialog();

            string username = credentialWindow.Username;
            string password = credentialWindow.Password;

            setCredentials(username, password);
        }

        private void setCredentials(string username, string password)
        {
            string credentialFile = "credentials.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(credentialFile);

            foreach (XmlNode node in doc.FirstChild.ChildNodes)
            {
                switch (node.Name)
                {
                    case "username":
                        node.InnerText = username;
                        break;
                    case "password":
                        node.InnerText = password;
                        break;
                }
            }

            doc.Save(credentialFile);
        }
    }
}
