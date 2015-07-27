using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    internal class FileMenuItemBuilder : ISubMenuItemBuilder
    {
        #region Public Methods

        public FileMenuItemBuilder(UIEventManager eventManager, string defaultDirectory)
        {
            eventManager_m = eventManager;
        } // end method

        public ToolStripMenuItem GetSubMenuItem()
        {
            ToolStripMenuItem fileMenu = new ToolStripMenuItem()
            {
                Name = "FileMenuToolStripItem",
                Text = "File"
            };

            ToolStripMenuItem fileMenuOpenDirectory = new ToolStripMenuItem()
            {
                Name = "fileMenuOpenToolStripItem",
                Text = "&Open",
                ShortcutKeys = Keys.Control | Keys.O,
                ShortcutKeyDisplayString = "Ctrl+O",
                ShowShortcutKeys = true
            };

            fileMenuOpenDirectory.Click += new EventHandler(fileMenuOpenDirectory_Click);

            ToolStripMenuItem fileMenuCloseApp = new ToolStripMenuItem()
            {
                Name = "fileMenuCloseToolStripItem",
                Text = "&Close",
                ShortcutKeys = Keys.Alt | Keys.F4,
                ShortcutKeyDisplayString = "Alt+F4",
                ShowShortcutKeys = true
            };

            fileMenuCloseApp.Click += new EventHandler(fileMenuCloseApp_Click);

            fileMenu.DropDownItems.Add(fileMenuOpenDirectory);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(fileMenuCloseApp);

            return fileMenu;
        }

        #endregion

        #region Private Methods

        private void fileMenuOpenDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (Directory.Exists(defaultDir_m))
            {
                fbd.SelectedPath = defaultDir_m;
            } // end if

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string directory = fbd.SelectedPath;

                eventManager_m.TriggerDirectoryChangedEvent(directory);
            } // end if
        } // end method

        private void fileMenuCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;
        private string defaultDir_m;

        #endregion

    } // end class
} // end namespace
