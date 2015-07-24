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

        public ActionMenuItemBuilder(UIEventManager eventManager)
        {
            eventManager_m = eventManager;
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

        #region Private Data

        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
