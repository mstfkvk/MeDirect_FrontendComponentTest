using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDirect_FrontendComponentTest.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private readonly IWebDriver driver;
        public CheckoutCompletePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private IWebElement ConfirmShoppingMessage => driver.FindElement(By.XPath("//h2"));
        private IWebElement BackHomeButton => driver.FindElement(By.Id("back-to-products"));

        public string GetConfirmingOrderMessage()
        {
            return ConfirmShoppingMessage.Text;
        }

        public void GoBackHome()
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView();", BackHomeButton);
            BackHomeButton.Click();
        }
    }
}
