using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicGitClient
{
    /// <summary>
    /// Git Commands - others can be supported but these are the
    /// most common ones I use.
    /// </summary>
    public class GitCommands
    {
        public const string ADD = "add";
        public const string ADD_ALL = "add -A";
        public const string CLONE = "clone ";
        public const string COMMIT = "commit -m";
        public const string INIT = "init";
        public const string PULL = "pull";
        public const string SET_ORIGIN = "remote add origin ";
        public const string SET_EMAIL = "config --global user.email ";
        public const string SET_URL = "remote set-url origin ";
        public const string SET_USERNAME = "config --global user.name ";
        public const string SHOW_ORIGIN = "remote -v";
        public const string STATUS = "status";
        public const string RESET = "reset --hard";
        public const string REVERT = "revert HEAD";
        public const string VERSION = "--version";

        public static string PUSH = "push https://{0}:{1}@github.com{2} master";
    }
}
