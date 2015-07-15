using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicGitClient
{
    internal class UIEventManager
    {
        #region Events

        public delegate void DirectoryChangedEvent(string newDirectoryFullPath);
        public event DirectoryChangedEvent OnDirectoryChanged;

        #endregion

        #region Public Methods

        public void TriggerDirectoryChangedEvent(string newDirectory)
        {
            DirectoryChangedEvent handler = OnDirectoryChanged;
            if (handler != null)
            {
                OnDirectoryChanged(newDirectory);
            } // end if
        } // end method

        #endregion

    } // end class
} // end namespace
