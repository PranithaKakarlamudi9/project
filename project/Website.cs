using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace project
{
    class Website
    {
        //global driver;
        public static IWebDriver driver;
        public void LuanchBrowser()
        {
            //intialising driver with chrome
            driver = new ChromeDriver();

            //maximise window          
            driver.Manage().Window.Maximize();

            //launching browser nad navigate to website
            driver.Navigate().GoToUrl("https://www.commbank.com.au/");

        }
        public void NavigateToTravel()
        {
           
            Thread.Sleep(5000);
            //click on Travel           
            driver.FindElement(By.XPath("//*[@id='products']/div/div/div[1]/div[8]/div/a/div[2]/div")).Click();
            
            Thread.Sleep(3000);
            //click on Tell me more /more discover
            driver.FindElement(By.XPath("//*[@id='products']/div/div[1]/div/div/div[2]/div[1]/div/div/div[3]/p/a")).Click();
          
       
        }
        public void VerifyCurrencyConverter()
        {
            //click on currency converter tab
            driver.FindElement(By.LinkText("Currency converter")).Click(); 

        }
       
        public void  QuitBrowser()
        {
            //closes all browsers opened by selenium
            driver.Quit();
        }

    }
}
