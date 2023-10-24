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
    public class E2ETest
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
        public void EndToEndFlow()
        {
            String[] expectedProducts = { "iphone X", "Blackerry" };
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach ( IWebElement product in products)
            {

                if(expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                    {
                    product.FindElement(By.CssSelector(".card-foorter button")).Click();
                    }
                //product.FindElement(By.XPath("//app-card[1]//div[1]//div[2]//button[1]")).Click();
                //product.FindElement(By.XPath("//app-card[2]//div[1]//div[2]//button[1]")).Click();
                //product.FindElement(By.XPath("//app-card[3]//div[1]//div[2]//button[1]")).Click();

                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")));
            }
           driver.FindElement(By.PartialLinkText("Checkout")).Click();



        }

    }
}
