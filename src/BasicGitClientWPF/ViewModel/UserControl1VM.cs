using Prism.Mvvm;

namespace BasicGitClientWPF.ViewModel
{
    public class UserControl1VM : BindableBase
    {
        private string _text;
        public string TextBoxText
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged();
            }
        }

        public UserControl1VM()
        {
            _text = "HooHaaHee";
        }
    }
}
