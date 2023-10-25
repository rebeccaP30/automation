using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace CSharpSeleniumFramework.utilities
{
    public class Base
    {
        String browserName;
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
        }

        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //configuration
            String browserName =ConfigurationManager.AppSettings["browser"];

            InitBrowser(browserName);

            //options.AddArguments("--ignore-certificate-errors");
            //driver = new ChromeDriver(options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver;
        }
         public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;


                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions options = new ChromeOptions();
                    break;


                case "Edge":
                    driver = new EdgeDriver();
                    break;

            }
            
        }
        
    }
}
