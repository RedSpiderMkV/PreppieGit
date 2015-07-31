using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class ButtonGroup : UserControl
    {
        public ButtonGroup()
        {
            InitializeComponent();
        }

        private void btnScroll_Click(object sender, EventArgs e)
        {
            if (sender == btnScrollLeft)
            {
                panelInner.Location = new Point(panelInner.Location.X + 10, panelInner.Location.Y);
            }
            else if (sender == btnScrollRight)
            {
                panelInner.Location = new Point(panelInner.Location.X - 10, panelInner.Location.Y);
            } // end if
        } // end method

        private void btn_Click(object sender, EventArgs e)
        {
        } // end method
    }
}
