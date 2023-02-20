using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDirect_FrontendComponentTest.Pages
{
    public class CheckoutStepOnePage : BasePage
    {
        private readonly IWebDriver driver;
        public CheckoutStepOnePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        private IWebElement ContinueButton=>driver.FindElement(By.Id("continue"));
        private IWebElement CancelButton => driver.FindElement(By.Id("cancel"));

        private IWebElement FirstNameText => driver.FindElement(By.Id("first-name"));
        private IWebElement LastNameText => driver.FindElement(By.Id("last-name"));
        private IWebElement PostalCodeText => driver.FindElement(By.Id("postal-code"));


        public void ClickContinue()
        {
            ContinueButton.Click();
        }
        public void ClickCancel()
        {
            CancelButton.Click();
        }
        public void EnterCredentials(string firstName, string lastName, string postalCode)
        {
            FirstNameText.SendKeys(firstName);
            LastNameText.SendKeys(lastName);
            PostalCodeText.SendKeys(postalCode);
        }
       
        public void EnterFirstName(string text)
        {
            FirstNameText.SendKeys(text);
        }
        public void EnterLastName(string text)
        {
            LastNameText.SendKeys(text);
        }
        public void EnterPostalCode(string text)
        {
            PostalCodeText.SendKeys(text);
        }

        public string GetFirstNameText()
        {
            return GetText(FirstNameText);  
        }
        public string GetLastNameText()
        {
            return GetText(LastNameText);
        }
        public string GetPostalCodeText()
        {
            return GetText(PostalCodeText);
        }

    }
}
