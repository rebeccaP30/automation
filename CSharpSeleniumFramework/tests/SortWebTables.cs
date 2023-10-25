using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSeleniumFramework.utilities
{
    public class SortWebTables : Base
    {
        
        [Test]
        public void SortTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");
            IList <IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            
            }
            
            TestContext.Progress.WriteLine("After sorting");
            
            a.Sort();
            foreach(String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();

            ArrayList b = new ArrayList();
            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);
            }
            Assert.AreEqual(a, b);



        }
    }
}
