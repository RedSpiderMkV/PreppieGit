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

            lvLocalBranches.Columns[1].Width = tabPageEX3.Width - 50;

            eventManager_m.OnNewGitBranchEvent += new UIEventManager.GitBranchResponseEvent(eventManager_m_OnNewGitBranchEvent);
        } // end method

        #endregion

        #region Private Methods

        private void eventManager_m_OnNewGitBranchEvent(string output, BranchResponseType branchType)
        {
            switch (branchType)
            {
                case BranchResponseType.LOCAL:
                    setListViewValues(output, lvLocalBranches);
                    break;
                case BranchResponseType.REMOTE:
                    setListViewValues(output, lvRemoteBranches);
                    break;
                default:
                    break;
            } // end switch
        } // end method

        private void setListViewValues(string branches, ListView listView)
        {
            listView.Items.Clear();

            foreach (string branch in branches.Split('\n'))
            {
                if (String.IsNullOrEmpty(branch) || String.IsNullOrWhiteSpace(branch))
                {
                    continue;
                } // end if

                string branchName = branch;
                ListViewItem item = new ListViewItem(branchName);

                if (branch.StartsWith("*"))
                {
                    branchName = branch.Substring(1);

                    item = new ListViewItem(branchName);
                    item.SubItems.Add("*");
                } // end if

                listView.Items.Add(item);
            } // end foreach
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

        private void lvLocalBranches_DoubleClick(object sender, EventArgs e)
        {
            /*if (lvLocalBranches.SelectedItem == null)
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
            eventManager_m.TriggerDirectoryRefreshEvent();*/
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
