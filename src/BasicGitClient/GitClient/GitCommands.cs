using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicGitClient
{
    /// <summary>
    /// Git Commands - Support for others to be added later.
    /// </summary>
    public class GitCommands
    {
        public const string ADD = "add";
        public const string ADD_ALL = "add -A";
        public const string CLONE = "clone ";
        public const string COMMIT = "commit -m";
        public const string INIT = "init";
        public const string PULL = "pull";
        public const string SET_ORIGIN_BRANCH = "remote add origin ";
        public const string SET_EMAIL = "config --global user.email ";
        public const string SET_URL_ORIGIN_BRANCH = "remote set-url origin ";
        public const string SET_USERNAME = "config --global user.name ";
        public const string SHOW_ORIGIN = "remote -v";
        public const string STATUS = "status";
        public const string RESET = "reset --hard";
        public const string REVERT = "revert HEAD";
        public const string VERSION = "--version";
        public const string BRANCH_LOCAL = "branch";
        public const string BRANCH_REMOTE = "branch -r";
        public const string BRANCH_GET_CURRENT = "rev-parse --abbrev-ref HEAD";

        public static string BRANCH_CHECKOUT = "checkout {0}";
        public static string PUSH = "push -u https://{0}:{1}@github.com/{0}/{2} {3}";
    }
}
