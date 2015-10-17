using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class CloneConfigurationWindow : Form
    {
        #region Properties

        public string CloningDirectory { get; private set; }
        public string CloningRepoUrl { get; private set; }

        #endregion

        #region Public Methods

        public CloneConfigurationWindow()
        {
            InitializeComponent();
        } // end method

        #endregion

        #region Private Methods

        private void CloneConfigurationWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                okHandler();
            } 
            else if (e.KeyCode == Keys.Escape)
            {
                cancelHandler();
            } // end if
        } // end method

        private void btnOk_Click(object sender, EventArgs e)
        {
            okHandler();
        } // end method

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelHandler();
        } // end method

        private void btnDirectorySelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                CloningDirectory = fbd.SelectedPath;
                tbDirectory.Text = CloningDirectory;
            }
            else
            {
                CloningDirectory = String.Empty;
            } // end if
        } // end method

        private void okHandler()
        {
            CloningDirectory = tbDirectory.Text;
            CloningRepoUrl = tbUrl.Text;

            string[] repoParts = CloningRepoUrl.Split('/');
            string repoName = "";
            if (repoParts.Length > 0)
            {
                repoName = repoParts[repoParts.Length - 1];
            } // end if

            if (String.IsNullOrEmpty(CloningDirectory) || String.IsNullOrEmpty(CloningRepoUrl))
            {
                MessageBox.Show("Invalid selections");
            }
            else
            {
                CloningDirectory += "\\" + repoName;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            } // end if
        } // end method

        private void cancelHandler()
        {
            CloningDirectory = String.Empty;
            CloningRepoUrl = String.Empty;

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        } // end method

        #endregion
    } // end class
} // end namespace
