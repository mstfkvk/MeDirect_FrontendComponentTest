using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDirect_FrontendComponentTest.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly IWebDriver driver;
        public InventoryPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private List<IWebElement> ItemName => driver.FindElements(By.CssSelector("div.inventory_item_name")).ToList();
        private List<IWebElement> ItemPrice => driver.FindElements(By.CssSelector("div.inventory_item_price")).ToList();
        private List<IWebElement> ItemImage => driver.FindElements(By.CssSelector("div.inventory_item_img")).ToList();
        private List<IWebElement> AddToChartButton => driver.FindElements(By.CssSelector("div.inventory_item_price + button")).ToList();
        private List<IWebElement> RemoveButton => driver.FindElements(By.XPath("//button[.='Remove']")).ToList();

        private IWebElement FilterSelect => driver.FindElement(By.CssSelector(".product_sort_container"));
        private List<IWebElement> Options => driver.FindElements(By.TagName("option")).ToList();


        public void AddToChart(int number)
        {
            AddToChartButton[number].Click();
            //AddToChartButton[number].SendKeys(Keys.Enter);
        }
        public void RemoveFromChart(int number)
        {
            RemoveButton[number].Click();
        }

        public List<IWebElement> GetAllItem()
        {
            return ItemName;
        }
        public List<IWebElement> GetAllPrice()
        {
            return ItemPrice;
        }
        public List<IWebElement> GetAllImage()
        {
            return ItemImage;
        }
        public List<IWebElement> GetAllAddToChartButton()
        {
            return AddToChartButton;
        }
        public List<IWebElement> GetAllRemoveButton()
        {
            return RemoveButton;
        }

        public List<string> GetAllItemName()
        {
            List<string> result = new List<string>();

            foreach (var item in ItemName)
            {
                result.Add(item.Text);
            }
            return result;
        }
        public List<string> GetAllItemPrice()
        {
            List<string> result = new List<string>();

            foreach (var item in ItemPrice)
            {
                result.Add(item.Text);
            }
            return result;
        }

        public string GetItemName(int number)
        {
            return ItemName[number].Text;
        }

        public string GetItemPrice(int number)
        {
            return ItemPrice[number].Text;
        }

        public void ClickName(int number)
        {
            ItemName[number].Click();
        }

        public void ClickImage(int number)
        {
            ItemImage[number].Click();
        }

        public void ChooseFilter(string type, string value)
        {
            SelectElement select = new SelectElement(FilterSelect);

            // az , za , lohi , hilo

            if (type == "number")
            {
                if (value == "lohi")
                {
                    select.SelectByIndex(2);
                }
                else
                {
                    select.SelectByIndex(3);
                }
            }
            if (type == "alphabetical")
            {
                if (value == "az")
                {
                    select.SelectByIndex(0);
                }
                else
                {
                    select.SelectByIndex(1);
                }
            }
        }
        public List<String> PriceLoHi()
        {
            GetAllItemPrice().Sort();
            return GetAllItemPrice();
        }
        public List<String> PriceHiLo()
        {
            GetAllItemPrice().Sort();
            GetAllItemPrice().Reverse();
            return GetAllItemPrice();
        }
        public List<String> NameAZ()
        {
            GetAllItemName().Sort();
            return GetAllItemName();
        }
        public List<String> NameZA()
        {
            GetAllItemName().Sort();
            GetAllItemName().Reverse();
            return GetAllItemName();
        }

        public List<string> AddToChartItem(List<int> numbers)
        {
            List<string> addedItemName = new List<string>();
            foreach (var i in numbers)
            {
                AddToChart(i);
                addedItemName.Add(GetItemName(i));
            }
            return addedItemName;
        }
    }
}
