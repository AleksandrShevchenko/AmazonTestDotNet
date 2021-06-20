using AmazonTestsSpecflow.Base;
using AmazonTestsSpecflow.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AmazonTestsSpecflow.Steps
{
    [Binding]
    public sealed class MainMenuSteps
    {
        TimeSpan defaultTimeout = TimeSpan.FromSeconds(10);
        private readonly ScenarioContext _scenarioContext;

        public MainMenuSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"User opens Amazon home page")]
        public void OpenAmazonHomePage()
        {
            HomePage.Instance.OpenAmazonHomePage();
        }

        [When(@"User clicks 'Sign in' button")]
        public void ClickSignInButton()
        {
            HomePage.Instance.ClickSignInButton();
        }

        [When(@"User logs in site as login: ""(.*)"" password: ""(.*)""")]
        public void LogInSiteAsLoginPassword(string login, string password)
        {
            AuthorizationPage.Instance.EnterLogin(login);
            AuthorizationPage.Instance.ClickConfirmationButton();
                AuthorizationPage.Instance.EnterPassword(password);
                AuthorizationPage.Instance.ClickConfirmationButton();
        }
        [When(@"User enter ""(.*)"" to 'Enter email or phone number' input field")]
        public void EnterLoginToEmailOrPhoneNumberInputField(string login)
        {
            AuthorizationPage.Instance.EnterLogin(login);
        }

        [When(@"User enter ""(.*)"" to 'Enter password' input field")]
        public void EnterToInputField(string password)
        {
            try
            {
                AuthorizationPage.Instance.EnterPassword(password);
            }
            catch (Exception) { }
        }

        [When(@"User clicks on 'Continue authorization' button")]
        public void ClickOnContinueAuthorizationButton()
        {
            try
            {
                AuthorizationPage.Instance.ClickConfirmationButton();
            }
            catch (Exception) { }
        }

        [Then(@"User checks that user is authorized as ""(.*)"" ""(.*)""")]
        public void CheckThatUserIsAuthorizedAs(string login, string password)
        {
            try
            {
                Assert.True(HomePage.Instance.IsAccountNameEquals(login), "AccounName");
            }
            catch (Exception)
            {
                try
                {
                    Assert.True(AuthorizationPage.Instance.IsLoginErrorVisibleAndCorrect(login), "loginError");
                }
                catch (Exception)
                {
                    Assert.True(AuthorizationPage.Instance.IsPasswordErrorVisible(password), "passwordError");
                }
            }
        }
        [Given(@"User clicks 'Sign in' button")]
        public void ClickOnSignInButton()
        {
            HomePage.Instance.ClickSignInButton();
        }

        [Given(@"User clicks on 'Login and security' button")]
        public void ClickOLoginAndSecuritynButton()
        {
            AccountPage.Instance.WaitForPageLoad(DriverManager.Instance(), defaultTimeout);
            AccountPage.Instance.ClickLoginAndSecurityButton();
        }
        [When(@"User clicks 'Login and security' button")]
        public void ClickLoginAndSecurityButton()
        {
            AccountPage.Instance.ClickLoginAndSecurityButton();
        }

        [When(@"User clicks on 'Edit password' button")]
        public void ClickOnEditPasswordButton()
        { 
            LoginAndSecurityPage.Instance.ClickEditPasswordButton();
        }

        [When(@"User enter ""(.*)"" as 'Current password'")]
        public void EnterAs(string currentPassword)
        {
            LoginAndSecurityPage.Instance.EnterCurrentPassword(currentPassword);
        }

        [When(@"User enter ""(.*)"" to 'New password' input field")]
        public void EnterNewPasswordToInputField(string newPassword)
        {
            LoginAndSecurityPage.Instance.EnterNewPassword(newPassword);
        }

        [When(@"User enter ""(.*)"" to 'Reenter new password' input field")]
        public void ReenterNewPasswordToInputField(string newPassword)
        {
            LoginAndSecurityPage.Instance.ReenterNewPassword(newPassword);
        }


        [When(@"User clicks on 'Save changes' button")]
        public void ClickOnSaveChangesButton()
        {
            LoginAndSecurityPage.Instance.ClickSaveChangesButton();
        }

        [Then(@"User checks that information box about password changing is ""(.*)""")]
        public void CheckThatInformationBoxAboutPasswordChangingIsShown(string password)
        {
            Assert.True(LoginAndSecurityPage.Instance.IsInformationBoxShown(password));
        }




        [When(@"User searches (.*) using search field")]
        public void SearcheUsingSearchField(string searchQuery)
        {
            HomePage.Instance.EnterSearchQueryToSearchInputField(searchQuery);
            HomePage.Instance.ClickSearchButton();
        }

        [When(@"User clicks on first product")]
        public void ClickOnFirstProduct()
        {
            ProductsPage.Instance.ClickFirstProductInList();
        }

        [When(@"User clicks on 'Add to cart' button")]
        public void ClickOnAddToCartButton()
        {
            ProductCardPage.Instance.ClickAddToCartButton();
        }

        [When(@"User clicks on 'Cart' button")]
        public void ClickOnCartButton()
        {
            ProductCardPage.Instance.ClickCartButton();
        }

        [When(@"User clicks on 'More then ten' dropdown list item")]
        public void ClickOnMoreThenTenDropdownListItem()
        {
            CartPage.Instance.ClickMoreThenTenDropdownListButton();
        }


        [Then(@"User checks amount of products into the cart")]
        public void CheckAmountOfProductsIntoTheCart()
        {
            Assert.AreEqual(1, (int)CartPage.Instance.GetAmountOfProductsInCart());
        }

        [When(@"User clicks on 'Quantity' button")]
        public void ClickOnQuantityButton()
        {
            CartPage.Instance.ClickQuantityButton();
        }

        [When(@"User enters ""(.*)"" to 'Quantity input field'")]
        public void EnterToQuantityInputField(string amountOfProducts)
        {
            CartPage.Instance.EnterQuantityOfProducts(amountOfProducts);
        }

        [When(@"User clicks 'Update' button")]
        public void ClickUpdateButton()
        {
            CartPage.Instance.ClickUpdateButton();
        }


        [Then(@"User checks that total price is changed accordingly to (.*) or existence of error")]
        public void CheckThatTotalPriceIsChangedAccordinglyToOrExistenceOfError(int quantity)
        {
            if (quantity != 0)
            {
                if (quantity > 9 || quantity < -9) 
                {
                    CartPage.Instance.WaitForVisibilityofQuantityInputFiled(defaultTimeout);
                } 
                else 
                {
                    CartPage.Instance.WaitForVisibilityofQuantityBetweenOneAndNine(defaultTimeout);
                }
                Assert.True(CartPage.Instance.IsTotalPriceChangedAccordinglyToQuantityOfProducts(quantity));
            }
        }

        [When(@"User clicks on 'Delete' button")]
        public void ClickOnButton()
        {
            try
            {
                CartPage.Instance.ClickDeleteButton();
            }
            catch (Exception) { }
        }

        [Then(@"User checks that cart is empty")]
        public void CheckThatCartIsEmpty()
        {
            Assert.True(CartPage.Instance.IsEmptyCartMessageIsVisible());
        }

        [When(@"User clicks on 'Buy now' button")]
        public void ClickBuyNowButton()
        {
            ProductCardPage.Instance.ClickBuyNowButton();
        }

        [When(@"User clicks on 'Country & Region' drop-down list button")]
        public void ClickOnDrop_DownListButton()
        {
            ShippingAddressPage.Instance.ClickCountryRegionDropdownListButton();
        }

        [When(@"User clicks on 'Ukraine' item into drop-down list")]
        public void ClickOnUkraineItemIntoDrop_DownList()
        {
            ShippingAddressPage.Instance.ClickUkraineItemIntoCountryRegionDropdownListButton();
        }

        [When(@"User enters his ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void EnterHisAnd(string name, string street, string city, string zipCode, string phoneNumber)
        {
            ShippingAddressPage.Instance.WaitForNameInputFieldToBeClear(defaultTimeout);
            ShippingAddressPage.Instance.EnterFullName(name);
            ShippingAddressPage.Instance.EnterStreetAddress(street);
            ShippingAddressPage.Instance.EnterZipCode(zipCode);
            ShippingAddressPage.Instance.EnterCity(city);
            ShippingAddressPage.Instance.EnterPhoneNumber(phoneNumber);
        }

        [When(@"User clicks 'Use this address' button")]
        public void ClickButton()
        {
            ShippingAddressPage.Instance.ClickUseThisAddressButton();
        }

        [When(@"User clicks on 'Continue' button")]
        public void ClickOnContinueButton()
        {
            try { ShippingOptionsPage.Instance.ClickContinueButton(); }
            catch (Exception) { }
        }

        [When(@"User checks that 'Add credit cart' button is visible")]
        public void CheckThatButtonIsVisible()
        {
            Assert.True(ShippingOptionsPage.Instance.IsAddCreditCardButtonVisible(), "add credit cart");
        }

        [When(@"User checks that 'Enter a gift card, voucher or promotional code' link is visible")]
        public void CheckThatLinkIsVisible()
        {
            Assert.True(ShippingOptionsPage.Instance.IsEnterAGiftVoucherOrPromotionalCodeButtonVisible(), "promo code");
        }

        [When(@"User checks that 'Learn more' link in the 'Amazon store card' block is visible")]
        public void CheckThatLinkInTheBlockIsVisible()
        {
            Assert.True(ShippingOptionsPage.Instance.IsLearnMoreAboutAmazonStoreCardButtonVisible(), "amazon store card");
        }

        [Then(@"User checks that 'Add a personal checking account' button is visible")]
        public void CheckThatAddAPersonalCheckingAccounButtonIsVisible()
        {
            Assert.True(ShippingOptionsPage.Instance.IsAddAPerconalCheckingAccountButtonBisible(), "personal checking account");
        }



        [When(@"User clicks on 'Add to list' button")]
        public void ClickOnAddToListButton()
        {
            ProductCardPage.Instance.ClickOnTheAddToListButton();
            ProductCardPage.Instance.WaitForVisibilityOfCreateNewListButton(defaultTimeout);
            ProductCardPage.Instance.ClickCreateNewListButton();
        }


        [When(@"User clicks on 'Create list' button")]
        public void ClickOnCreateListButton()
        {
            ProductCardPage.Instance.ClickCreateListButton();
        }


        [When(@"User clicks on 'View List' button")]
        public void ClickOnViewListButton()
        {
            ProductCardPage.Instance.WaitForVisibilityOfViewListButton(defaultTimeout);
            ProductCardPage.Instance.ClickViewListButton();
        }

        [When(@"User enters list name - ""(.*)""")]
        public void EnterListName_(string listName)
        {
            ProductCardPage.Instance.WaitForVisibilityOfListNameInputField(defaultTimeout);
            ProductCardPage.Instance.EnterTheListName(listName);
        }

        [Then(@"User checks that ""(.*)"" is added to wish list")]
        public void CheckThatIsAddedToWishList(string productName)
        {
            WishlistPage.Instance.WaitForPageLoad(DriverManager.Instance(), defaultTimeout);
            Assert.True(WishlistPage.Instance.IsProductAddedToListProperly(productName));
        }

        [Given(@"User clicks 'Catalogue' button")]
        public void ClickCatalogueButton()
        {
            HomePage.Instance.CLickCatalogueMenuButton();
        }

        [Given(@"User clicks 'Computer' menu item")]
        public void ClickComputerMenuItem()
        {
            HomePage.Instance.WaitForVisibilityOfComputersMenuItem(defaultTimeout);
            HomePage.Instance.ClickComputersMenuItem();
        }

        [Given(@"User clicks 'Data storage' menu item")]
        public void ClickDataStorageMenuItem()
        {
            HomePage.Instance.WaitForVisibilityOfDataStorageMenuItem(defaultTimeout);
            HomePage.Instance.ClickDataStoragemenuItem();
        }

        [When(@"User clicks 'External Hard Drives' button")]
        public void ClickExternalHardDrivesButton()
        {
            ProductsPage.Instance.WaitForPageLoad(DriverManager.Instance(), defaultTimeout);
            ProductsPage.Instance.ClickExternalHardDrivesFilter();
        }
        [When(@"User clicks '4 stars & up' button")]
        public void ClickMoreThenFourStarsRateButton()
        {
            ProductsPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, ProductsPage.Instance.GetAverageCustomerReviewMoreThanFourStarsFilterCheckbox());
            ProductsPage.Instance.ClickAverageCustomerReviewMoreThanFourStarsFilterCheckbox();
        }
        [When(@"User clicks 'Toshiba' button")]
        public void ClickToshibaButton()
        {
            ProductsPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, ProductsPage.Instance.GetToshibaBrandGilterCheckbox());
            ProductsPage.Instance.ClickToshibaBrandFilterCheckbox();
        }
        [When(@"User clicks 'Price from fifty to one hunded' button")]
        public void ClickFromFiftyToHundredDollarsPriceButton()
        {
            ProductsPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, ProductsPage.Instance.GetFromFiftyToHundredDollarsPriceFilterButton());
            ProductsPage.Instance.ClickFromFiftyToHundredDollarsPriceFilterButton();
        }
        [When(@"User clicks 'Portable' button")]
        public void ClickPortableButton()
        {
            ProductsPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, ProductsPage.Instance.GetPortableHardDriveTypeFilterCheckbox());
            ProductsPage.Instance.ClickPortableHardDriveTypeFilterCheckbox();
        }

        [When(@"User clicks 'PC' button for 'Platform support'")]
        public void ClickPcPlatformSupportFilterButton()
        {
            ProductsPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, ProductsPage.Instance.GetPcPlatformSupportFilterCheckbox());
            ProductsPage.Instance.ClickPCPlatformSupportFilterCheckbox();
        }

        [When(@"User clicks '4TB & Above' for 'Hard Drive Size' filter")]
        public void ClickForCapacityFilter()
        {
            ProductsPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, ProductsPage.Instance.GetHardDriveSizeMoreThan4TBFilterCheckbox());
            ProductsPage.Instance.ClickHardDriveSizeMoreThan4TBFilterCheckbox();
        }

        [When(@"User clicks 'Tablet' button as 'Compatible Devices'")]
        public void ClickTabletButtonAs()
        {
            ProductsPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, ProductsPage.Instance.GetTabletAsCompatibleDeviceFilterCheckbox());
            ProductsPage.Instance.ClickTabletAsCompatibleDeviceFilterCheckbox();
        }

        [When(@"User clicks on first 'Toshiba' product")]
        public void ClickOnFirstToshibaProduct()
        {
            ProductsPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, ProductsPage.Instance.GetFirstToshibaProduct());
            ProductsPage.Instance.ClickFirstToshibaHardDrive();
            ProductCardPage.Instance.WaitForPageLoad(DriverManager.Instance(), defaultTimeout);
        }

        [When(@"User checks that product is external hard drive")]
        public void CheckThatProductIsExternalHardDrive()
        {
            Assert.True(ProductCardPage.Instance.IsProductExternalHardDrive(), "external");
        }

        [When(@"User checks that product has rate '4 stars' or higher")]
        public void CheckThatProductHasRateOrHigher()
        {
            Assert.True(ProductCardPage.Instance.IsProductsRateUpperThenFour(), "rate");
        }

        [When(@"User checks that product is manufactured by '(.*)'")]
        public void CheckThatProductIsManufacturedBy(string brand)
        {
            Assert.True(ProductCardPage.Instance.IsProductManufacturedByCompany(brand), "brand");
        }

        [When(@"User checks that product's price is between fifty and one hundred dollars")]
        public void CheckThatProduct()
        {
            Assert.True(ProductCardPage.Instance.IsProductBetweenFiftyAndHundredDollars(), "price");
        }
        [When(@"User checks that product is portable")]
        public void CheckThatProductIsPortable()
        {
            Assert.True(ProductCardPage.Instance.IsProductPortable(), "portable");
        }

        [When(@"User checks that product supports ""(.*)"" platform")]
        public void CheckThatProductSupportsPlatform(string platform)
        {
            Assert.True(ProductCardPage.Instance.IsProductHardwarePlatformIs(platform), "PC");
        }

        [When(@"User checks that product's capacity is (.*)TB or above")]
        public void CheckProductsCapacity(int capacity)
        {
            Assert.True(ProductCardPage.Instance.IsProductCapacityMoreOrEquals(capacity));
        }

        [Then(@"User checks that product comparable with ""(.*)""")]
        public void CheckThatProductComparableWith(string device)
        {
            Assert.True(ProductCardPage.Instance.IsProductComparableWith(device));
        }

        [When(@"User clicks on 'Deliver to' button")]
        public void ClickOnDeliveryButton()
        {
            HomePage.Instance.ClickDeliverToLocationButton();
        }

        [When(@"User clicks on 'Manage address book' button")]
        public void ClickOnManageAddressBookButton()
        {
            HomePage.Instance.WaitForVisibilityOfManageAddressBookButton(defaultTimeout);
            HomePage.Instance.ClickManageAddressBookButton();
        }

        [When(@"User clicks on 'Add address' panel")]
        public void ClickOnAddAddressPanel()
        {
            ShippingAddressPage.Instance.ClickAddAddressButton();
        }

        [When(@"User clicks 'Add address' button")]
        public void ClickAddAddressButton()
        {
            ShippingAddressPage.Instance.ClickAddNewAddressButton();
        }

        [When(@"User checks that address is added to addressBook with ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void CheckThatAddressIsAddedToAddressBookWithAnd(string name, string street, string city, string zipCode, string phoneNumber)
        {
            if (ShippingAddressPage.Instance.IsAnyAlertVisible())
                Assert.True(ShippingAddressPage.Instance.IsProperlyErrorIsShown(name, street, city, zipCode, phoneNumber), "properlyerror");
            else
                ShippingAddressPage.Instance.WaitForPageLoad(DriverManager.Instance(), defaultTimeout);
        }

        [When(@"User checks that name ""(.*)"" was added to addressBook correctly")]
        public void CheckThatNameWasAddedToAddressBookCorrectly(string name)
        {
            if (!ShippingAddressPage.Instance.IsAnyAlertVisible())
                Assert.True(ShippingAddressPage.Instance.IsNameAddedToAddressBookCorrectly(name), "name");
        }

        [When(@"User checks that street ""(.*)"" was added to addressBook correctly")]
        public void CheckThatStreetWasAddedToAddressBookCorrectly(string street)
        {
            if (!ShippingAddressPage.Instance.IsAnyAlertVisible())
                Assert.True(ShippingAddressPage.Instance.IsAddressAddedToAddressBookCorrectly(street), "street");
        }

        [When(@"User checks that city ""(.*)"" was added to addressBook correctly")]
        public void CheckThatCityWasAddedToAddressBookCorrectly(string city)
        {
            if (!ShippingAddressPage.Instance.IsAnyAlertVisible())
                Assert.True(ShippingAddressPage.Instance.IsCityAddedToAddressBookCorrectly(city), "city");
        }

        [When(@"User checks that zipCode ""(.*)"" was added to addressBook correctly")]
        public void CheckThatZipCodeWasAddedToAddressBookCorrectly(string zipCode)
        {
            if (!ShippingAddressPage.Instance.IsAnyAlertVisible())
                Assert.True(ShippingAddressPage.Instance.IsPostalCodeAddedToAddressBookCorrectly(zipCode), "zipcode");
        }

        [When(@"User checks that phone number ""(.*)"" was added to addressBook correctly")]
        public void CheckThatPhoneNumberWasAddedToAddressBookCorrectly(string phoneNumber)
        {
            if (!ShippingAddressPage.Instance.IsAnyAlertVisible())
                Assert.True(ShippingAddressPage.Instance.IsPhoneNumberAddedToAddressBookCorrectly(phoneNumber), "phoneNumber");
        }

        [Then(@"User checks that country ""(.*)"" was added to addressBook correctly")]
        public void CheckThatCountryWasAddedToAddressBookCorrectly(string country)
        {
            if (!ShippingAddressPage.Instance.IsAnyAlertVisible())
                Assert.True(ShippingAddressPage.Instance.IsCountryAddedToAddressBookCorrectly(country), "country");
        }



        [When(@"User hovers on 'Sign In' button")]
        public void HoverOnSignInButton()
        {
            HomePage.Instance.HoverSignInButton();
        }

        [When(@"User clicks 'Switch accounts' button")]
        public void ClickSwitchAccountButton()
        {
            HomePage.Instance.ClickSwitchAccountButton();
        }

        [When(@"User clicks on 'Add account' button")]
        public void ClickAddAccountButton()
        {
            AuthorizationPage.Instance.WaitForVisibilityOfElement(DriverManager.Instance(), defaultTimeout, AuthorizationPage.Instance.GetAddAccountToSwitchButton());
            AuthorizationPage.Instance.ClickAddAccountButton();
        }

        [Then(@"User checks that account is switched to ""(.*)""")]
        public void CheckThatAccountIsSwitchedTo(string accountName)
        {
            Assert.True(HomePage.Instance.IsAccountNameEquals(accountName));
        }



        [When(@"User clicks 'Watchlist' button")]
        public void ClickWatchlistButton()
        {
            PrimeVideoPage.Instance.WaitForPageLoad(DriverManager.Instance(), defaultTimeout);
            PrimeVideoPage.Instance.ClickWatchListButton();
        }

        [When(@"User clicks 'The boys' series block")]
        public void ClickSeriesBlock()
        {
            PrimeVideoPage.Instance.ClickBoysSeriesFirstSeasonPanel();
        }

        [Then(@"User checks 'Service Area Restriction' popup visibility")]
        public void CheckPopupVisibility()
        {
            PrimeVideoPage.Instance.IsServiceAreaRestrictionPopupVisible();
        }

        [When(@"User clicks 'Watch Trailer' button")]
        public void ClickWatchTrailerButton()
        {
            PrimeVideoPage.Instance.ClickWatchTheTrailerButton();
        }

        [When(@"User clicks 'Sorting type' drop-down list button")]
        public void ClickDrop_DownListButton()
        {
            ProductsPage.Instance.ClickOnSortingDropDownListButton();
        }

        [When(@"User chooses ""(.*)"" and click this sorting type dropdown list item")]
        public void ChooseAndClickThisSortingTypeDropdownListItem(string sortingType)
        {
            if (sortingType == "asc")
                ProductsPage.Instance.ClickOnSortingFromLowToHighDropDownListItem();
            else if (sortingType == "desc")
                ProductsPage.Instance.ClickOnSortingFromHighToLowDropDownListItem();
        }

        [Then(@"User checks that products are sorted by ""(.*)""")]
        public void CheckThatProductsAreSortedBy(string sortingType)
        {
            if (sortingType.Contains("asc"))
                Assert.True(ProductsPage.Instance.IsSortingWorksProperly("asc"));
            else if (sortingType.Contains("desc"))
                Assert.True(ProductsPage.Instance.IsSortingWorksProperly("desc"));
        }

        [When(@"User waits for three seconds to make web-site sure that user is a real person")]
        public void WaitForThreeSecondsToMakeWeb_SiteSureThatUserIsARealPerson()
        {
            AuthorizationPage.Instance.WaitForSomeSeconds(defaultTimeout);
        }

    }
}
