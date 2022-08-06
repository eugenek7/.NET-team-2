using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class HeaderUsersListComponent: BasePage
    {
        public HeaderUsersListComponent(IWebDriver driver) : base(driver)
        {
            
        }
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'All')]")]
        private IWebElement _listAllUsersButton;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Active')]")]
        private IWebElement _listActiveUsersButton ;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Banned')]")]
        private IWebElement _listBannedUsersButton;
        
        public void ClickListAllUsersButton()
        {
            _listAllUsersButton.Click();
        }
        
        public void ClickListActiveUsersButton()
        {
            _listActiveUsersButton.Click();
        }
        
        public void ClickListBannedUsersButton()
        {
            _listBannedUsersButton.Click();
        }
    }
}