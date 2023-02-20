using BoDi;
using MeDirect_FrontendComponentTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MeDirect_FrontendComponentTest.StepDefinitions
{
    [Binding]
    public class LoginPageTestStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly InventoryPage inventoryPage;
        public LoginPageTestStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
        }

        [Given(@"User goes login page")]
        public void GivenUserGoesLoginPage()
        {
            loginPage.NavigateTo();
        }

        [Given(@"user enter credentials with (.*) and (.*)")]
        public void GivenUserEnterCredentialsWith(string username, string password)
        {
            loginPage.EnterCredentials(username, password);
        }


        [When(@"user clicks login button")]
        public void WhenUserClicksLoginButton()
        {
            loginPage.Clicks();
        }

        [Then(@"user is on the ""([^""]*)"" page")]
        public void ThenUserIsOnThePage(string pageTitle)
        {
            Console.WriteLine(loginPage.GetCurrentUrl());
            Assert.IsTrue(loginPage.GetCurrentUrl().Contains(pageTitle), $"Expected title: {loginPage.GetCurrentUrl()}, Actual title: {pageTitle}");
        }

        [Then(@"user should see ""([^""]*)"" title")]
        public void ThenUserShouldSeeTitle(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, inventoryPage.GetPageTitle(), $"Expected title: {expectedTitle}, Actual title: {inventoryPage.GetPageTitle()}");
        }



        [Then(@"user should get the (.*)")]
        public void ThenUserShouldGetTheSorryThisUserHasBeenLockedOut_(string errorMessage)
        {
            Assert.AreEqual(errorMessage, loginPage.GetErrorMessage());
        }
        
    }
}
