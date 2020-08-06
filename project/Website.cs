using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace project
{
    class Website
    {
        public static IWebDriver driver;
        public void LuanchBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //launching browser nad navigate to website
            driver.Navigate().GoToUrl("https://www.commbank.com.au/");

        }
        public void NavigateToTravel()
        {
            //click on Travel
            driver.FindElement(By.XPath("//*[@id='products']/div/div/div[1]/div[8]/div/a/div[2]/div")).Click();
            var element = driver.FindElement(By.XPath("//*[@id='products']/div/div/div[1]/div[8]/div/a/div[2]/div")) ;
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            //click on Tell me more/discover more
            driver.FindElement(By.LinkText("Discover more"));
            


        }
        public void LogOn()
        {
            //click on logon
            driver.FindElement(By.XPath("//*[@id='gloNavUnauth']/nav[1]/div/div/ul[2]/li[2]/a[1]")).Click();
        }
        

    }
}
