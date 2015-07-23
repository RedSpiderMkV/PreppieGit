﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace BasicGitClient
{
    /// <summary>
    /// Class to access the git client via input/output redirection.
    /// </summary>
    public class GitClientAccessor
    {
        #region Properties
        
        /// <summary>
        /// Directory in which client will operate.
        /// i.e. repo directory.
        /// </summary>
        public string RepoDirectory { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialise a new object to access the git client.
        /// <param name="eventManager">Event manager used throughout app.</param>
        /// </summary>
        internal GitClientAccessor(UIEventManager eventManager)
        {
            eventManager_m = eventManager;

            eventManager_m.OnDirectoryChanged += new UIEventManager.DirectoryChangedEvent(eventManager_m_OnDirectoryChanged);
            eventManager_m.OnNewGitCommandIssued += new UIEventManager.NewGitCommandEvent(eventManager_m_OnNewGitCommandIssued);

            procInfo_m = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                FileName = "git"
            };
        } // end method

        #endregion

        #region Public Methods

        /// <summary>
        /// Change working directory.
        /// </summary>
        /// <param name="directory"></param>
        public void SetDirectory(string directory)
        {
            RepoDirectory = procInfo_m.WorkingDirectory = directory;
        } // end method

        /// <summary>
        /// Run a git command and retrieve the output and error messages.
        /// </summary>
        /// <param name="command">Git command to execute.</param>
        /// <param name="stdout">Standard output from git process.</param>
        /// <param name="stderror">Standard error from git process.</param>
        public void RunGitCommand(string command, out string stdout, out string stderror)
        {
            using (Process gitProc = new Process())
            {
                procInfo_m.Arguments = command;
                gitProc.StartInfo = procInfo_m;
                gitProc.Start();

                stdout = gitProc.StandardOutput.ReadToEnd();
                stderror = gitProc.StandardError.ReadToEnd();

                gitProc.WaitForExit();
                gitProc.Close();
            } // end using
        } // end method

        #endregion

        #region Private Methods

        /// <summary>
        /// New command event handler, triggered when new commands are issued.
        /// </summary>
        /// <param name="command">Command to be executed.</param>
        private void eventManager_m_OnNewGitCommandIssued(string command)
        {
            string error = "", output = "";

            RunGitCommand(command, out output, out error);

            if (command.Equals(GitCommands.ADD) || command.Equals(GitCommands.ADD_ALL))
            {
                if (String.IsNullOrEmpty(output) && String.IsNullOrEmpty(error))
                {
                    output = Environment.NewLine + "Added all modified files.  Check status " + Environment.NewLine;
                } // end if
            } // end if

            eventManager_m.TriggerGitResponseEvent(output, error);
        } // end method

        /// <summary>
        /// Directory changed event handler.
        /// </summary>
        /// <param name="newDirectoryFullPath">New directory, name and path.</param>
        private void eventManager_m_OnDirectoryChanged(string newDirectoryFullPath)
        {
            SetDirectory(newDirectoryFullPath);
        } // end method

        #endregion

        #region Private Data

        // Process runner information.
        private ProcessStartInfo procInfo_m;
        // Event manager - events used to interact with rest of program.
        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
