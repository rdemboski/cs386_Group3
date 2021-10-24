using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using PartyApplication.Model;


namespace PartyTest
{
    public class AccountTest
    {
        public Account testGetAccount(Account account)
        {
            return account;
        }

        public Account testNewAccount(Account account)
        {
            account.Id = account.Username;
            if(account != null)
            {
                return account;
            }
            return null;
        }

        public bool testLogin(Account account, Account user)
        {
            if(account != null)
            {
                if(user != null)
                {
                    if(account.Username == user.Username && account.Passcode == user.Passcode)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        [Fact]
        public void newAccount()
        {
            Account test = new Account();
            Account test2;
            test.Username = "test";
            test.Id = test.Username;
            test.Passcode = "admin";

            test2 = testNewAccount(test);

            Assert.Equal(test, test2);
        }

        [Fact]
        public void getAccount()
        {
            Account test = new Account();
            test.Username = "test";
            test.Id = test.Username;
            test.Passcode = "admin";

            Assert.Equal(test, testGetAccount(test));
        }

        [Fact]
        public void login()
        {
            Account trueInput = new Account(), falseInput = new Account(), existingAccount = new Account();
            existingAccount.Username = "test";
            existingAccount.Passcode = "admin";

            trueInput.Username = existingAccount.Username;
            trueInput.Passcode = existingAccount.Passcode;

            Assert.True(testLogin(existingAccount, trueInput));
            Assert.False(testLogin(existingAccount, falseInput));
        }
    }
}
