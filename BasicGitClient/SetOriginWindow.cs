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
    public partial class SetOriginWindow : Form
    {
        public string Url { get; private set; }

        public SetOriginWindow()
        {
            InitializeComponent();
            Url = String.Empty;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbUrl.Text))
            {
                Url = tbUrl.Text;

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
