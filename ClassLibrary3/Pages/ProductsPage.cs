using OpenQA.Selenium;
using System;
using System.Linq;

namespace AmazonTestsSpecflow.Pages
{
    class ProductsPage : BasePage
    {
        private static ProductsPage productsPage;
        public static ProductsPage Instance => productsPage ?? (productsPage = new ProductsPage());

        string SortingDropDownListButton => "//span[@class=\"a-dropdown-prompt\"]";
        string SortingFromLowToHighDropDownListItem => "//a[contains(text(),\"Price: Low to High\")]";
        string SortingFromHighToLowDropDownListItem => "//a[contains(text(),\"Price: High to Low\")]";
        string SortingTypeAvgCustomerReview => "//a[contains(text(),\"Avg. Customer Review\")]";
        string PriceListWhole => "//span[@class=\"a-price-whole\"]";
        string PriceListFraction => "//span[@class=\"a-price-fraction\"]";
        string FirstToshibaHardDrive => "//div[@class=\"a-section aok-relative s-image-square-aspect\"]//img[contains(@alt,\"Toshiba\")]";
        string ProductsList => "//span[@class=\"a-size-medium a-color-base a-text-normal\"]";
        string ProductsBackupList => "//span[@class=\"a-size-base-plus a-color-base a-text-normal\"]";
        string ExternalHardDrivesFilterButton => "//ul[@class=\"a-unordered-list a-nostyle a-vertical a-spacing-medium\"]//span[contains(text(),'External Hard Drives')]";
        string PcPlatformSupportFilterCheckbox => "//span[contains(text(),\"PC\")][@class=\"a-size-base a-color-base\"]";
        string HardDriveSizeMoreThan4TBFilterCheckbox => "//span[contains(text(),\"4 TB & Above\")][@class=\"a-size-base a-color-base\"]";
        string TabletAsCompatibleDeviceFilterCheckbox => "//span[contains(text(),\"Tablet\")][@class=\"a-size-base a-color-base\"]";
        string AverageCustomerReviewMoreThanFourStarsFilterCheckbox => "//i[@class=\"a-icon a-icon-star-medium a-star-medium-4\"]";
        string ToshibaBrandFilterCheckbox => "//span[@class=\"a-size-base a-color-base\"][contains(text(),\"Toshiba\")]";
        string FromFiftyToHundredDollarsPriceFilterButton => "//span[@class=\"a-size-base a-color-base\"][contains(text(),\"$50 to $100\")]";
        string PortableHardDriveTypeFilterCheckbox => "//span[@class=\"a-size-base a-color-base\"][contains(text(),\"Portable\")]";
        public By GetToshibaBrandGilterCheckbox() { return By.XPath(ToshibaBrandFilterCheckbox); }
        public By GetFromFiftyToHundredDollarsPriceFilterButton() { return By.XPath(FromFiftyToHundredDollarsPriceFilterButton); }
        public By GetPortableHardDriveTypeFilterCheckbox() { return By.XPath(PortableHardDriveTypeFilterCheckbox); }
        public By GetAverageCustomerReviewMoreThanFourStarsFilterCheckbox() { return By.XPath(AverageCustomerReviewMoreThanFourStarsFilterCheckbox); }
        public By GetTabletAsCompatibleDeviceFilterCheckbox() { return By.XPath(TabletAsCompatibleDeviceFilterCheckbox); }
        public By GetHardDriveSizeMoreThan4TBFilterCheckbox() { return By.XPath(HardDriveSizeMoreThan4TBFilterCheckbox); }
        public By GetPcPlatformSupportFilterCheckbox() { return By.XPath(PcPlatformSupportFilterCheckbox); }
        public By GetFirstToshibaProduct() { return By.XPath(FirstToshibaHardDrive); }
        public void ClickPCPlatformSupportFilterCheckbox()
        {
            FindElement(By.XPath(PcPlatformSupportFilterCheckbox)).Click();
        }

