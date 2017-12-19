using System;
using System.Linq;

using Xamarin.Auth;

namespace StyleUs
{
    public class AccountManager
    {
        
        public static AccountStore manager;

        public static string UserName
        {
            get
            {
                var account = manager.FindAccountsForService(App.AppName).FirstOrDefault();
                return account?.Username;
            }
        }

        public static string Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return account?.Properties["Password"];
            }
        }

        public static void SaveCredentials(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                Account account = new Account
                {
                    Username = userName
                };
                account.Properties.Add("Password", password);
                AccountStore.Create().Save(account, App.AppName);
            }
        }

        public static void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, App.AppName);
            }
        }
    }
}
