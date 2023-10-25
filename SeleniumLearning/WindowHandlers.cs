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
    public class WindowHandlers
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
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void WindowHandle()
        {
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);
            String childWindowName = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);

        }
    }
}
