using OpenQA.Selenium;

namespace AmazonTestsSpecflow.Pages
{
    class AccountPage : BasePage
    {
        private static AccountPage accountPage;
        public static AccountPage Instance => accountPage ?? (accountPage = new AccountPage());

        private string LoginAndSecurityButton => "//div[@data-card-identifier=\"SignInAndSecurity\"]";

        public void ClickLoginAndSecurityButton()
        {
            var subMenuItem = FindElement(By.XPath(LoginAndSecurityButton));
            subMenuItem.Click();
        }
    }
}
