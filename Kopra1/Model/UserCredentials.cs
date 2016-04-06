using System;

namespace Kopra
{
    class UserCredentials
    {
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName;  }
            set { userName = value; }
        }

        public string EmailToUserName(string mail)
        {
            try
            {
                var indexOfAtSignInEmail = mail.IndexOf("@", StringComparison.Ordinal);

                if (indexOfAtSignInEmail == -1) return null;
                mail = mail.Substring(0, indexOfAtSignInEmail);
            }
            catch (Exception) {
                UserName = "invalid mail";
                return UserName;
            }
            UserName = mail;
            return mail;
        }
    }
}
