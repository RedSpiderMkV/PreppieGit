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
    internal partial class BranchesBrowser : UserControl
    {
        #region Public Methods

        public BranchesBrowser(UIEventManager eventManager)
        {
            InitializeComponent();
            eventManager_m = eventManager;

            this.Dock = DockStyle.Fill;

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

        private void lbLocalBranches_DoubleClick(object sender, EventArgs e)
        {
            if (lbLocalBranches.SelectedItem == null)
            {
                return;
            } // end if

            string branch = lbLocalBranches.GetItemText(lbLocalBranches.SelectedItem);
            if (branch.StartsWith("*"))
            {
                branch = branch.Remove(0, 1);
            } // end if

            eventManager_m.TriggerNewGitCommandEvent(String.Format(GitCommands.BRANCH_CHECKOUT, branch));
            eventManager_m.TriggerNewGitBranchCheckout(branch);
            
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_LOCAL);
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_REMOTE);
            eventManager_m.TriggerDirectoryRefreshEvent();
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
