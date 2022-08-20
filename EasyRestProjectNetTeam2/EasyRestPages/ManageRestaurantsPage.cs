using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageRestaurantsPage : BasePage
    {

        public ManageRestaurantComponent manageResturantComponent { get; private set; }
        public ManageRestaurantsPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'My Restaurants')]")]
        private IWebElement _myRestaurantsButton;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'details')]/ancestor::a")]
        private IWebElement _detailsButton;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'Watch Menu')]/ancestor::a")]
        private IWebElement _watchMenuButton;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label= 'More']")]
        private IWebElement _moreButton;

        [FindsBy(How = How.XPath, Using = "//a[@role='menuitem']")]
        private IWebElement _manageRestaurantButton;

        [FindsBy(How = How.XPath, Using = "//li[@role='menuitem']")]
        private IWebElement _archiveRestaurantButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='NOT APPROVED']")]
        private IWebElement _unarchivedStatus;

        [FindsBy(How = How.XPath, Using = "//span[text()='ARCHIVED']")]
        private IWebElement _archivedStatus;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label= 'Show more']")]
        private IWebElement _addRestaurantButton;

        [FindsBy(How = How.XPath, Using = "//p[text()='Restaurant was successfully created']")]
        private IWebElement _popuprestaurantAdded;

        public ManageRestaurantsPage ClickMyresturantsButton()
        {
            _myRestaurantsButton.Click();
            return this;
        }

        public ManageRestaurantsPage ClickMoreButton()
        {
            _moreButton.Click();
            return this;
        }

        public ManageRestaurantsPage WaitForManageAndArchiveButtons(int timeToWait)
        {
            WaitVisibilityOfElement(timeToWait, _manageRestaurantButton);
            return this;
        }

        public ManageRestaurantsPage ClickArchiveButton()
        {
            _archiveRestaurantButton.Click();
            return this;
        }

        public ManageRestaurantsPage WaitForArchiveStatus(int timeToWait)
        {
            WaitVisibilityOfElement(timeToWait, _archivedStatus);
            return this;
        }

        public ManageRestaurantsPage WaitForUnarchiveStatus(int timeToWait)
        {
            WaitVisibilityOfElement(timeToWait, _unarchivedStatus);
            return this;
        }

        public ManageRestaurantComponent ClickAddRestaurantButton()
        {
            _addRestaurantButton.Click();
            return new ManageRestaurantComponent(driver);
        }                              

        public void WaitAndClickManageButton(int timeToWait)
        {
            _manageRestaurantButton.WaitAndClick(driver, timeToWait);
        }

        public void WaitAndClickMoreButton(int timeToWait)
        {
            _moreButton.WaitAndClick(driver, timeToWait);
        }
    }
}

