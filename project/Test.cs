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
    class Test : Website
    {

        [Test, Order(1)]
        //test travel method
        public void TestTravel()
        {
            Website web = new Website();

            //launch browser
            web.LuanchBrowser();
            
            //navigate to travel
            web.NavigateToTravel();

            //check wheteher sub topics "Tell me more"/"Discover more"
            Thread.Sleep(5000);

            //click on sub tab
            web.VerifyCurrencyConverter();

            //getting list af all subtabs under tab
            IList<IWebElement> _subTasks = driver.FindElements(By.XPath("//div[@class='cta-wrapper']"));
            int _noOfTasks = _subTasks.Count();
            for (int i = 0; i < _noOfTasks; i++)
            {
                String _taskText = _subTasks.ElementAt(i).Text;
                if ((_taskText == "Foreign exchange calculator") || (_taskText == "Exchange rates"))
                {
                    Assert.Pass("Vrified subtasks of Currency Converter");
                }
            }
            web.QuitBrowser();
        } 
           

        //tets log on by asserting presence of textboxes username and password
        [Test, Order(2)]
        public void TestLogOn()
        {
            Website web = new Website();

            //launch browser
            web.LuanchBrowser();

            //navigate to travel page
            web.NavigateToTravel();
           
            //click on Net bank link 
            driver.FindElement(By.XPath("//*[@id='how']/div/div[2]/div/div[3]/div/ol/li[1]/a")).Click();

             //switch window
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(4000);

            IWebElement _username = driver.FindElement(By.Id("txtMyClientNumber_field"));
            IWebElement _password = driver.FindElement(By.Id("txtMyPassword_field"));

            //verifying username and password on the net bank page
            if (_username.Displayed && _password.Displayed)
           {
                Assert.Pass("Username and password fields exist");
            }

            web.QuitBrowser();

        }

    }
}


