using OpenQA.Selenium;

namespace AmazonTestsSpecflow.Pages
{
    class PrimeVideoPage : BasePage
    {
        private static PrimeVideoPage primeVideoPage;
        public static PrimeVideoPage Instance => primeVideoPage ?? (primeVideoPage = new PrimeVideoPage());

        string TheBoysSeriesFirstSeasonPanel => "//span[text()=\"The Boys - Season 1\"]";
        string ServiceAreaRestrictionPopup => "//div[contains(text(),\"Service Area Restriction\")]";
        string WatchTheTrailerButton => "//a[contains(@href,\"ref=atv_dp_watch_trailer_tv\")]";

        public void ClickBoysSeriesFirstSeasonPanel()
        {
            FindElement(By.XPath(TheBoysSeriesFirstSeasonPanel)).Click();
        }

        public void ClickWatchTheTrailerButton()
        {
            FindElement(By.XPath(WatchTheTrailerButton)).Click();
        }

        public bool IsServiceAreaRestrictionPopupVisible()
        {
            return IsDisplayed(By.XPath(ServiceAreaRestrictionPopup));
        }
    }
}
