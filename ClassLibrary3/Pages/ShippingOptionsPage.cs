using AmazonTestsSpecflow.Base;
using OpenQA.Selenium;

namespace AmazonTestsSpecflow.Pages
{
    class ShippingOptionsPage : BasePage
    {
        private static ShippingOptionsPage shippingOptionsPage;
        public static ShippingOptionsPage Instance => shippingOptionsPage ?? (shippingOptionsPage = new ShippingOptionsPage());
        string ContinueButton => "//div[@class=\"a-row\"]//input[@class=\"a-button-text\"]";
        string AddCreditCardButton => "//span[contains(text(),\"Add a credit or debit card\")]";
        string LearnMoreAboutAmazonStoreCardLink => "//a[contains(text(),\"Learn more\")][contains(@href,\"cobrandcard\")]";
        string EnterAGiftCardVoucherOrPromotionalCodeLink => "//span[contains(text(),\"Enter a gift card, voucher or promotional code\")]";
        string AddAPersonalCheckingAccountButton => "//span[contains(text(),\"Add a personal checking account\")]";
        string EmptyNameFieldErrorMessage => "//div[contains(text(), \"Please enter a name\")]";
        string EmptyStreetAddressFieldErrorMessage => "//div[contains(text(), \"Please enter an address\")]";
        string EmptyCityFieldErrorMessage => "//div[@class=\"a-box a-alert-inline a-alert-inline-error\"]//div[contains(text(), \"Please enter a city name\")]";
        string EmptyZipCodeFieldErrorMessage => "//div[contains(text(), \"Please enter a ZIP\")]";
        string EmptyPhoneNumberFieldErrorMessage => "//div[contains(text(), \"Please enter a phone number\")]";
        string InvalidZipCodeErrorMessage => "//div[@class=\"a-box a-alert-inline a-alert-inline-warning\"]//div[contains(text(), \"Please enter a valid ZIP\")]";
        string InvalidPhoneNumberErrorMessage => "//div[contains(text(), \"valid phone number\")]";
        string PageHeader => "//h1[contains(text(),\"Select a payment method\")]";

        public void ClickContinueButton()
        {
            FindElement(By.XPath(ContinueButton)).Click();
        }

        public bool IsAddCreditCardButtonVisible()
        {
            return IsDisplayed(By.XPath(AddCreditCardButton));
        }

        public bool IsLearnMoreAboutAmazonStoreCardButtonVisible()
        {
            return IsDisplayed(By.XPath(LearnMoreAboutAmazonStoreCardLink));
        }

        public bool IsAddAPerconalCheckingAccountButtonBisible()
        {
            return IsDisplayed(By.XPath(AddAPersonalCheckingAccountButton));
        }

        public bool IsEnterAGiftVoucherOrPromotionalCodeButtonVisible()
        {
            return IsDisplayed(By.XPath(EnterAGiftCardVoucherOrPromotionalCodeLink));
        }
    }
}
