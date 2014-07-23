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

        public Form1()
        {
            InitializeComponent();
            gitClient = new GitClientAccess();
        }

        private void btnSetDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            // TODO: Make this come from a config file and not hard coded..
            string defaultDir = @"E:\Documents and Settings\Nikeah\My Documents\Python\Python_2014";
            if (Directory.Exists(defaultDir))
            {
                fbd.SelectedPath = defaultDir;
            }

            DialogResult result = fbd.ShowDialog();

            string directory = fbd.SelectedPath;
            tbDirectory.Text = directory;

            string error, output;
            gitClient.SetDirectory(directory);
            gitClient.RunGitCommand("status", out output, out error);

            tbOutput.Text += output.Replace("\n", Environment.NewLine);
            tbOutput.Text += error.Replace("\n", Environment.NewLine);
        }
    }
}
