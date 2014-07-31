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

            if (command.StartsWith("push"))
            {
                System.Threading.Thread.Sleep(5000);
                string username = File.ReadAllLines(@"E:\Documents and Settings\Nikeah\Desktop\username.txt")[0];
                string password = File.ReadAllLines(@"E:\Documents and Settings\Nikeah\Desktop\password.txt")[0];

                gitProc.StandardInput.WriteLine(username);
                gitProc.StandardInput.Write(password);
            }

            stdout = gitProc.StandardOutput.ReadToEnd();
            stderror = gitProc.StandardError.ReadToEnd();

            gitProc.WaitForExit();

            gitProc.Close();
        }
    }
}
