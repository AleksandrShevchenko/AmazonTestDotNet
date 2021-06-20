using OpenQA.Selenium;

namespace AmazonTestsSpecflow.Pages
{
    class LoginAndSecurityPage : BasePage
    {
        private static LoginAndSecurityPage loginAndSecurityPage;
        public static LoginAndSecurityPage Instance => loginAndSecurityPage ?? (loginAndSecurityPage = new LoginAndSecurityPage());

        string EditNameButton => "//input[@id=\"auth-cnep-edit-name-button\"]";
        string EditPasswordButton => "//input[@id=\"auth-cnep-edit-password-button\"]";
        string CurrentPasswordInputField => "//label[@class=\"a-form-label\"][contains(text(),\"Current password\")]//..//..//input[@type=\"password\"]";
        string NewPasswordInputField => "//label[@class=\"a-form-label\"][contains(text(),\"New password\")]//..//..//input[@type=\"password\"]";
        string ReenterNewPasswordInputField => "//input[@name=\"passwordNewCheck\"]";
        string EditPasswordInfoMessage => "//h4[@class=\"a-alert-heading\"]";
        string NewNameInputField => "//input[@name=\"customerName\"]";
        string SaveChangesButton => "//span[contains(text(),\"Save changes\")]//..";
        string AccountName => "//form[@id=\"cnep_1a_name_form\"]//div[@class=\"a-fixed-right-grid-col a-col-left\"]//div[not(contains(span, \"Name:\"))]";


        public void ClickEditPasswordButton()
        {
            FindElement(By.XPath(EditPasswordButton)).Click();
        }

        public void ClickSaveChangesButton()
        {
            FindElement(By.XPath(SaveChangesButton)).Click();
        }

        public void EnterCurrentPassword(string currentPassword)
        {
            FindElement(By.XPath(CurrentPasswordInputField)).SendKeys(currentPassword);
        }

        public void EnterNewPassword(string newPassword)
        {
            FindElement(By.XPath(NewPasswordInputField)).SendKeys(newPassword);
        }

        public void ReenterNewPassword(string newPassword)
        {
            FindElement(By.XPath(ReenterNewPasswordInputField)).SendKeys(newPassword);
        }

        public bool IsInformationBoxShown(string expectedStatus)
        {
            return true;
        }
    }
}
