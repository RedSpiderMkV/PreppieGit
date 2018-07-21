using System.Diagnostics;
using System.Reflection;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows;
using System.ComponentModel;

namespace BasicGitClientWPF.ViewModel
{
    /// <summary>
    /// ViewModel for the shell.
    /// </summary>
    public class ShellVM : BindableBase
    {
        public string Title { get; }
        public DelegateCommand ClickMeCommand { get; }

        public UserControl1VM UserControl1ViewModel { get; }

        public ShellVM(UserControl1VM userControl1VM)
        {
            UserControl1ViewModel = userControl1VM;
            UserControl1ViewModel.PropertyChanged += UserControl1ViewModel_PropertyChanged;

            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.FileVersion;

            Title = "BasicGitClient - v" + version;

            ClickMeCommand = new DelegateCommand(ClickMeCommand_Execute, ClickMeCommand_CanExecute);
        }

        private void UserControl1ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ClickMeCommand.RaiseCanExecuteChanged();
        }

        private void ClickMeCommand_Execute()
        {
            MessageBox.Show("Yay got clicked");
        }

        private bool ClickMeCommand_CanExecute()
        {
            return string.Equals(UserControl1ViewModel.TextBoxText, "OK");
        }
    }
}
