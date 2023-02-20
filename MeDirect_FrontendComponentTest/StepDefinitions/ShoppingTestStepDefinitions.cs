using MeDirect_FrontendComponentTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MeDirect_FrontendComponentTest.StepDefinitions
{
    [Binding]
    public class ShoppingTestStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly InventoryPage inventoryPage;
        private readonly InventoryItemPage inventoryItemPage;
        private readonly CartPage cartPage;
        private readonly CheckoutStepOnePage checkoutStepOnePage;
        private readonly CheckoutStepTwoPage checkoutStepTwoPage;
        private readonly CheckoutCompletePage checkoutCompletePage;
        private List<int> countList;
        private List<string> nameList;
        private List<string> afterFilter;

        public ShoppingTestStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            inventoryItemPage = new InventoryItemPage(driver);
            cartPage = new CartPage(driver);
            checkoutStepOnePage = new CheckoutStepOnePage(driver);
            checkoutStepTwoPage = new CheckoutStepTwoPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);
            countList = new List<int>();
            nameList = new List<string>();
            afterFilter = new List<string>();
        }
        [When(@"user logs in inventory page as ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserLogsInInventoryPageAsAnd(string username, string password)
        {
            loginPage.NavigateTo();
            loginPage.Login(username, password);
        }


        [Given(@"user chooses (.*) products randomly")]
        public void GivenUserChoosesProductsRandomly(int count)
        {
            countList = inventoryPage.GenerateRandomNumbers(count, inventoryPage.GetAllItem().Count);
        }

        [When(@"user clicks add to chart for added products")]
        public void WhenUserClicksAddToChartForAddedProducts()
        {
            nameList = inventoryPage.AddToChartItem(countList);
        }

        [Then(@"user should see changing number of the cart")]
        public void ThenUserShouldSeeChangingNumberOfTheCart()
        {
            Assert.AreEqual(inventoryPage.GetCountedItemOnCart(), countList.Count, $"Expected: {inventoryPage.GetCountedItemOnCart()}, Actual: {countList.Count}");
        }

        [Then(@"user goes to cart page")]
        public void ThenUserGoesToCartPage()
        {
            inventoryPage.GotoCart();
        }

        [Then(@"user should see the product which added")]
        public void ThenUserShouldSeeTheProductWhichAdded()
        {
            Assert.IsTrue(inventoryPage.isIncludeAllItem(nameList, cartPage.GetAllItemNameOnCart()));
        }

        [When(@"user comes back inventory page")]
        public void WhenUserComesBackInventoryPage()
        {
            cartPage.GoBackToProducts();
        }

        [When(@"user removes randomly one product in inventory page")]
        public void WhenUserRemovesRandomlyOneProductInInventoryPage()
        {
            int random = inventoryPage.GenerateRandomNumbers(1, inventoryPage.GetAllRemoveButton().Count)[0];
            inventoryPage.RemoveFromChart(random);
        }

        [When(@"user goes to cart page")]
        public void WhenUserGoesToCartPage()
        {
            inventoryPage.GotoCart();
        }

        [When(@"user removes randomly one product in cart")]
        public void WhenUserRemovesRandomlyOneProductInCart()
        {
            //cartPage.RemoveItem(new Random().Next(0, cartPage.GetAllItemNameOnCart().Count + 1));
            cartPage.RemoveItem(cartPage.GenerateRandomNumbers(1, cartPage.GetAllItemNameOnCart().Count)[0]);
        }

        [When(@"user clicks checkout button")]
        public void WhenUserClicksCheckoutButton()
        {
            cartPage.ClickCheckout();
        }


        [Then(@"user clicks continue button")]
        public void ThenUserClicksContinueButton()
        {
            checkoutStepOnePage.ClickContinue();
        }

        [When(@"user clicks finish button")]
        public void WhenUserClicksFinishButton()
        {
            checkoutStepTwoPage.ClickFinish();
        }

        [Then(@"user should get thanks message for order")]
        public void ThenUserShouldGetThanksMessageForOrder()
        {
            Assert.IsTrue(checkoutCompletePage.GetConfirmingOrderMessage().ToLower().Contains("thank"));
        }

        [Then(@"user clicks back home button")]
        public void ThenUserClicksBackHomeButton()
        {
            checkoutCompletePage.GoBackHome();
        }

        [Then(@"user logs out succesfully")]
        public void ThenUserLogsOutSuccesfully()
        {
            inventoryPage.LogOut();
        }

        [Given(@"user goes to cart page")]
        public void GivenUserGoesToCartPage()
        {
            inventoryPage.GotoCart();
        }

        [Given(@"user removes all items, if there is an item")]
        public void GivenUserRemovesAllItemsIfThereIsAnItem()
        {
            cartPage.RemoveAllItemsOnCart();
        }

        [Given(@"user clicks checkout button")]
        public void GivenUserClicksCheckoutButton()
        {
            cartPage.ClickCheckout();
        }

        [Given(@"user gives credentials with (.*), (.*) and (.*)")]
        public void GivenUserGivesCredentialsWithAnd(string fn, string ln, string pc)
        {
            checkoutStepOnePage.EnterCredentials(fn, ln, pc);
        }
        [Then(@"user gives credentials with ""([^""]*)"", ""([^""]*)"" and (.*)")]
        public void ThenUserGivesCredentialsWithAnd(string fn, string ln, string pc)
        {
            checkoutStepOnePage.EnterCredentials(fn, ln, pc);
        }


        [Given(@"user clicks continue button")]
        public void GivenUserClicksContinueButton()
        {
            checkoutStepOnePage.ClickContinue();
        }

        [When(@"user should get thanks message for order")]
        public void WhenUserShouldGetThanksMessageForOrder()
        {
            Assert.IsTrue(checkoutCompletePage.GetConfirmingOrderMessage().ToLower().Contains("thank"));
        }

        [When(@"user clicks back home button")]
        public void WhenUserClicksBackHomeButton()
        {
            checkoutCompletePage.GoBackHome();
        }

        [When(@"user gives up to logs out")]
        public void WhenUserGivesUpToLogsOut()
        {
            inventoryPage.GiveUpToLogOut();
        }

        [Then(@"user should not see ""([^""]*)"" title")]
        public void ThenUserShouldNotSeeTitle(string message)
        {
            Assert.AreEqual(message, checkoutStepTwoPage.GetPageTitle());
        }

        [Given(@"user clicks linkedin button")]
        public void GivenUserClicksLinkedinButton()
        {
            inventoryPage.ClickLinkedn();
        }

        [Given(@"user selects filter with (.*) and (.*)")]
        public void GivenUserSelectsFilterWithAnd(string type, string value)
        {

            inventoryPage.ChooseFilter(type, value);

        }
        [Then(@"user should see filtering (.*) and (.*)")]
        public void ThenUserShouldSeeFiltering(string type, string value)
        {
            if (type == "number")
            {
                if (value == "hilo")
                { Assert.AreEqual(inventoryPage.GetAllItemPrice(), inventoryPage.PriceHiLo()); }
                else
                { Assert.AreEqual(inventoryPage.GetAllItemPrice(), inventoryPage.PriceLoHi()); }
            }
            if (type == "alphabetical")
            {
                if (value == "za")
                { Assert.AreEqual(inventoryPage.GetAllItemName(), inventoryPage.NameZA()); }
                else
                { Assert.AreEqual(inventoryPage.GetAllItemName(), inventoryPage.NameAZ()); }

            }
        }



        [Given(@"user looks randomly one image of item first enterance")]
        public void GivenUserLooksRandomlyOneImageOfItemFirstEnterance()
        {
            throw new PendingStepException();
        }

        [Given(@"user clicks the image")]
        public void GivenUserClicksTheImage()
        {
            throw new PendingStepException();
        }

        [Then(@"images should be different")]
        public void ThenImagesShouldBeDifferent()
        {
            throw new PendingStepException();
        }

        [Then(@"user clicks go to products button")]
        public void ThenUserClicksGoToProductsButton()
        {
            throw new PendingStepException();
        }

        [Then(@"user clicks second item name")]
        public void ThenUserClicksSecondItemName()
        {
            throw new PendingStepException();
        }

        [Then(@"user notices names are different")]
        public void ThenUserNoticesNamesAreDifferent()
        {
            throw new PendingStepException();
        }

        [Given(@"user can click only (.*)(.*) to add to cart")]
        public void GivenUserCanClickOnlyToAddToCart(Decimal p0, int p1)
        {
            throw new PendingStepException();
        }

        [Given(@"user tries to remove one of (.*)(.*) items")]
        public void GivenUserTriesToRemoveOneOfItems(Decimal p0, int p1)
        {
            throw new PendingStepException();
        }

        [Then(@"user can't remove")]
        public void ThenUserCantRemove()
        {
            throw new PendingStepException();
        }

        [Then(@"user removes randomly one product in cart")]
        public void ThenUserRemovesRandomlyOneProductInCart()
        {
            throw new PendingStepException();
        }

        [Then(@"user clicks to checkout button")]
        public void ThenUserClicksToCheckoutButton()
        {
            throw new PendingStepException();
        }

        [When(@"user writes its firstname")]
        public void WhenUserWritesItsFirstname()
        {
            throw new PendingStepException();
        }

        [Then(@"user should see in the firstname textarea")]
        public void ThenUserShouldSeeInTheFirstnameTextarea()
        {
            throw new PendingStepException();
        }

        [When(@"user writes its lastname")]
        public void WhenUserWritesItsLastname()
        {
            throw new PendingStepException();
        }

        [When(@"user sees the only one letter of the lastname in the firstname textarea")]
        public void WhenUserSeesTheOnlyOneLetterOfTheLastnameInTheFirstnameTextarea()
        {
            throw new PendingStepException();
        }

        [When(@"user clicks continue button")]
        public void WhenUserClicksContinueButton()
        {
            throw new PendingStepException();
        }

        [Then(@"user can't see any filtering")]
        public void ThenUserCantSeeAnyFiltering()
        {
            throw new PendingStepException();
        }

        [When(@"user clicks menu button")]
        public void WhenUserClicksMenuButton()
        {
            throw new PendingStepException();
        }

        [When(@"user clicks about button")]
        public void WhenUserClicksAboutButton()
        {
            throw new PendingStepException();
        }

        [Then(@"user gets ""([^""]*)"" page not found message")]
        public void ThenUserGetsPageNotFoundMessage(string p0)
        {
            throw new PendingStepException();
        }

    }

}