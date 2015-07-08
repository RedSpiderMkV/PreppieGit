using System;
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
    public class GitClientAccess
    {
        #region Public Properties
        
        /// <summary>
        /// Directory in which client will operate.
        /// i.e. repo directory.
        /// </summary>
        public string RepoDirectory { get; private set; }

        #endregion

        #region Private Data

        // Process runner information.
        private ProcessStartInfo procInfo_m;
        private Process gitProc_m;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialise a new object to access the git client.
        /// </summary>
        public GitClientAccess()
        {
            procInfo_m = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                FileName = "git"
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Change working directory.
        /// </summary>
        /// <param name="directory"></param>
        public void SetDirectory(string directory)
        {
            RepoDirectory = procInfo_m.WorkingDirectory = directory;
        }

        /// <summary>
        /// Run a git command and retrieve the output and error messages.
        /// </summary>
        /// <param name="command">Git command to execute.</param>
        /// <param name="stdout">Standard output from git process.</param>
        /// <param name="stderror">Standard error from git process.</param>
        public void RunGitCommand(string command, out string stdout, out string stderror)
        {
            gitProc_m = new Process();

            procInfo_m.Arguments = command;
            gitProc_m.StartInfo = procInfo_m;
            gitProc_m.Start();

            stdout = gitProc_m.StandardOutput.ReadToEnd();
            stderror = gitProc_m.StandardError.ReadToEnd();

            gitProc_m.WaitForExit();
            gitProc_m.Close();
        }

        #endregion
    }
}
