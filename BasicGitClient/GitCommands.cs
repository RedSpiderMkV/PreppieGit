using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicGitClient
{
    public class GitCommands
    {
        public const string STATUS = "status";
        public const string INIT = "init";
        public const string PULL = "pull";
        public const string COMMIT = "commit -m";
        public const string ADD = "add";
        public const string ADD_ALL = "add -A";
        public const string CLONE = "clone ";
        public const string SHOW_ORIGIN = "remote -v";
        public const string SET_ORIGIN = "remote add origin ";
        public const string RESET = "reset --hard";

        public static string PUSH = "push https://{0}:{1}@github.com{2} master";
    }
}
