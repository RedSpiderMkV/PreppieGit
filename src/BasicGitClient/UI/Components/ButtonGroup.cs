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
            panelInner.Location = new Point(panelInner.Location.X + 40, panelInner.Location.Y);
        }

        private void btnScrollLeft_Click(object sender, EventArgs e)
        {
            panelInner.Location = new Point(panelInner.Location.X + 10, panelInner.Location.Y);
        }

        private void btnScrollRight_Click(object sender, EventArgs e)
        {
            panelInner.Location = new Point(panelInner.Location.X - 10, panelInner.Location.Y);
        }
    }
}
