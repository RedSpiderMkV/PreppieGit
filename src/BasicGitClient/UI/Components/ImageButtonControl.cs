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
    public partial class ImageButtonControl : UserControl
    {
        public ImageButtonControl()
        {
            InitializeComponent();
        }

        private void ImageButtonControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }

        private void ImageButtonControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        private void ImageButtonControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void ImageButtonControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }

        private void ImageButtonControl_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
