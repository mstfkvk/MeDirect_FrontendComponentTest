using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDirect_FrontendComponentTest.Pages
{
    public class CheckoutStepTwoPage : BasePage
    {
        private readonly IWebDriver driver;
        public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        private IWebElement FinishButton => driver.FindElement(By.Id("finish"));
        private IWebElement CancelButton => driver.FindElement(By.Id("cancel"));

        public void ClickFinish()
        {
            FinishButton.Click();   
        }
        public void CancelFinish()
        {
            CancelButton.Click();
        }

    }
}
