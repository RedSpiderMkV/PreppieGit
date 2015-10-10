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
    public partial class BranchBrowser : UserControl
    {
        public BranchBrowser()
        {
            InitializeComponent();
            
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
    }
}
