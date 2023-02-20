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
        private IWebElement Image => driver.FindElement(By.CssSelector(".inventory_details_img_container img"));
        private IWebElement ImageName => driver.FindElement(By.CssSelector(".inventory_details_name"));

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
        public string GetImageSrcInInventoryItem()
        {
            return GetImageSrc(Image);
        }
        public string GetImageNameInInventoryItem()
        {
            return GetImageName(ImageName);
        }
    }
}
