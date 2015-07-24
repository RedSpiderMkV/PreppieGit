using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    internal class ActionMenuItemBuilder
    {
        #region Public Methods

        public ActionMenuItemBuilder(UIActionEventManager actionEventManager)
        {
            actionEventManager_m = actionEventManager;
        } // end method

        public ToolStripMenuItem GetActionMenuItem()
        {
            ToolStripMenuItem actionMenu = new ToolStripMenuItem()
            {
                Name = "actionMenuItem",
                Text = "Actions"
            };

            ToolStripMenuItem setRepoUrlMenuItem = new ToolStripMenuItem()
            {
                Name = "setRepoUrlActionMenuItem",
                Text = "Set Repo URL"
            };

            ToolStripMenuItem resetToHeadMenuItem = new ToolStripMenuItem()
            {
                Name = "resetToHeadUrlActionMenuItem",
                Text = "Reset To Head"
            };

            ToolStripMenuItem cloneUrlMenuItem = new ToolStripMenuItem()
            {
                Name = "cloneUrlActionMenuItem",
                Text = "Clone Repo"
            };

            ToolStripMenuItem initialiseNewRepoActionMenuItem = new ToolStripMenuItem()
            {
                Name = "initialiseNewRepoActionMenuItem",
                Text = "Initialise New Repo"
            };

            ToolStripMenuItem showOriginActionMenuItem = new ToolStripMenuItem()
            {
                Name = "showOriginActionMenuItem",
                Text = "Show Origin"
            };

            ToolStripMenuItem pushChangesActionMenuItem = new ToolStripMenuItem()
            {
                Name = "pushChangesActionMenuItem",
                Text = "Push All"
            };

            ToolStripMenuItem revertLastChangeActionMenuItem = new ToolStripMenuItem()
            {
                Name = "revertLastChangeActionMenuItem",
                Text = "Revert Last Change"
            };

            ToolStripMenuItem commitChangesActionMenuItem = new ToolStripMenuItem()
            {
                Name = "commitChangesActionMenuItem",
                Text = "Commit Changes"
            };

            ToolStripMenuItem updateGitIgnoreActionMenuItem = new ToolStripMenuItem()
            {
                Name = "updateGitIgnoreActionMenuItem",
                Text = "Update .gitignore"
            };

            ToolStripMenuItem changeRepoUrlActionMenuItem = new ToolStripMenuItem()
            {
                Name = "changeRepoUrlActionMenuItem",
                Text = "Change Repo URL"
            };

            setRepoUrlMenuItem.Click += new EventHandler(setRepoUrlMenuItem_Click);
            resetToHeadMenuItem.Click += new EventHandler(resetToHeadMenuItem_Click);
            cloneUrlMenuItem.Click += new EventHandler(cloneUrlMenuItem_Click);
            initialiseNewRepoActionMenuItem.Click += new EventHandler(initialiseNewRepoActionMenuItem_Click);
            showOriginActionMenuItem.Click += new EventHandler(showOriginActionMenuItem_Click);
            pushChangesActionMenuItem.Click += new EventHandler(pushChangesActionMenuItem_Click);
            revertLastChangeActionMenuItem.Click += new EventHandler(revertLastChangeActionMenuItem_Click);
            commitChangesActionMenuItem.Click += new EventHandler(commitChangesActionMenuItem_Click);
            updateGitIgnoreActionMenuItem.Click += new EventHandler(updateGitIgnoreActionMenuItem_Click);
            changeRepoUrlActionMenuItem.Click += new EventHandler(changeRepoUrlActionMenuItem_Click);

            actionMenu.DropDownItems.Add(setRepoUrlMenuItem);
            actionMenu.DropDownItems.Add(resetToHeadMenuItem);
            actionMenu.DropDownItems.Add(cloneUrlMenuItem);
            actionMenu.DropDownItems.Add(initialiseNewRepoActionMenuItem);
            actionMenu.DropDownItems.Add(showOriginActionMenuItem);
            actionMenu.DropDownItems.Add(pushChangesActionMenuItem);
            actionMenu.DropDownItems.Add(revertLastChangeActionMenuItem);
            actionMenu.DropDownItems.Add(commitChangesActionMenuItem);
            actionMenu.DropDownItems.Add(updateGitIgnoreActionMenuItem);
            actionMenu.DropDownItems.Add(changeRepoUrlActionMenuItem);

            return actionMenu;
        } // end method

        #endregion

        #region Private Methods

        private void changeRepoUrlActionMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void updateGitIgnoreActionMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void commitChangesActionMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void revertLastChangeActionMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void pushChangesActionMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void showOriginActionMenuItem_Click(object sender, EventArgs e)
        {
            //eventManager_m.TriggerNewGitCommandEvent(GitCommands.SHOW_ORIGIN);
        } // end method

        private void initialiseNewRepoActionMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void cloneUrlMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void resetToHeadMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void setRepoUrlMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        #endregion

        #region Private Data

        private UIActionEventManager actionEventManager_m;

        #endregion
    } // end class
} // end namespace
