using System;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;

namespace Kopra
{
    public static class UserCredentials
    {
        public static string Email { get; set; }

        public static string Password { get; set; }

        public static string UserName { get; set; }

        public static string EmailToUserName(string mail)
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

		/// <summary>
		/// Sets username in localSettings device memory.
		/// </summary>
		public static void SetUserName(TextBlock textBlock)
		{
			SettingsManager loadUserName = new SettingsManager();
			if (loadUserName.Username != null)
				textBlock.Text = loadUserName.Username;
			else
			{
				EmailToUserName(loadUserName.Email);
				textBlock.Text = UserName;
			}
		}
	}
}
