using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MeDirect_FrontendComponentTest.Pages
{
    public abstract class BasePage
    {

        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement MenuButton => driver.FindElement(By.Id("react-burger-menu-btn"));
        protected IWebElement AllItemSubMenu => driver.FindElement(By.XPath("//nav[@class='bm-item-list']/a[1]"));
        protected IWebElement AboutSubMenu => driver.FindElement(By.XPath("//nav[@class='bm-item-list']/a[2]"));
        protected IWebElement LogoutSubMenu => driver.FindElement(By.XPath("//nav[@class='bm-item-list']/a[3]"));
        protected IWebElement ResetAppStateSubMenu => driver.FindElement(By.XPath("//nav[@class='bm-item-list']/a[4]"));
        protected IWebElement CloseMenuButton => driver.FindElement(By.Id("react-burger-cross-btn"));

        protected IWebElement OnlyChartButton => driver.FindElement(By.CssSelector("a.shopping_cart_link"));
        protected IWebElement CountedItemInChartButton => driver.FindElement(By.CssSelector("a.shopping_cart_link>span"));

        private IWebElement PageTitle => driver.FindElement(By.CssSelector(".title"));
        private IWebElement Error => driver.FindElement(By.TagName("h3"));
        private IWebElement ErrorCloseButton => driver.FindElement(By.XPath("//h3/button"));

        protected IWebElement TwitterButton => driver.FindElement(By.CssSelector(".social_twitter a"));
        protected IWebElement FacebookButton => driver.FindElement(By.CssSelector(".social_facebook a"));
        protected IWebElement LinkedinButton => driver.FindElement(By.CssSelector(".social_linkedin a"));

        public string GetPageTitle()
        {
            return PageTitle.GetAttribute("textContent");
        }

        public void GotoCart()
        {
            OnlyChartButton.Click();
        }

        public int GetCountedItemOnCart()
        {
            return Convert.ToInt32(CountedItemInChartButton.Text);
        }
        public void LogOut()
        {
            MenuButton.Click();
            WaitUntilClickable(LogoutSubMenu, 5);
            LogoutSubMenu.Click();
        }

        public void GiveUpToLogOut()
        {
            MenuButton.Click();
            WaitUntilClickable(LogoutSubMenu, 5);
            CloseMenuButton.Click();
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }
        public string GetErrorMessage()
        {
            return Error.GetAttribute("textContent");
        }
        /* wait until element is clickable 
         */
        public IWebElement WaitUntilClickable(IWebElement element, int second)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(second));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public void WaitUntilURL(int second)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(second));
            wait.Until(ExpectedConditions.UrlContains("www"));
        }
        public void ClickTwitter()
        {
            ScrollDown(TwitterButton);
            TwitterButton.SendKeys(Keys.Enter);
        }
        public void ClickFacebook()
        {
            ScrollDown(FacebookButton);
            FacebookButton.SendKeys(Keys.Enter);
        }
        public void ClickLinkedin()
        {
            ScrollDown(LinkedinButton);
            LinkedinButton.SendKeys(Keys.Enter);
        }
        public void ClickMenuButton()
        {
            MenuButton.Click();
        }
        public void ClickAboutSubMenuButton()
        {
            AboutSubMenu.Click();
        }
        public void ScrollDown(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", element);

        }

        /*
         * compares two elements, first sort then check them inside the for loop
         * */
        public bool isIncludeAllItem(List<string> items1, List<string> items2)
        {
            items1.Sort();
            items2.Sort();
            if (items1.Count != items2.Count) { return false; }
            for (int i = 0; i < items1.Count; i++)
            {
                if (items1[i] != items2[i])
                {
                    return false;
                }

            }

            return true;
        }

        /*
         * This method creates random number list with wanted length and between given data
         */
        public List<int> GenerateRandomNumbers(int count, int max)
        {
            if (count < 1 || count > max)
            {
                throw new ArgumentException("invalid parameters");
            }

            List<int> numbers = new List<int>();
            Random rand = new Random();

            while (numbers.Count < count)
            {
                int num = rand.Next(max);

                if (!numbers.Contains(num))
                {
                    numbers.Add(num);
                }
            }

            return numbers;
        }
        public string GetImageSrc(IWebElement element)
        {
            return element.GetAttribute("src");
        }
        public string GetImageName(IWebElement element)
        {
            return element.Text;//GetAttribute("textContent");
        }

        public string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }
    }
}
