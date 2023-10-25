using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.pageObjects
{
    public class ProductsPage
    {
        IWebDriver driver;
        By cardTitle = By.CssSelector(".card-title a");
        By addToCart = By.CssSelector(".card-footer button");
        

        public ProductsPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "checkout")]
        private IList<IWebElement> checkoutButton;

        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public By getCardTitle()
        {
            return cardTitle;
        }

        public CheckoutPage checkout()
        {
            checkoutButton.Click();
            return new CheckoutPage(driver);
        }

        public By addToCartButton()
        {
            return addToCart;
        }

    }
}
