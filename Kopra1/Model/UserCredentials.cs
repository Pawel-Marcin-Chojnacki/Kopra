using System;

namespace Kopra
{
    class UserCredentials
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

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
