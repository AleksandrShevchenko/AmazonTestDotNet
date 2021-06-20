using AmazonTestsSpecflow.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AmazonTestsSpecflow.Pages
{
    public class BasePage
    {
        public BasePage()
        {

        }

        public void WaitForPageLoad(IWebDriver driver, TimeSpan timeout)
        {
            new WebDriverWait(driver, timeout)
                .Until(webDriver => ((IJavaScriptExecutor)webDriver)
                .ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForVisibilityOfElement(IWebDriver driver, TimeSpan timeout, By locator)
        {
            new WebDriverWait(driver, timeout).Until(x=>IsDisplayed(locator) == true) ;
        }

        public void WaitForInputFieldCleaner(IWebDriver driver, TimeSpan timeout, By locator, string attribute, string expectedValue)
        {
            new WebDriverWait(driver, timeout).Until(webDriver => FindElement(locator).GetAttribute(attribute) == expectedValue);
        }
        public void WaitForAjax (IWebDriver driver, TimeSpan timeout)
        {
            new WebDriverWait(driver, timeout)
                .Until(webDriver => ((IJavaScriptExecutor)webDriver)
                .ExecuteScript("return window.jQuery != undefined && jQuery.active == 0;"));
        }
        public IWebElement FindElement(By locator)
        {
            return DriverManager.Instance().FindElement(locator);
        }

        public ICollection<IWebElement> FindElements(By locator)
        {
            return DriverManager.Instance().FindElements(locator);
        }

        public bool IsDisplayed(By locator, int timeout = 30)
        {
            var wait = new WebDriverWait(DriverManager.Instance(), TimeSpan.FromSeconds(timeout));
            return wait.Until(d => DriverManager.Instance().FindElement(locator).Displayed);
        }
    string WarrantiesAndServicesMenuItem => "//a[contains(@href, \"warranties_and_services\")]";
    string SignInMenuButton => "//span[@class=\"nav-line-2 \"]";
    string CatalogueMenuButton => "//div[@class=\"nav-sprite\"]/div[@class=\"nav-left\"]";     
    string ComputersButton => "//div[text()=\"Computers\"]";     
    string DataStorageButton => "//a[contains(text(),\"Data Storage\")]";    
    string SearchInputField => "//input[@name=\"field-keywords\"]";       
    string SignInMenuButtonText => "//span[@class=\"nav-line-1 nav-progressive-content\"][contains(text(),\"Hello\")]";       
    string WatchlistButton => "//a[contains(@href, \"/gp/video/watchlist\")]";       
    string SwitchAccountsButton => "//span[contains(text(),\"Switch\")]";      
    string SearchButton => "//input[@id=\"nav-search-submit-button\"]";      
    string ShoppingListItem => "//div[@class=\"nav-panel\"]//span[@class=\"nav-text\"]";      
    string WishListItemInSignInMenu => "//span[@class=\"nav-text\"][text()=\"list1\"]";      
    string SignInMenuSignOutButton => "//span[contains(text(),\"Sign Out\")]";
    string GreetingsText => "//div[@class=\"nav-line-1-container\"]/span[@class=\"nav-line-1 nav-progressive-content\"]";      
    string ManageAddressBookButton => "//span[@data-action=\"GLUXManageAddressLinkAction\"]";     
    string LocationDeliverTuButton => "//a[@id=\"nav-global-location-popover-link\"]//span[@class=\"nav-line-1 nav-progressive-content\"]";

    public bool IsAccountNameEquals(string name)
        {
            return FindElement(By.XPath(GreetingsText)).Text.Contains(name);
        }

        public void ClickWarrantiesAndServicesMenuItem()
        {
            FindElement(By.XPath(WarrantiesAndServicesMenuItem)).Click();
        }

        public void CLickCatalogueMenuButton()
        {
            FindElement(By.XPath(CatalogueMenuButton)).Click();
        }

        public void ClickSignInButton()
        {
            FindElement(By.XPath(SignInMenuButton)).Click();
        }

        public void ClickComputersMenuItem()
        {
            FindElement(By.XPath(ComputersButton)).Click();
        }

        public void ClickDataStoragemenuItem()
        {
            FindElement(By.XPath(DataStorageButton)).Click();
        }

        public void ClickManageAddressBookButton()
        {
            FindElement(By.XPath(ManageAddressBookButton)).Click();
        }

        public void ClickDeliverToLocationButton()
        {
            FindElement(By.XPath(LocationDeliverTuButton)).Click();
        }

        public void ClickSwitchAccountButton()
        {
            FindElement(By.XPath(SwitchAccountsButton)).Click();
        }

        public void ClickWatchListButton()
        {
            FindElement(By.XPath(WatchlistButton)).Click();
        }

        public void ClickSearchButton()
        {
            FindElement(By.XPath(SearchButton)).Click();
        }

        public void EnterSearchQueryToSearchInputField(string searchQuery)
        {
            FindElement(By.XPath(SearchInputField)).SendKeys(searchQuery);
        }

        public void HoverSignInButton()
        {
            new Actions(DriverManager.Instance()).MoveToElement(FindElement(By.XPath(SignInMenuButton))).Perform();
        }

        public void WaitForVisibilityOfComputersMenuItem(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(ComputersButton));
        }

        public void WaitForVisibilityOfDataStorageMenuItem(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(DataStorageButton));
        }

        public void WaitForVisibilityOfManageAddressBookButton(TimeSpan timeout)
        {
            WaitForVisibilityOfElement(DriverManager.Instance(), timeout, By.XPath(ManageAddressBookButton));
        }

        public void WaitForSomeSeconds(TimeSpan timeoout)
        {
            Thread.Sleep(3000);
        }

    }
}
