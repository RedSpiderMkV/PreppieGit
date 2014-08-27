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
    public partial class SingleTextBoxDialogWindow : Form
    {
        public string TextField { get; private set; }

        public SingleTextBoxDialogWindow(string title)
        {
            InitializeComponent();
            TextField = String.Empty;
            this.Text = title;
        }

        public SingleTextBoxDialogWindow(string title, string labelName) : this(title)
        {
            label1.Text = labelName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbUrl.Text))
            {
                TextField = tbUrl.Text;

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
