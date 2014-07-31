using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace BasicGitClient
{
    public class GitClientAccess
    {
        public string Directory { get; private set; }

        private ProcessStartInfo info;
        private Process gitProc;

        public GitClientAccess()
        {
            info = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                FileName = "git"
            };
        }

        public void SetDirectory(string directory)
        {
            Directory = info.WorkingDirectory = directory;
        }

        public void RunGitCommand(string command, out string stdout, out string stderror)
        {
            gitProc = new Process();

            info.Arguments = command;
            gitProc.StartInfo = info;
            gitProc.Start();

            stdout = gitProc.StandardOutput.ReadToEnd();
            stderror = gitProc.StandardError.ReadToEnd();

            gitProc.WaitForExit();
            gitProc.Close();
        }
    }
}
