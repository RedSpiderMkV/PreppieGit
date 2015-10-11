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
    internal partial class BranchBrowser : UserControl
    {
        #region Public Methods

        public BranchBrowser(UIEventManager eventManager)
        {
            InitializeComponent();
            eventManager_m = eventManager;

            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            eventManager_m.OnNewGitBranchEvent += new UIEventManager.GitBranchResponseEvent(eventManager_m_OnNewGitBranchEvent);
        } // end method

        #endregion

        #region Private Methods

        private void eventManager_m_OnNewGitBranchEvent(string output, BranchResponseType branchType)
        {
            switch (branchType)
            {
                case BranchResponseType.LOCAL:
                    setListBoxValues(output, lbLocalBranches);
                    break;
                case BranchResponseType.REMOTE:
                    setListBoxValues(output, lbRemoteBranches);
                    break;
                default:
                    break;
            } // end switch
        } // end method

        private void setListBoxValues(string branches, ListBox listBox)
        {
            listBox.Items.Clear();

            foreach (string branch in branches.Split('\n'))
            {
                if (String.IsNullOrEmpty(branch) || String.IsNullOrWhiteSpace(branch))
                {
                    continue;
                } // end if

                listBox.Items.Add(branch);
            } // end foreach
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;

        #endregion

    } // end class
} // end namespace
