using AmazonTestsSpecflow.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonTestsSpecflow.Pages
{
    class ShippingAddressPage : BasePage
    {
        private static ShippingAddressPage shippingAddressPage;
        public static ShippingAddressPage Instance => shippingAddressPage ?? (shippingAddressPage = new ShippingAddressPage());

        string CountryRegionDropdownListButton => "//div[@class=\"a-section a-spacing-base adddress-ui-widgets-form-field-container\"]//span[@class=\"a-button-text a-declarative\"]";
        string UkraineItemIntoCountryRegionDropdownList => "//a[contains(text(),\"Ukraine\")]";
        string FullNameInputField => "//input[@name=\"address-ui-widgets-enterAddressFullName\"]";
        string StreetAddressInputField => "//input[@name=\"address-ui-widgets-enterAddressLine1\"]";
        string CityInputField => "//input[@name=\"address-ui-widgets-enterAddressCity\"]";
        string ZipCodeInputField => "//input[@name=\"address-ui-widgets-enterAddressPostalCode\"]";
        string PhoneNumberInputField => "//input[@name=\"address-ui-widgets-enterAddressPhoneNumber\"]";
        string UseThisAddressButton => "//input[@class=\"a-button-input\"]";
        string AddNewAddressButton => "//span[@id=\"address-ui-widgets-form-submit-button\"]//input[@type=\"submit\"]";
        string AddAddressButton => "//a[@class=\"a-link-normal add-new-address-button\"]";
        string FullNameCardText => "//div[@class=\"a-section address-section-no-default\"]//span[@class=\"a-list-item\"]//h5[@id=\"address-ui-widgets-FullName\"]";
        string AddressCardText => "//div[@class=\"a-section address-section-no-default\"]//span[@class=\"a-list-item\"]//span[@id=\"address-ui-widgets-AddressLineOne\"]";
        string CityPostalCodeCardText => "//div[@class=\"a-section address-section-no-default\"]//span[@class=\"a-list-item\"]//span[@id=\"address-ui-widgets-CityStatePostalCode\"]";
        string CountryCardText => "//div[@class=\"a-section address-section-no-default\"]//span[@class=\"a-list-item\"]//span[@id=\"address-ui-widgets-Country\"]";
        string PhoneNumberCardText => "//div[@class=\"a-section address-section-no-default\"]//span[@class=\"a-list-item\"]//span[@id=\"address-ui-widgets-PhoneNumber\"]";
        string EmptyNameFieldError => "//div[contains(text(),\"Please enter a name.\")]";
        string EmptyStreetAddressFieldError => "//div[contains(text(),\"Please enter an address.\")]";
        string EmptyCityFieldError => "//div[@class=\"a-box a-alert-inline a-alert-inline-error\"]//div[contains(text(),\"Please enter a city name.\")]";
        string EmptyZipCodeError => "//div[@class=\"a-box a-alert-inline a-alert-inline-error\"]//div[contains(text(),\"Please enter a ZIP or postal code.\")]";
        string EmptyPhoneNumberFieldError => "//div[contains(text(),\"Please enter a phone number so we can call if there are any issues with delivery.\")]";
        string InvalidZipCodeFieldAlert => "//div[@class=\"a-box a-alert-inline a-alert-inline-warning\"]//div[contains(text(),\"Please enter a valid ZIP or postal code.\")]";
        string InvalidPhoneNumberError => "//div[contains(text(),\"Please provide a valid phone number\")]";
        string AlertIconsList => "//div[@class=\"a-box a-alert-inline a-alert-inline-error\"]//i[@class=\"a-icon a-icon-alert\"]";

        public void ClickAddAddressButton()
        {
            FindElement(By.XPath(AddAddressButton)).Click();
        }

        public void ClickAddNewAddressButton()
        {
            FindElement(By.XPath(AddNewAddressButton)).Click();
        }

        public void ClickCountryRegionDropdownListButton()
        {
            FindElement(By.XPath(CountryRegionDropdownListButton)).Click();
        }

        public void ClickUkraineItemIntoCountryRegionDropdownListButton()
        {
            FindElement(By.XPath(UkraineItemIntoCountryRegionDropdownList)).Click();
        }

        public void ClickUseThisAddressButton()
        {
            FindElement(By.XPath(UseThisAddressButton)).Click();
        }

        public void EnterFullName(string fullName)
        {
            FindElement(By.XPath(FullNameInputField)).SendKeys(fullName);
        }

        public void EnterStreetAddress(string streetAddress)
        {
            FindElement(By.XPath(StreetAddressInputField)).SendKeys(streetAddress);
        }

        public void EnterCity(string city)
        {
            FindElement(By.XPath(CityInputField)).SendKeys(city);
        }

        public void EnterZipCode(string zipCode)
        {
            FindElement(By.XPath(ZipCodeInputField)).SendKeys(zipCode);
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            FindElement(By.XPath(PhoneNumberInputField)).SendKeys(phoneNumber);
        }

        public bool IsNameAddedToAddressBookCorrectly(string name)
        {
            ICollection<IWebElement> names = FindElements(By.XPath(FullNameCardText));
            return names.Last().Text.Contains(name);
        }

        public bool IsAddressAddedToAddressBookCorrectly(string address)
        {
            ICollection<IWebElement> streets = FindElements(By.XPath(AddressCardText));
            return streets.Last().Text.Contains(address);
        }

        public bool IsCountryAddedToAddressBookCorrectly(string country)
        {
            ICollection<IWebElement> countries = FindElements(By.XPath(CountryCardText));
            return countries.Last().Text.Contains(country);
        }

        public bool IsPostalCodeAddedToAddressBookCorrectly(string postCode)
        {
            ICollection<IWebElement> postCodes = FindElements(By.XPath(CityPostalCodeCardText));
            return postCodes.Last().Text.Contains(postCode);
        }

        public bool IsPhoneNumberAddedToAddressBookCorrectly(string phoneNumber)
        {
            ICollection<IWebElement> phoneNumbers = FindElements(By.XPath(PhoneNumberCardText));
            return phoneNumbers.Last().Text.Contains(phoneNumber);
        }

        public bool IsCityAddedToAddressBookCorrectly(string city)
        {
            ICollection<IWebElement> cities = FindElements(By.XPath(CityPostalCodeCardText));
            return cities.Last().Text.Contains(city);
        }

        public bool IsAnyAlertVisible()
        {
            foreach (IWebElement webElement in FindElements(By.XPath(AlertIconsList)))
                if (webElement.Displayed)
                    return true;
            return false;
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            foreach (char symbol in phoneNumber)
            {
                if (!char.IsDigit(symbol))
                    return false;
            }
            return true;
        }

        public bool IsProperlyErrorIsShown(string name, string street, string city, string zipCode, string phoneNumber)
        {
            if (name.Length<1) return IsDisplayed(By.XPath(EmptyNameFieldError));
            else if (street.Length < 1) return IsDisplayed(By.XPath(EmptyStreetAddressFieldError));
            else if (city.Length < 1) return IsDisplayed(By.XPath(EmptyCityFieldError));
            else if (zipCode.Length < 1) return IsDisplayed(By.XPath(EmptyZipCodeError));
            else if (phoneNumber.Length < 1) return IsDisplayed(By.XPath(EmptyPhoneNumberFieldError));
            else if (!IsPhoneNumberValid(phoneNumber)) return IsDisplayed(By.XPath(InvalidPhoneNumberError));
            else return false;
        }


        public void WaitForNameInputFieldToBeClear(TimeSpan timeout)
        {
            WaitForInputFieldCleaner(DriverManager.Instance(), timeout, By.XPath(FullNameInputField), "value", string.Empty);
        }
    }
}
