using BasicGitClientWPF.ViewModel;
using System;

namespace BasicGitClientWPF
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var application = new App();
            application.InitializeComponent();

            var shell = new Shell();

            var userControl1VM = new UserControl1VM();
            shell.DataContext = new ShellVM(userControl1VM);
            application.Run(shell);
        }
    }
}
