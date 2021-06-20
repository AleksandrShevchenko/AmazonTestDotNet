using AmazonTestsSpecflow.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AmazonTestsSpecflow.Pages
{
    class ProductCardPage : BasePage
    {
        private static ProductCardPage productCardPage;
        public static ProductCardPage Instance => productCardPage ?? (productCardPage = new ProductCardPage());
        string AddToCartButton => "//input[@name=\"submit.add-to-cart\"]";
        string BuyNowButton => "//input[@name=\"submit.buy-now\"]";
        string AddToListButton => "//span[@class=\"a-button a-button-dropdown a-button-group-last\"]//input[@name=\"submit.add-to-registry.wishlist\"][@type=\"submit\"]";
        string CreateNewListButton => "//a[@href=\"/hz/wishlist/create\"]";
        string ShippingDelaysPopup => "//div[@data-toaster-type=\"LOCATION_ALERT\"]";
        string CartButton => "//div[@id=\"huc-v2-subcart-buttons-wrapper\"]//a[contains(@href,\"/gp/cart/view.html/ref=lh_cart\")]";
        string AddToFirstListButton => "//input[@name=\"submit.add-to-registry.wishlist\"]";
        string ProductManufacturerBrandName => "//span[contains(text(),\"Brand\")]//..//..//span[@class=\"a-size-base\"]";
        string ProductCompatibleDevices => "//span[contains(text(),\"Compatible Devices\")]//..//..//span[@class=\"a-size-base\"]";

        string ProductPrice => "//div[@class=\"a-section a-spacing-micro\"]//span[@class=\"a-size-medium a-color-price\"]";
        string HardDriveInfo => "//th[contains(text(),\"Hard Drive\")]//..//td[@class=\"a-size-base prodDetAttrValue\"]";
        string HardDriveCapacity => "//label[contains(text(), \"Capacity:\")]/../span";
        string HardwarePlatform => "//th[contains(text(),\"Hardware Platform\")]//..//td[@class=\"a-size-base prodDetAttrValue\"]";
        string UserReviewRateStars => "//div[@class=\"centerColAlign centerColAlign-bbcxoverride\"]//i[contains(@class,\"a-icon-star\")]";
        string AmazonsChoiceProductSection => "//span[@class=\"ac-for-text\"]//span";
        string CreateNewListPopup => "//div[@class=\"a-popover a-popover-modal a-declarative\"]";
        string EmptyWishlistNameAlert => "//div[contains(text(), \"Please enter a name for the list.\")]";
        string ListNameInputField => "//input[@name=\"list-name\"]";
        string AddToYourListPopup => "//div[@class=\"a-popover a-popover-modal a-declarative  a-popover-modal-fixed-height pop-huc-create\"]";
        string CreateListButton => "//span[@data-action=\"create-list-submit\"]//input[@class=\"a-button-input a-declarative\"]";
        string ViewListButton => "//span[@class=\"a-button-inner\"]//a[contains(@href, \"/hz/wishlist\")]";
        string SideCartButton => "//input[@aria-labelledby=\"attach-sidesheet-view-cart-button-announce\"]";

        public void WaitForVisibilityOfViewListButton(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(ViewListButton));
        }
        public void WaitForVisibilityOfCartButton(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(CartButton));
        }

        public void WaitForVisibilityOfCreateNewListPopup(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(CreateNewListPopup));
        }

        public void WaitForVisibilityOfCreateNewListButton(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(CreateNewListButton));
        }

        public void WaitForVisibilityOfListNameInputField(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(ListNameInputField));
        }

        public void WaitForVisibilityOfSideCartButton(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(SideCartButton));
        }
        public void ClickBuyNowButton()
        {
            FindElement(By.XPath(BuyNowButton)).Click();
        }

        public void ClickAddToCartButton()
        {
            FindElement(By.XPath(AddToCartButton)).Click();
        }

        public void ClickCreateNewListButton()
        {
            FindElement(By.XPath(CreateNewListButton)).Click();
        }

        public void ClickOnTheAddToListButton()
        {
            FindElement(By.XPath(AddToListButton)).Click();
        }

        public void ClickCartButton()
        {
            try
            {
                WaitForVisibilityOfElement(DriverManager.Instance(), TimeSpan.FromSeconds(5), By.XPath(CartButton));
                FindElement(By.XPath(CartButton)).Click();
            }
            catch (Exception)
            {
                WaitForVisibilityOfElement(DriverManager.Instance(), TimeSpan.FromSeconds(5), By.XPath(SideCartButton));
                FindElement(By.XPath(SideCartButton)).Click();
            }

        }

        public void ClickAddToListButton()
        {
            FindElement(By.XPath(AddToFirstListButton)).Click();
        }

        public void ClickViewListButton()
        {
            FindElement(By.XPath(ViewListButton)).Click();
        }

        public void ClickCreateListButton()
        {
            FindElement(By.XPath(CreateListButton)).Click();
        }

        public bool IsProductHardwarePlatformIs(string platformName)
        {
            return FindElement(By.XPath(HardwarePlatform)).Text.Contains(platformName);
        }

        public bool IsEmptyWishlistNameAlertVisible()
        {
            return IsDisplayed(By.XPath(EmptyWishlistNameAlert));
        }

        public bool IsProductPortable()
        {
            return FindElement(By.XPath(HardDriveInfo)).Text.Contains("Portable");
        }

        public bool IsProductExternalHardDrive()
        {
            return FindElement(By.XPath(AmazonsChoiceProductSection)).Text.Contains("External Hard Drives");
        }

        public bool IsProductComparableWith(string deviceName)
        {
            return FindElement(By.XPath(ProductCompatibleDevices)).Text.Contains(deviceName);
        }

        public bool IsProductsRateUpperThenFour()
        {
            return FindElement(By.XPath(UserReviewRateStars)).GetAttribute("class").Contains("a-star-4-5");
        }

        public bool IsProductManufacturedByCompany(string company)
        {
            return FindElement(By.XPath(ProductManufacturerBrandName)).Text.Contains(company);
        }

        public bool IsProductCapacityMoreOrEquals(int capacity)
        {
            string capacityAsText = "";
            IWebElement hardDriveCapacity = FindElement(By.XPath(HardDriveCapacity));
            for (int i = 0; i < hardDriveCapacity.Text.Length; i++)
            {
                if (char.IsDigit(hardDriveCapacity.Text.ToCharArray()[i]))
                {
                    capacityAsText += hardDriveCapacity.Text.ToCharArray()[i];
                }
            }
            return int.Parse(capacityAsText) >= capacity;
        }

        public bool IsProductBetweenFiftyAndHundredDollars()
        {
            string priceAsText = "";
            IWebElement productPrice = FindElement(By.XPath(ProductPrice));
            for (int i = 0; i < productPrice.Text.Length; i++)
            {
                if (char.IsDigit(productPrice.Text.ToCharArray()[i]))
                {
                    priceAsText += productPrice.Text.ToCharArray()[i];
                }
            }
            int price = int.Parse(priceAsText.Substring(0, priceAsText.Length - 2));
            return price > 50 && price < 100;
        }

        public void EnterTheListName(string listName)
        {
            if (listName.Length>0)
            {
                FindElement(By.XPath(ListNameInputField)).Clear();
                FindElement(By.XPath(ListNameInputField)).SendKeys(listName);
            }
            else
            {
                Assert.True(IsEmptyWishlistNameAlertVisible());
            }
        }
    }
}
