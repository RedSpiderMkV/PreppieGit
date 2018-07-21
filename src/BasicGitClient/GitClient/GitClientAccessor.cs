using System;
using System.Diagnostics;

namespace BasicGitClient
{
    /// <summary>
    /// Class to access the git client via input/output redirection.
    /// </summary>
    public class GitClientAccessor
    {
        #region Private Data

        // Process runner information.
        private ProcessStartInfo procInfo_m;
        // Event manager - events used to interact with rest of program.
        private UIEventManager eventManager_m;

        #endregion

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

            // TODO: this needs to be modified to make it more generic or something
            if (validateOutput(command, GitCommands.SET_URL_ORIGIN_BRANCH, output, error))
            {
                output = Environment.NewLine + "URL has been set.  Check URL\r\n" + Environment.NewLine;
            } // end if

            if (validateOutput(command, GitCommands.ADD, output, error))
            {
                output = Environment.NewLine + "Added all modified files.  Check status " + Environment.NewLine;
            } // end if

            if (String.Equals(command, GitCommands.BRANCH_LOCAL))
            {
                eventManager_m.TriggerNewBranchResponseEvent(output, BranchResponseType.LOCAL);
            }
            else if (String.Equals(command, GitCommands.BRANCH_REMOTE))
            {
                eventManager_m.TriggerNewBranchResponseEvent(output, BranchResponseType.REMOTE);
            }
            else if (String.Equals(command, GitCommands.BRANCH_GET_CURRENT))
            {
                output = output.Trim();
                eventManager_m.TriggerNewGitBranchCheckout(output);
            }
            else
            {
                eventManager_m.TriggerGitResponseEvent(output, error);
            } // end if
        } // end method

        private bool validateOutput(string receivedCommand, string commandType, string output, string error)
        {
            return (receivedCommand.StartsWith(commandType) && String.IsNullOrEmpty(output) && String.IsNullOrEmpty(error));
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
    } // end class
} // end namespace
