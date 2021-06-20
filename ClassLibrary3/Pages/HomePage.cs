using AmazonTestsSpecflow.Base;

namespace AmazonTestsSpecflow.Pages
{
    class HomePage : BasePage
    {
        private string URL = "https://www.amazon.com/";

        private static HomePage homePage;
        public static HomePage Instance => homePage ?? (homePage = new HomePage());

        public void OpenAmazonHomePage()
        {
            DriverManager.Instance().Navigate().GoToUrl(URL);
        }
    }
}
