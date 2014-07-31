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
    public partial class Form1 : Form
    {
        private GitClientAccess gitClient;
        private string error, output;
        private string comment = String.Empty;
        // TODO: Make this come from a config file and not hard coded..
        private static string defaultDir = @"E:\Documents and Settings\Nikeah\My Documents\Python\Python_2014";
        private string remoteName;

        public Form1()
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

            string directory = fbd.SelectedPath;
            tbDirectory.Text = directory;

            gitClient.SetDirectory(directory);

            // get remote name
            tbnShowOrigin_Click(null, new EventArgs());
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.STATUS, out output, out error);
            
            tbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            tbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.ADD_ALL, out output, out error);

            if (String.Equals(String.Empty, output) && String.Equals(String.Empty, error))
            {
                tbOutput.AppendText(Environment.NewLine + "Added all modified files.  Check status" + Environment.NewLine);
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            CommitCommentWindow commitWindow = new CommitCommentWindow();
            commitWindow.CommitCommentEvent += new CommitCommentWindow.CommitCommentStringHandler(commitWindow_CommitCommentEvent);
            commitWindow.ShowDialog();

            if (comment != String.Empty)
            {
                string command = GitCommands.COMMIT + " " + comment;

                gitClient.RunGitCommand(command, out output, out error);

                tbOutput.AppendText(output.Replace("\n", Environment.NewLine));
                tbOutput.AppendText(error.Replace("\n", Environment.NewLine));
            }
            else
            {
                tbOutput.AppendText("\nNo comment added.  Not committed..");
            }

            commitWindow.CommitCommentEvent -= commitWindow_CommitCommentEvent;
        }

        private void commitWindow_CommitCommentEvent(string comment, EventArgs e)
        {
            this.comment = "\"" + comment + "\"";
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            string username = File.ReadAllLines(@"E:\Documents and Settings\Nikeah\Desktop\username.txt")[0];
            string password = File.ReadAllLines(@"E:\Documents and Settings\Nikeah\Desktop\password.txt")[0];

            string command = String.Format(GitCommands.PUSH, username, password, remoteName);
            gitClient.RunGitCommand(command, out output, out error);

            tbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            tbOutput.AppendText(error.Replace("\n", Environment.NewLine));

            // push then pull required due to master/origin local mismatch
            btnPull_Click(null, new EventArgs());
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.PULL, out output, out error);

            tbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            tbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void tbnShowOrigin_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.SHOW_ORIGIN, out output, out error);

            remoteName = output.Split('\n')[0].Split('\t')[1]
                .Split(new string[] { "(fetch)" }, StringSplitOptions.None)[0]
                .Split(new string[] {"github.com"}, StringSplitOptions.None)[1];

            if (sender != null)
            {
                tbOutput.AppendText(output.Replace("\n", Environment.NewLine));
                tbOutput.AppendText(error.Replace("\n", Environment.NewLine));
            }
        }
    }
}