        public void ClickHardDriveSizeMoreThan4TBFilterCheckbox()
        {
            FindElement(By.XPath(HardDriveSizeMoreThan4TBFilterCheckbox)).Click();
        }

        public void ClickOnSortingDropDownListButton()
        {
            FindElement(By.XPath(SortingDropDownListButton)).Click();
        }

        public void ClickOnSortingFromLowToHighDropDownListItem()
        {
            FindElement(By.XPath(SortingFromLowToHighDropDownListItem)).Click();
        }

        public void ClickOnSortingFromHighToLowDropDownListItem()
        {
            FindElement(By.XPath(SortingFromHighToLowDropDownListItem)).Click();
        }

        public void ClickFirstToshibaHardDrive()
        {
            FindElement(By.XPath(FirstToshibaHardDrive)).Click();
        }

        public void ClickExternalHardDrivesFilter()
        {
            FindElement(By.XPath(ExternalHardDrivesFilterButton)).Click();
        }

        public void ClickTabletAsCompatibleDeviceFilterCheckbox()
        {
            FindElement(By.XPath(TabletAsCompatibleDeviceFilterCheckbox)).Click();
        }

        public void ClickAverageCustomerReviewMoreThanFourStarsFilterCheckbox()
        {
            FindElement(By.XPath(AverageCustomerReviewMoreThanFourStarsFilterCheckbox)).Click();
        }

        public void ClickToshibaBrandFilterCheckbox()
        {
            FindElement(By.XPath(ToshibaBrandFilterCheckbox)).Click();
        }

        public void ClickFromFiftyToHundredDollarsPriceFilterButton()
        {
            FindElement(By.XPath(FromFiftyToHundredDollarsPriceFilterButton)).Click();
        }

        public void ClickPortableHardDriveTypeFilterCheckbox()
        {
            FindElement(By.XPath(PortableHardDriveTypeFilterCheckbox)).Click();
        }

        public void ClickFirstProductInList()
        {
            try
            {
                FindElements(By.XPath(ProductsList)).First().Click();
            }
            catch (Exception)
            {
                FindElements(By.XPath(ProductsBackupList)).First().Click();
            }
        }

        public bool IsSortingWorksProperly(string sortingType)
        {
            if (sortingType.Contains("asc"))
            {
                for (int i = 1; i < FindElements(By.XPath(PriceListWhole)).Count; i++)
                {
                    if (int.Parse(FindElements(By.XPath(PriceListWhole)).ElementAt(i).Text) < int.Parse(FindElements(By.XPath(PriceListWhole)).ElementAt(0).Text))
                        return false;
                    else if (int.Parse(FindElements(By.XPath(PriceListWhole)).ElementAt(i).Text) == int.Parse(FindElements(By.XPath(PriceListWhole)).ElementAt(0).Text))
                    {
                        if (int.Parse(FindElements(By.XPath(PriceListFraction)).ElementAt(i).Text) < int.Parse(FindElements(By.XPath(PriceListFraction)).ElementAt(i).Text))
                            return false;
                    }
                }
            }
            else if (sortingType.Contains("desc"))
            {
                for (int i = 1; i < FindElements(By.XPath(PriceListWhole)).Count; i++)
                {
                    if (int.Parse(FindElements(By.XPath(PriceListWhole)).ElementAt(i).Text) > int.Parse(FindElements(By.XPath(PriceListWhole)).ElementAt(0).Text))
                    {
                        return false;
                    }
                    else if (int.Parse(FindElements(By.XPath(PriceListWhole)).ElementAt(i).Text) == int.Parse(FindElements(By.XPath(PriceListWhole)).ElementAt(0).Text))
                    {
                        if (int.Parse(FindElements(By.XPath(PriceListFraction)).ElementAt(i).Text) > int.Parse(FindElements(By.XPath(PriceListFraction)).ElementAt(i).Text))
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
