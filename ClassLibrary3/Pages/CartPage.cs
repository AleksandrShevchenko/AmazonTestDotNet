using AmazonTestsSpecflow.Base;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace AmazonTestsSpecflow.Pages
{
    class CartPage : BasePage
    {
        private static CartPage cartPage;
        public static CartPage Instance => cartPage ?? (cartPage = new CartPage());

        string ProductsInCart =>"//ul[@class=\"a-unordered-list a-nostyle a-vertical a-spacing-mini sc-info-block\"]";
        string QuantityButton => "//span[@class=\"a-button a-button-dropdown quantity\"]";
        string MoreThanTenButton => "//a[contains(text(), '10+')]";
        string QuantityInputField => "//input[@name=\"quantityBox\"]";
        string UpdateButton => "//span[@class=\"a-button a-button-primary a-button-small sc-update-link\"]";
        string TotalPrice => "//div[contains(@class,\"sc-subtotal-buybox\")]//span[contains(text(),\"$\")]";
        string PriceOfOneProduct => "//span[@class=\"a-size-medium a-color-base sc-price sc-white-space-nowrap sc-product-price a-text-bold\"]";
        string QuantityAlertMessage => "//span[contains(text(),\"This seller has only\")]";
        string DeleteButton => "//input[@value=\"Delete\"]";
        string EmptyCartMessage => "//*[contains(text(),\"Your Amazon Cart is empty\")]";
        string FilledQuantityInputField => "//input[@class=\"a-input-text a-width-small sc-quantity-textfield sc-update-quantity-input\"]";
        string QuantityBetweenOneAndNineButton => "//span[@class=\"a-dropdown-prompt\"]";

        public int GetAmountOfProductsInCart() => FindElements(By.XPath(ProductsInCart)).Count();

        public void EnterQuantityOfProducts(string quantity)
        {
            FindElement(By.XPath(QuantityInputField)).SendKeys(quantity);
        }

        public void ClickMoreThenTenDropdownListButton()
        {
            FindElement(By.XPath(MoreThanTenButton)).Click();
        }

        public void ClickUpdateButton()
        {
            FindElement(By.XPath(UpdateButton)).Click();
        }

        public void ClickQuantityButton()
        {
            FindElement(By.XPath(QuantityButton)).Click();
        }

        public void ClickDeleteButton()
        {
            try
            {
                FindElement(By.XPath(DeleteButton)).Click();
            }
            catch (Exception) { }
        }

        public bool IsTotalPriceChangedAccordinglyToQuantityOfProducts(int quantity)
        {
            string priceAsText = "";
            IWebElement priceOfOneProduct = FindElement(By.XPath(PriceOfOneProduct));
            for (int i = 0; i < priceOfOneProduct.Text.Length; i++)
            {
                if (char.IsDigit(priceOfOneProduct.Text.ToCharArray()[i]))
                {
                    priceAsText += priceOfOneProduct.Text.ToCharArray()[i];
                }
            }
            string totPrice = "";
            IWebElement totalPrice = FindElement(By.XPath(TotalPrice));
            for (int i = 0; i < totalPrice.Text.ToCharArray().Length; i++)
            {
                if (char.IsDigit(totalPrice.Text.ToCharArray()[i]))
                {
                    totPrice += totalPrice.Text.ToCharArray()[i];
                }
            }

            if (quantity < -9 || quantity > 9)
                return int.Parse(totPrice) == int.Parse(priceAsText) * int.Parse(FindElement(By.XPath(FilledQuantityInputField)).GetAttribute("value"));
            else
                return int.Parse(totPrice) == int.Parse(priceAsText) * int.Parse(FindElement(By.XPath(QuantityBetweenOneAndNineButton)).Text);
        }


        public bool IsEmptyCartMessageIsVisible()
        {
            return IsDisplayed(By.XPath(EmptyCartMessage));
        }

        public void WaitForVisibilityofQuantityInputFiled(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(FilledQuantityInputField));
        }

        public void WaitForVisibilityofQuantityBetweenOneAndNine(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(QuantityBetweenOneAndNineButton));
        }
    }
}
