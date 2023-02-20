using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using System.Configuration;

namespace MeDirect_FrontendComponentTest.Pages
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;


        }

        private IWebElement UsernameInput => driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
       


        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void EnterCredentials(string username, string password)
        {
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void Clicks() { LoginButton.Click(); }

        public void Login(string username, string password)
        {
            EnterCredentials(username, password);
            Clicks();
        }

       
    }
}
