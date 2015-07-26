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
        #region Properties

        public string TextField { get; private set; }

        #endregion

        #region Constructors

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

        #endregion

        #region Private Methods

        private void btnOk_Click(object sender, EventArgs e)
        {
            validateAndCompleteDialog();
        } // end method

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        } // end method

        private void tbInputl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                validateAndCompleteDialog();
            } // end if

            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            } // end if
        } // end method

        private void validateAndCompleteDialog()
        {
            if (!String.IsNullOrEmpty(tbInput.Text))
            {
                TextField = tbInput.Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        } // end method

        #endregion
    }
}
