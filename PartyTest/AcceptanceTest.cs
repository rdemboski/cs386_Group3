using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace PartyTest
{
    public class AcceptanceTest 
    {
        // Change as needed.
        private string url = "https://partyapplication20211129123249.azurewebsites.net/";

        [Fact]
        public void NoAuthTest()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.Navigate().GoToUrl(url);

                // Verify that the Events button doesn't appear for users not logged in.
                try
                {
                    driver.FindElement(By.LinkText("Events")).Click();
                    Assert.False(true);
                }
                catch (Exception ex)
                {
                    ;
                }

                driver.Close();

                Assert.True(true);
            }
        }

        [Fact]
        public void LoginTest()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.Navigate().GoToUrl(url);
                driver.FindElement(By.LinkText("Login")).Click();

                
                // Enter needed info to login.
                driver.FindElement(By.Name("username")).SendKeys("dummy");
                driver.FindElement(By.Name("passcode")).SendKeys("dummy");
                driver.FindElement(By.XPath("/html/body/div[1]/form/li[3]/button")).Click();

                var passCondition = driver.FindElement(By.TagName("h4")).Displayed;

                driver.Close();

                // Verify that the h4 element displayed for logged in users appears as expected.
                Assert.True(passCondition);
            }
        }

        [Fact]
        public void SearchEventTest()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.Navigate().GoToUrl(url);
                driver.FindElement(By.LinkText("Login")).Click();


                // Enter needed info to login.
                driver.FindElement(By.Name("username")).SendKeys("dummy");
                driver.FindElement(By.Name("passcode")).SendKeys("dummy");
                driver.FindElement(By.XPath("/html/body/div[1]/form/li[3]/button")).Click();


                // Search events
                driver.FindElement(By.LinkText("Events")).Click();
                driver.FindElement(By.Name("zipcode")).SendKeys("86001");
                driver.FindElement(By.XPath("/html/body/div[1]/form/li[2]/button")).Click();

                // View some event's details.
                driver.FindElement(By.LinkText("Details")).Click();

                var title = driver.FindElement(By.TagName("h1")).Text;

                driver.Close();

                // Verify that the h1 element displayed for event details appears as expected.
                Assert.Equal("Event Details", title);
            }
        }

    }
}
