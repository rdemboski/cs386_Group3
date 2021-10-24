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

    public class EventTest
    {
        public Event NewPartyTest(Event party)
        {
            party.Id = party.Name;
            if(party != null)
            {
                return party;
            }
            return null;
        }

        public List<Event> GetPartiesByZipcodeTest(List<Event> givenEvents, string zipcode)
        {
            /*
             * Analogous to "GetPartiesAsync" query in EventController
             */
            List<Event> events = new List<Event>();
            for(int i = 0; i < givenEvents.Count; i++)
            {
                if(givenEvents[i].Zipcode == zipcode)
                {
                    events.Add(givenEvents[i]);
                }
            }
            if(events!=null)
            {
                return events;
            }
            return null;
        }

        [Fact]
        public void NewParty()
        {
            Event party = new Event();
            party.Name = "test";
            party.Id = party.Name;

            Assert.Equal(party, NewPartyTest(party));
        }

        [Fact]
        public void GetPartiesByZipcode()
        {
            List<Event> testEvents = new List<Event>();
            Event test1 = new Event(), test2 = new Event(), test3 = new Event();
            test1.Zipcode = "1234";
            test1.Name = "Wrong";

            test2.Zipcode = "86001";
            test2.Name = "Correct1";

            test3.Zipcode = "86001";
            test3.Name = "Correct2";

            testEvents.Add(test1);
            testEvents.Add(test2);
            testEvents.Add(test1);
            testEvents.Add(test3);

            Assert.NotEmpty(GetPartiesByZipcodeTest(testEvents, "86001"));
            Assert.Equal("86001", GetPartiesByZipcodeTest(testEvents, "86001")[0].Zipcode);
        }
    }

    public class SupportTests
    {
        public Support TestNewTicket(Support ticket)
        {
            if(ticket != null)
            {
                return ticket;
            }
            return null;
        }

        [Fact]
        public void NewTicket()
        {
            Support test = new Support();
            test.Id = "test";
            test.Message = "message";

            Assert.Equal(test, TestNewTicket(test));
        }
    }
}
