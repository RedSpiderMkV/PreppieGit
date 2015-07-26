using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    internal class HelpMenuItemBuilder
    {
        #region Public Methods

        public HelpMenuItemBuilder()
        {
            // not sure yet what is required here
        } // end method

        public ToolStripMenuItem GetHelpMenuItems()
        {
            ToolStripMenuItem helpMenu = new ToolStripMenuItem()
            {
                Text = "Help",
                Name = "HelpMenu"
            };

            ToolStripMenuItem helpMenuAboutItem = new ToolStripMenuItem()
            {
                Name = "AboutHelpMenuItem",
                Text = "About"
            };

            helpMenu.DropDownItems.Add(helpMenuAboutItem);

            return helpMenu;
        } // end method

        #endregion
    } // end class
} // end namespace
