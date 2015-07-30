using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    internal class ActionMenuItemBuilder : ISubMenuItemBuilder
    {
        #region Public Methods

        public ActionMenuItemBuilder(UIEventManager eventManager, UIActionEventManager actionEventManager)
        {
            actionEventManager_m = actionEventManager;
            eventManager_m = eventManager;
        } // end method

        public ToolStripMenuItem GetSubMenuItem()
        {
            ToolStripMenuItem actionMenu = new ToolStripMenuItem()
            {
                Name = "actionMenuItem",
                Text = "Actions"
            };

            ToolStripMenuItem setRepoOriginMenuItem = new ToolStripMenuItem()
            {
                Name = "setRepoUrlActionMenuItem",
                Text = "Set Repo Origin"
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

            ToolStripMenuItem revertLastChangeActionMenuItem = new ToolStripMenuItem()
            {
                Name = "revertLastChangeActionMenuItem",
                Text = "Revert Last Change"
            };

            ToolStripMenuItem changeRepoUrlActionMenuItem = new ToolStripMenuItem()
            {
                Name = "changeRepoUrlActionMenuItem",
                Text = "Change Repo URL"
            };

            setRepoOriginMenuItem.Click += new EventHandler(setRepoOriginMenuItem_Click);
            resetToHeadMenuItem.Click += new EventHandler(resetToHeadMenuItem_Click);
            cloneUrlMenuItem.Click += new EventHandler(cloneUrlMenuItem_Click);
            initialiseNewRepoActionMenuItem.Click += new EventHandler(initialiseNewRepoActionMenuItem_Click);
            showOriginActionMenuItem.Click += new EventHandler(showOriginActionMenuItem_Click);
            revertLastChangeActionMenuItem.Click += new EventHandler(revertLastChangeActionMenuItem_Click);
            changeRepoUrlActionMenuItem.Click += new EventHandler(changeRepoUrlActionMenuItem_Click);

            actionMenu.DropDownItems.Add(setRepoOriginMenuItem);
            actionMenu.DropDownItems.Add(resetToHeadMenuItem);
            actionMenu.DropDownItems.Add(cloneUrlMenuItem);
            actionMenu.DropDownItems.Add(initialiseNewRepoActionMenuItem);
            actionMenu.DropDownItems.Add(showOriginActionMenuItem);
            actionMenu.DropDownItems.Add(revertLastChangeActionMenuItem);
            actionMenu.DropDownItems.Add(changeRepoUrlActionMenuItem);

            return actionMenu;
        } // end method

        #endregion

        #region Private Methods

        private void changeRepoUrlActionMenuItem_Click(object sender, EventArgs e)
        {
            runCommandWithSingleTextInput(GitCommands.SET_URL_ORIGIN_BRANCH, "Set Repo URL");
            runCommand(GitCommands.SHOW_ORIGIN);
        } // end method

        private void revertLastChangeActionMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.REVERT);
        } // end method

        private void showOriginActionMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.SHOW_ORIGIN);
        } // end method

        private void initialiseNewRepoActionMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.INIT);
        } // end method

        private void cloneUrlMenuItem_Click(object sender, EventArgs e)
        {
            runCommandWithSingleTextInput(GitCommands.CLONE, "Clone");
            eventManager_m.TriggerCompletionNotificationEvent("Cloning complete");
        } // end method

        private void resetToHeadMenuItem_Click(object sender, EventArgs e)
        {
            runCommand(GitCommands.RESET);
        } // end method

        private void setRepoOriginMenuItem_Click(object sender, EventArgs e)
        {
            runCommandWithSingleTextInput(GitCommands.SET_ORIGIN_BRANCH, "URL");
        } // end method

        private void runCommand(string command)
        {
            eventManager_m.TriggerNewGitCommandEvent(command);
        } // end method

        private void runCommandWithSingleTextInput(string gitCommand, string label)
        {
            SingleTextBoxDialogWindow newUrlDialog = new SingleTextBoxDialogWindow(label);
            DialogResult dialogResult = newUrlDialog.ShowDialog();

            if (!String.IsNullOrEmpty(newUrlDialog.TextField))
            {
                runCommand(gitCommand + newUrlDialog.TextField);
            } // end if
        } // end method

        #endregion

        #region Private Data

        private UIActionEventManager actionEventManager_m;
        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
