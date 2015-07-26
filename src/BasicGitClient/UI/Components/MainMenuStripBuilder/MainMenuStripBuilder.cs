using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    internal class MainMenuStripBuilder
    {
        #region Public Methods

        public MainMenuStripBuilder(Color menuBackgroundColor, UIEventManager eventManager, UIActionEventManager actionEventManager, string defaultDirectory)
        {
            mainMenuStrip_m = new MenuStrip();
            mainMenuStrip_m.BackColor = menuBackgroundColor;

            eventManager_m = eventManager;
            defaultDir_m = defaultDirectory;
        } // end method

        public MenuStrip GetMainMenuStrip()
        {
            mainMenuStrip_m.Items.Add((new FileMenuItemBuilder(eventManager_m, defaultDir_m)).GetFileMenu());
            mainMenuStrip_m.Items.Add((new ConnectionMenuItemBuilder(eventManager_m)).GetConnectionMenuItem());
            mainMenuStrip_m.Items.Add((new ActionMenuItemBuilder(eventManager_m, actionEventManager_m)).GetActionMenuItem());
            mainMenuStrip_m.Items.Add((new HelpMenuItemBuilder()).GetHelpMenuItems());

            return mainMenuStrip_m;
        } // end method

        #endregion

        #region Private Data

        private MenuStrip mainMenuStrip_m;
        private UIEventManager eventManager_m;
        private UIActionEventManager actionEventManager_m;
        private string defaultDir_m;

        #endregion

    } // end class
} // end namespace
