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
        // TODO: Make this come from a config file and not hard coded..
        private static string defaultDir = @"E:\Documents and Settings\Nikeah\My Documents\Python\Python_2014";

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
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            string error, output;
            gitClient.RunGitCommand(GitCommands.STATUS, out output, out error);

            tbOutput.Text += output.Replace("\n", Environment.NewLine);
            tbOutput.Text += error.Replace("\n", Environment.NewLine);
        }
    }
}
