using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObjects
{
    // driver.FindElements(By.CssSelector("h4 a"));
    public class CheckoutPage
    {
        private IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IList<IWebElement> checkoutButton;
        

        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }

        public void checkOut()
        {
            checkoutButton.Click();
        }
    }
}
