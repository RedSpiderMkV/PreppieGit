using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class FileBrowser : UserControl
    {
        #region Public Methods

        internal FileBrowser(UIEventManager eventManager, SelectedDirectoryEventManager directoryEventManager)
        {
            InitializeComponent();

            eventManager_m = eventManager;
            directoryEventManager_m = directoryEventManager;

            this.Dock = DockStyle.Fill;
            //this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
            directoryEventManager_m.OnSelectedDirectoryNodeChanged += new SelectedDirectoryEventManager.SelectedDirectoryNodeChangedEvent(directoryEventManager_m_OnSelectedDirectoryNodeChanged);
        } // end method

        #endregion

        #region Private Methods

        private void directoryEventManager_m_OnSelectedDirectoryNodeChanged(string directoryFullPath)
        {
            populateFileList(directoryFullPath);
        } // end method

        private void eventManager_m_OnDirectoryChanged(string newDirectoryFullPath)
        {
            populateFileList(newDirectoryFullPath);
        } // end method

        private void populateFileList(string directory)
        {
            lbFileList.Items.Clear();

            foreach (string fileWithPath in Directory.GetFiles(directory))
            {
                lbFileList.Items.Add(Path.GetFileName(fileWithPath));
            } // end foreach
        } // end method

        #endregion

        #region Private Data

        private UIEventManager eventManager_m;
        private SelectedDirectoryEventManager directoryEventManager_m;

        #endregion

    } // end class
} // end namespace
