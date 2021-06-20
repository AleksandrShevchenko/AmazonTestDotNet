using OpenQA.Selenium;

namespace AmazonTestsSpecflow.Pages
{
    class WishlistPage : BasePage
    {
        private static WishlistPage wishlistPage;
        public static WishlistPage Instance => wishlistPage ?? (wishlistPage = new WishlistPage());

        string ItemIntoWishlist => "//h3[@class=\"a-size-base\"]/a[@class=\"a-link-normal\"]";
        string ListHeader => "//span[@id=\"profile-list-name\"]";
        string AddCommentQuantityAndPriorityButton => "//span[@class=\"a-declarative\"]/a[contains(text(),\"Add comment, quantity & priority\")]";
        string AddCommentQuantityAndPriorityPopup => "//div[@class=\"a-popover-wrapper\"]";
        string CommentInputField => "//textarea[@name=\"itemComment\"]";
        string CommentTextField => "//span[@class=\"g-comment-quote a-text-quote\"]/text()";
        string SaveButton => "//span[@id=\"WLNOTES_save-announce\"]";
        string PriorityDropdownList => "//div[@class=\"a-row\"]//span[@class=\"a-button-text a-declarative\"]";
        string LowPriorityDropdownListItem => "//div[@id=\"a-popover-7\"]//a[text() = \"low\"]";
        string LowestPriorityDropdownListItem => "//div[@id=\"a-popover-7\"]//a[contains(text(),\"lowest\")]";
        string MediumPriorityDropdownListItem => "//div[@id=\"a-popover-7\"]//a[contains(text(),\"medium\")]";
        string HighPriorityDropdownListItem => "//div[@id=\"a-popover-7\"]//a[text() = \"high\"]";
        string HighestPriorityDropdownListItem => "//div[@id=\"a-popover-7\"]//a[contains(text(),\"highest\")]";
        string PriorityRank => "//span[@class=\"a-size-small dropdown-priority item-priority-medium\"]";
        string WishListItem => "//div[contains(@class,\"g-span7when-wide\")]//a[contains(@title, \"QNAP\")]";

        public bool IsProductAddedToListProperly(string searchQuery)
        {
            return FindElement(By.XPath(ItemIntoWishlist)).Text.Contains(searchQuery);
        }





    }
}
