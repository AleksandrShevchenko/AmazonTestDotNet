using OpenQA.Selenium;

namespace AmazonTestsSpecflow.Pages
{
    class AuthorizationPage : BasePage
    {
        private static AuthorizationPage authorizationPage;
        public static AuthorizationPage Instance => authorizationPage ?? (authorizationPage = new AuthorizationPage());

        string EmailAndPhoneNumberInputField => "//input[@name=\"email\"]";
        string PasswordInputField => "//input[@name=\"password\"]";
        string AnotherPasswordErrorSecurityWarning => "//h4[@class=\"a-alert-heading\"]";
        string ConfirmationButton => "//input[@class=\"a-button-input\"]";
        string InvalidEmailOrPhoneNumberError => "//div[@id=\"auth-error-message-box\"]";
        string EmptyPasswordError => "//div[contains(text(),\"Enter your password\")]";
        string EmptyEmailAndPhoneNumberInputFieldError => "//div[contains(text(),\"Enter your email or mobile phone number\")]";
        string AddAccountToSwitchButton => "//div[@class=\"a-column a-span12 a-text-left\"][contains(text(),\"Add\")]";
        string InvalidPhoneNumberError => "//div[@class=\"a-box-inner a-alert-container\"]//span[contains(text(),\"mobile number\")]";
        string InvalidPasswordError => "//div[@class=\"a-box-inner a-alert-container\"]//span[contains(text(),\"Your password is incorrect\")]";
        public By GetAddAccountToSwitchButton() { return By.XPath(AddAccountToSwitchButton); }
        public bool IsPasswordInputNameVisible()
        {
            return IsDisplayed(By.XPath(PasswordInputField));
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool IsLoginErrorVisibleAndCorrect(string login)
        {
            if (!IsValidEmail(login))
                return IsDisplayed(By.XPath(EmptyEmailAndPhoneNumberInputFieldError)) || IsDisplayed(By.XPath(InvalidEmailOrPhoneNumberError));
            else return true;
        }

        public bool IsPasswordErrorVisible(string password)
        {
            if (FindElement(By.XPath(EmptyPasswordError)).Displayed)
                return FindElement(By.XPath(EmptyPasswordError)).Displayed;
            else if (FindElement(By.XPath(AnotherPasswordErrorSecurityWarning)).Displayed)
                return FindElement(By.XPath(AnotherPasswordErrorSecurityWarning)).Displayed;
            else
                return FindElement(By.XPath(InvalidPasswordError)).Displayed;
        }

        public void EnterLogin(string login)
        {
            FindElement(By.XPath(EmailAndPhoneNumberInputField)).SendKeys(login);
        }

        public void EnterPassword(string password)
        {
                FindElement(By.XPath(PasswordInputField)).SendKeys(password);
        }

        public void ClickConfirmationButton()
        {
            FindElement(By.XPath(ConfirmationButton)).Click();
        }

        public void ClickAddAccountButton()
        {
            FindElement(By.XPath(AddAccountToSwitchButton)).Click();
        }
    }
}
