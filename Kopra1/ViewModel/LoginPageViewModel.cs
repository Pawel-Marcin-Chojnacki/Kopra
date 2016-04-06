using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kopra1.Annotations;

namespace Kopra.ViewModel
{
    class LoginPageViewModel : INotifyPropertyChanged
    {

        public void FillLoginForm(string email, string password)
        {
            Email = email;
            Password = password;
        }

        private string _email;
    
        public string Email {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                NotifyPropertyChanged(nameof(Email));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
