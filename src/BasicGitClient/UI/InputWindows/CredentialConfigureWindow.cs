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
    public partial class CredentialConfigureWindow : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public CredentialConfigureWindow()
        {
            InitializeComponent();
            ClearCredentials();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            okHandler();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelHandler();
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                okHandler();
            }

            if (e.KeyCode == Keys.Escape)
            {
                cancelHandler();
            }
        }

        private void okHandler()
        {
            if (String.IsNullOrEmpty(tbUsername.Text) || String.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Please enter a username and password");
                return;
            }

            Username = tbUsername.Text;
            Password = tbPassword.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        } // end method

        private void cancelHandler()
        {
            ClearCredentials();

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        } // end method

        private void ClearCredentials()
        {
            Username = String.Empty;
            Password = String.Empty;
        }
    }
}
