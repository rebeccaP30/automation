using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using CSharpSeleniumFramework.utilities;
using CSharpSeleniumFramework.pageObjects;
using AngleSharp.Text;

namespace CSharpSeleniumFramework.tests
{
    public class E2ETest : Base
    {

        [Test]
        // [TestCase("rahulshettyacademy", "learning")]
        [TestCaseSource("AddTestDataConfig")]
        public void EndToEndFlow(String username, String password, String[] expectedProduct)
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productPage =loginPage.validLogin(username, password);
            productPage.waitForPageDisplay();

            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    product.FindElement(productPage.addToCartButton()).Click();
                }
            }
            CheckoutPage checkoutPage = productPage.checkout();
     
            IList<IWebElement> checkoutCards = checkoutPage.getCards();

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            checkoutPage.checkOut();




            driver.Value.FindElement(By.Id("country")).SendKeys("sou");
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("South Afriva")));
            driver.Value.FindElement(By.LinkText("India")).Click();


            driver.Value.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.Value.FindElement(By.CssSelector("[value='Purchase']")).Click();
            String confirText = driver.Value.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirText);


        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData("rahulshettyacademy", "learning");
           
        }

}
}
