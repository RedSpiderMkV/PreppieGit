using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicGitClient
{
    internal class SelectedDirectoryEventManager
    {
        #region Events

        public delegate void SelectedDirectoryNodeChangedEvent(string directoryFullPath);
        public event SelectedDirectoryNodeChangedEvent OnSelectedDirectoryNodeChanged;

        #endregion

        public void TriggerSelectedDirectoryChangedEvent(string directoryFullPath)
        {
            SelectedDirectoryNodeChangedEvent handler = OnSelectedDirectoryNodeChanged;
            if (handler != null)
            {
                OnSelectedDirectoryNodeChanged(directoryFullPath);
            } // end if
        } // end method

        #region Public Methods

        #endregion
    } // end class
} // end namespace
