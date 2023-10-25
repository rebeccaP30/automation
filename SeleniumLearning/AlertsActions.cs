using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class AlertsActions
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();

            options.AddArguments("--ignore-certificate-errors");
            driver = new ChromeDriver(options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]
        public void test_Alerts()
        {
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys("Rebecca");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("confirmbtn")).Click();
            Thread.Sleep(5000);
            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();

        }

        [Test]
        public void test_AutoSuggestiveDropDowns() 
        {
            driver.FindElement(By.XPath("//input[@id='autocomplete']")).SendKeys("Sout");
            Thread.Sleep(5000);
            IList <IWebElement> options = driver.FindElements(By.XPath("//div[@id='ui-id-20']"));

            foreach (IWebElement option in options)
            {
                if(option.Text.Equals("South Africa"))
                {
                    option.Click();
                }
                    
            }
        
        }
    }
}
