using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    public class Locators
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            
            options.AddArguments("--ignore-certificate-errors");
            driver = new ChromeDriver(options);
            //driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
        }




         [Test]
            public void LocatorsIdentification()
            {


                driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
                driver.FindElement(By.Id("username")).Clear();
                driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
                driver.FindElement(By.Name("password")).SendKeys("123456");
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

                driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
               .TextToBePresentInElementValue(driver.FindElement(By.Id("signInBtn")), "Sign In"));

                String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
                TestContext.Progress.WriteLine(errorMessage);

                IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
                String hrefAttr = link.GetAttribute("href");
                //String expectedUrl = "https://rahulshettyacademy.com/#/documents-request";
                //Assert.AreEqual(expectedUrl, hrefAttr);

            }
        }
    }
