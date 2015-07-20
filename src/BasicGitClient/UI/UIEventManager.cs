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

        public delegate void UpdateCredentialsEvent(bool showMessage);
        public event UpdateCredentialsEvent OnCredentialsUpdateRequired;

        public delegate void NewCredentialsEvent(string username, string password);
        public event NewCredentialsEvent OnNewCredentials;

        #endregion

        #region Public Methods

        public void TriggerNewCredentialsEvent(string username, string password)
        {
            NewCredentialsEvent handler = OnNewCredentials;
            if (handler != null)
            {
                OnNewCredentials(username, password);
            } // end if
        } // end method

        public void TriggerDirectoryChangedEvent(string newDirectory)
        {
            DirectoryChangedEvent handler = OnDirectoryChanged;
            if (handler != null)
            {
                OnDirectoryChanged(newDirectory);
            } // end if
        } // end method

        public void TriggerUpdateCredentialsEvent(bool showMessageBox)
        {
            UpdateCredentialsEvent handler = OnCredentialsUpdateRequired;
            if (handler != null)
            {
                OnCredentialsUpdateRequired(showMessageBox);
            } // end if
        } // end method

        #endregion

    } // end class
} // end namespace
