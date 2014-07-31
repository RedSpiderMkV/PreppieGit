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
        public const string CLONE = "clone";

        public static string PUSH = "push https://{0}:{1}@github.com/{0}/BasicGitClient.git master";
    }
}
