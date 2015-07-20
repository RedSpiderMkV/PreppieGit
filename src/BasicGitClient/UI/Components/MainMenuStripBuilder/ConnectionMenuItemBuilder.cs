using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    internal class ConnectionMenuItemBuilder
    {
        #region Public Methods

        public ConnectionMenuItemBuilder(UIEventManager eventManager)
        {
            eventManager_m = eventManager;
        } // end method

        public ToolStripMenuItem GetConnectionMenuItem()
        {
            ToolStripMenuItem connectionMenu = new ToolStripMenuItem()
            {
                Name = "connectionMenuItem",
                Text = "Connection"
            };

            ToolStripMenuItem setCredentialsMenuItem = new ToolStripMenuItem()
            {
                Name = "setCredentialsMenuItem",
                Text = "Set Credentials",
            };

            ToolStripMenuItem configureUsernameMenuItem = new ToolStripMenuItem()
            {
                Name = "configureUsernameMenuItem",
                Text = "Configure Repo Username"
            };

            ToolStripMenuItem configureEmailMenuItem = new ToolStripMenuItem()
            {
                Name = "configureEmailMenuItem",
                Text = "Configure Email Address"
            };

            setCredentialsMenuItem.Click += new EventHandler(setCredentialsMenuItem_Click);
            configureUsernameMenuItem.Click += new EventHandler(configureUsernameMenuItem_Click);
            configureEmailMenuItem.Click += new EventHandler(configureEmailMenuItem_Click);

            connectionMenu.DropDownItems.Add(setCredentialsMenuItem);
            connectionMenu.DropDownItems.Add(new ToolStripSeparator());
            connectionMenu.DropDownItems.Add(configureUsernameMenuItem);
            connectionMenu.DropDownItems.Add(configureEmailMenuItem);

            return connectionMenu;
        } // end method

        #endregion

        #region Private Methods

        private void configureEmailMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void configureUsernameMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        } // end method

        private void setCredentialsMenuItem_Click(object sender, EventArgs e)
        {
            eventManager_m.TriggerUpdateCredentialsEvent(false);
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
