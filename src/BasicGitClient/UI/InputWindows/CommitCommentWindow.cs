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
    public partial class CommitCommentWindow : Form
    {
        public string CommitComment { get; private set; }

        public CommitCommentWindow()
        {
            InitializeComponent();
            CommitComment = String.Empty;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            commitComment();
        }

        private void tbComment_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Enter) || (e.KeyData == Keys.Return))
            {
                commitComment();
            }

            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            } // end if

            if (e.Control && e.KeyCode == Keys.A)
            {
                tbComment.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        private void commitComment()
        {
            CommitComment = String.Format("\"{0}\"", tbComment.Text);

            this.Close();
        }
    }
}
