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
        private IWebElement webElement;
        private string beforeImgSrc;
        private string afterImgSrc;
        private string beforeImgName;
        private string afterImgName;

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

        [Given(@"user clicks (.*) button")]
        public void GivenUserClicksButton(string social)
        {
            if (social == "linkedin")
            {
                inventoryPage.ClickLinkedin();
            }
            else if (social == "facebook")
            {
                inventoryPage.ClickFacebook();
            }
            else if (social == "twitter")
            {
                inventoryPage.ClickTwitter();
            }
            inventoryPage.WaitUntilURL(10);

        }
        [Then(@"user goes (.*) website in a new tab")]
        public void ThenUserGoesWebsiteInANewTab(string social)
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            if (social == "linkedin")
            {
                Assert.That(driver.Url.Contains("linkedin"), $"{driver.Url}");
            }
            else if (social == "facebook")
            {
                Assert.That(driver.Url.Contains("facebook"), $"{driver.Url}");
            }
            else if (social == "twitter")
            {
                Assert.That(driver.Url.Contains("twitter"), $"{driver.Url}");
            }
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
                {
                    Assert.AreEqual(inventoryPage.GetAllItemPrice(), inventoryPage.PriceHiLo(), $"expected: {inventoryPage.GetAllItemPrice()}, actual:{inventoryPage.PriceHiLo()}");
                    Console.WriteLine($"expected: {inventoryPage.GetAllItemPrice()}, actual:{inventoryPage.PriceHiLo()}");
                }
                else
                {
                    Assert.AreEqual(inventoryPage.GetAllItemPrice(), inventoryPage.PriceLoHi(), $"expected: {inventoryPage.GetAllItemPrice()}, actual:{inventoryPage.PriceLoHi()}");
                    Console.WriteLine($"expected: {inventoryPage.GetAllItemPrice()}, actual:{inventoryPage.PriceLoHi()}");
                }
            }
            if (type == "alphabetical")
            {
                if (value == "za")
                {
                    Assert.AreEqual(inventoryPage.GetAllItemName(), inventoryPage.NameZA(), $"expected: {inventoryPage.GetAllItemName()}, actual:{inventoryPage.NameZA()}");
                    Console.WriteLine($"expected: {inventoryPage.GetAllItemName()}, actual:{inventoryPage.NameZA()}");
                }
                else
                {
                    Assert.AreEqual(inventoryPage.GetAllItemName(), inventoryPage.NameAZ(), $"expected: {inventoryPage.GetAllItemName()}, actual:{inventoryPage.NameAZ()}");
                    Console.WriteLine($"expected: {inventoryPage.GetAllItemName()}, actual:{inventoryPage.NameAZ()}");
                }

            }
        }



        [Given(@"user looks one image of item first enterance")]
        public void GivenUserLooksOneImageOfItemFirstEnterance()
        {
            beforeImgSrc = inventoryPage.GetImageOneSrcInInventory();
        }

        [Given(@"user clicks the image")]
        public void GivenUserClicksTheImage()
        {
            inventoryPage.ClickImgOne();
            afterImgSrc = inventoryItemPage.GetImageSrcInInventoryItem();
        }

        [Then(@"images should be different")]
        public void ThenImagesShouldBeDifferent()
        {
            Assert.AreNotEqual(beforeImgSrc, afterImgSrc);
        }

        [Then(@"user clicks go to products button")]
        public void ThenUserClicksGoToProductsButton()
        {
            inventoryItemPage.GoBackToProducts();
        }

        [Then(@"user clicks second item name")]
        public void ThenUserClicksSecondItemName()
        {
            beforeImgName = inventoryPage.GetImageTwoNameInInventory();
            inventoryPage.ClickImgTwo();
            afterImgName = inventoryItemPage.GetImageNameInInventoryItem();
        }

        [Then(@"user notices names are different")]
        public void ThenUserNoticesNamesAreDifferent()
        {
            Assert.AreNotEqual(beforeImgName, afterImgName);
        }

        [Given(@"user can click only specific number to add to cart")]
        public void GivenUserCanClickOnlySpecificNumberToAddToCart()
        {
            //1-2-5 item
            // so only be able to run with 0-1-4 indexes element
            // added 3 items
            List<IWebElement> webElements = inventoryPage.GetAllAddToChartButton();
            foreach (IWebElement webElement in webElements)
            {
                webElement.Click();
            }
        }

        [Given(@"user tries to remove one of specific number items")]
        public void GivenUserTriesToRemoveOneOfSpecificNumberItems()
        {
            inventoryPage.GetAllRemoveButton()[0].Click();
        }

        [Then(@"user can't remove")]
        public void ThenUserCantRemove()
        {
            Assert.AreEqual(inventoryPage.GetCountedItemOnCart(), 3);
        }

        [Then(@"user removes randomly one product in cart")]
        public void ThenUserRemovesRandomlyOneProductInCart()
        {
            cartPage.RemoveItem(cartPage.GenerateRandomNumbers(1, 3)[0]);
        }

        [Then(@"user clicks to checkout button")]
        public void ThenUserClicksToCheckoutButton()
        {
            cartPage.ClickCheckout();
        }

        [When(@"user writes its firstname")]
        public void WhenUserWritesItsFirstname()
        {
            checkoutStepOnePage.EnterFirstName("meDirect");
        }

        [Then(@"user should see in the firstname textarea")]
        public void ThenUserShouldSeeInTheFirstnameTextarea()
        {
            string text = checkoutStepOnePage.GetFirstNameText();
            Assert.AreEqual(text, "meDirect");
        }

        [When(@"user writes its lastname")]
        public void WhenUserWritesItsLastname()
        {
            checkoutStepOnePage.EnterLastName("mustafa kavak");
        }

        [When(@"user sees the only one letter of the lastname in the firstname textarea")]
        public void WhenUserSeesTheOnlyOneLetterOfTheLastnameInTheFirstnameTextarea()
        {
            string textFirstName = checkoutStepOnePage.GetFirstNameText();
            string textLastName = checkoutStepOnePage.GetLastNameText();
            Assert.AreEqual(textLastName, "");
            Assert.AreEqual("" + textFirstName[textFirstName.Length - 1], "k");
        }

        [When(@"user clicks continue button")]
        public void WhenUserClicksContinueButton()
        {
            checkoutStepOnePage.ClickContinue();
        }

        [Then(@"user can't see any filtering (.*) and (.*)")]
        public void ThenUserCantSeeAnyFiltering(string type, string value)
        {

            Assert.IsTrue(inventoryPage.GetImageOneSrcInInventory()
                .Equals("https://www.saucedemo.com/static/media/sl-404.168b1cce.jpg"));
        }

        [When(@"user clicks menu button")]
        public void WhenUserClicksMenuButton()
        {
            inventoryPage.ClickMenuButton();
        }

        [When(@"user clicks about button")]
        public void WhenUserClicksAboutButton()
        {
            inventoryPage.ClickAboutSubMenuButton();
        }

        [Then(@"user gets ""([^""]*)"" page not found message")]
        public void ThenUserGetsPageNotFoundMessage(string errorCode)
        {
            Assert.IsTrue(driver.Url.Contains(errorCode));
        }

        /*[Then(@"user should get the (.*) on shopping")]
        public void ThenUserShouldGetTheOnShopping(string errorMessage)
        {
            throw new PendingStepException();
        }*/


    }

}