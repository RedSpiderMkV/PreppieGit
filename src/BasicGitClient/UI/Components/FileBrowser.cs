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
    public partial class FileBrowser : UserControl
    {
        #region Public Methods

        internal FileBrowser(UIEventManager eventManager)
        {
            InitializeComponent();

            eventManager_m = eventManager;

            this.Dock = DockStyle.Fill;
            //this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
        } // end method

        #endregion

        #region Private Methods

        private void eventManager_m_OnDirectoryChanged(string newDirectoryFullPath)
        {
            
        } // end method

        #endregion

        #region Private Methods

        private UIEventManager eventManager_m;

        #endregion

    } // end class
} // end namespace
