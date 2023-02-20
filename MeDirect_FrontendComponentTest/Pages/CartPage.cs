using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDirect_FrontendComponentTest.Pages
{
    public class CartPage : BasePage
    {

        private readonly IWebDriver driver;
        public CartPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private IWebElement ContinueShoppingButton => driver.FindElement(By.Id("continue-shopping"));
        private IWebElement CheckoutButton => driver.FindElement(By.Id("checkout"));
        private List<IWebElement> ItemNameOnCart => driver.FindElements(By.CssSelector(".inventory_item_name")).ToList();
        private List<IWebElement> RemoveButton => driver.FindElements(By.XPath("//button[.='Remove']")).ToList();

        public void RemoveItem(int number)
        {
            RemoveButton[number].Click();
        }
        public void GoBackToProducts()
        {
            ContinueShoppingButton.Click();
        }
        public void ClickCheckout()
        {
            CheckoutButton.Click();
        }

        public List<string> GetAllItemNameOnCart()
        {
            List<string> result = new List<string>();

            foreach (var item in ItemNameOnCart)
            {
                result.Add(item.Text);
            }
            return result;
        }

        public void RemoveAllItemsOnCart()
        {
            if (GetAllItemNameOnCart().Count != 0)
            {
                for (int i = 0; i < GetAllItemNameOnCart().Count; i++)
                {
                    RemoveItem(i);
                }
            }
        }
    }
}
