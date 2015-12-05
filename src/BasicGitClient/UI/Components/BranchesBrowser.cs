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
            eventManager_m.OnRefreshControlsRequest += new UIEventManager.RefreshControlsEvent(eventManager_m_OnRefreshControlsRequest);
        } // end method

        #endregion

        #region Private Methods

        private void ctxBranchesMenuToolStripItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            if (menuItem == newBranchToolStripMenuItem)
            {
                SingleTextBoxDialogWindow branchNameInputBox = new SingleTextBoxDialogWindow("Branch", "Name");
                DialogResult result = branchNameInputBox.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string newBranchName = branchNameInputBox.TextField;
                    eventManager_m.TriggerNewGitCommandEvent(String.Format(GitCommands.BRANCH_CREATE, newBranchName));

                    eventManager_m.TriggerRefreshControlsEvent();
                } // end if
            }
            else if (menuItem == checkoutToolStripMenuItem)
            {
                checkoutSelectedBranch();
            }
            else if (menuItem == deleteToolStripMenuItem)
            {
            } // end if
        } // end method

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
                    branchName = branch.Remove(0, 2);

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
            checkoutSelectedBranch();
        } // end method

        private void checkoutSelectedBranch()
        {
            if (lvLocalBranches.SelectedItems.Count == 0)
            {
                return;
            } // end if


            string branch = lvLocalBranches.SelectedItems[0].Text;
            if (branch.StartsWith("*"))
            {
                branch = branch.Remove(0, 2);
            } // end if

            eventManager_m.TriggerNewGitCommandEvent(String.Format(GitCommands.BRANCH_CHECKOUT, branch));
            eventManager_m.TriggerNewGitBranchCheckout(branch);

            eventManager_m.TriggerRefreshControlsEvent();
        } // end method

        private void eventManager_m_OnRefreshControlsRequest()
        {
            updateBranches();
        } // end method

        private void updateBranches()
        {
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_LOCAL);
            eventManager_m.TriggerNewGitCommandEvent(GitCommands.BRANCH_REMOTE);
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
