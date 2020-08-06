using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace project
{
    [TestFixture]
    class Test:Website
    {

        [Test,Order(1)]
        //test travel method
        public void TestTravel()
        {
            Website web = new Website();
            
            web.LuanchBrowser();
            web.NavigateToTravel();

            //check wheteher sub topics "Tell me more"/"Discover more"
            Thread.Sleep(5000);
            IWebElement _discoverMore = driver.FindElement(By.LinkText("Discover more"));
            String _discoverMoreText= driver.FindElement(By.LinkText("Discover more")).Text;
            String _expected ="Discove more";

            if (_discoverMore.Displayed)
            {
                Assert.Equals(_expected,_discoverMoreText);
            }
            web.QuitBrowser();
        }
        //tets log on by asserting presence of textboxes username and password
        [Test,Order(2)]
        public void TestLogOn()
        {
            Website web = new Website();

            web.LuanchBrowser();
            web.NavigateToTravel();
            web.LogOn();
            driver.SwitchTo().ActiveElement();
            driver.FindElement(By.Id("txtMyClientNumber_field")).Click();
            IWebElement _username = driver.FindElement(By.Id("txtMyClientNumber_field"));
            driver.FindElement(By.Id("txtMyPassword_field")).Click();
            IWebElement _password = driver.FindElement(By.Id("txtMyPassword_field"));

            if (_username.Displayed && _password.Displayed)
            {
                Assert.Pass();
            }

            web.QuitBrowser();

        }

    }
}
