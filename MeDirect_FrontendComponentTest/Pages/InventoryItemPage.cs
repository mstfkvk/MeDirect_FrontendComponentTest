using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDirect_FrontendComponentTest.Pages
{
    public class InventoryItemPage : BasePage
    {
        private readonly IWebDriver driver;
        public InventoryItemPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

        }

        private IWebElement BackToProductsButton => driver.FindElement(By.Id("back-to-products"));
        private IWebElement AddToChartButton => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement RemoveButton => driver.FindElement(By.XPath("//button[.='Remove']"));

        public void GoBackToProducts()
        {
            BackToProductsButton.Click();
        }
        public void AddToChart()
        {
            AddToChartButton.Click();
        }
        public void RemoveChart()
        {
            RemoveButton.Click();
        }
    }
}
