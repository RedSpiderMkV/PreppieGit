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
            if (String.IsNullOrEmpty(tbUsername.Text) || String.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Please enter a username and password");
                return;
            }

            Username = tbUsername.Text;
            Password = tbPassword.Text;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearCredentials();
            this.Close();
        }

        private void ClearCredentials()
        {
            Username = String.Empty;
            Password = String.Empty;
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnOk_Click(this, null);
            }

            if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(this, null);
            }
        }
    }
}
