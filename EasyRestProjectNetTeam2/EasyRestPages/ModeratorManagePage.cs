//moderator panel 
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ModeratorManagePage : BasePage
    {
        public ModeratorManagePage(IWebDriver driver) : base(driver)
        {
            
        }
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Restaurants']")]
        private IWebElement _restaurantsButton;
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Users']")]
        private IWebElement _usersButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Owners']")]
        private IWebElement _ownersButton;
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'All')]")]
        private IWebElement _allButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Active')]")]
        private IWebElement _activeButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Banned')]")]
        private IWebElement _bannedButton;
        
        [FindsBy(How = How.XPath, Using = "(//span[contains(text(), 'Unapproved')])[1]")]
        private IWebElement _unapprovedRestaurantsButton;

        [FindsBy(How = How.XPath, Using = "(//span[contains(text(), 'Approved')])[1]")]
        private IWebElement _approvedRestaurantsButton;

        [FindsBy(How = How.XPath, Using = "(//span[contains(text(), 'Archived')])[1]")]
        private IWebElement _archivedRestaurantsButton;
        
        [FindsBy(How = How.XPath, Using = "(//span[contains(@class, 'MuiIconButton')])[2]")]
        private IWebElement _banOrActivateIcon;
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Disapprove']")]
        private IWebElement _disapproveRestaurantButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Approve']")]
        private IWebElement _approveRestaurantButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Restore']")]
        private IWebElement _restoreRestaurantButton;
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Delete']")]
        private IWebElement _deleteRestaurantButton;
        //span[text()='Undo']
        [FindsBy(How = How.XPath, Using = "//span[text()='Undo']")]
        private IWebElement _undoActionPopUpButton;
        
        public void ClickAllButton()
        {
            _allButton.Click();
        }

        public void ClickActiveButton()
        {
            _activeButton.Click();
        }

        public void ClickBannedButton()
        {
            _bannedButton.Click();
        }

        public void ClickRestaurantsButton()
        {
            _restaurantsButton.Click();
        }

        public void ClickUsersButton()
        {
            _usersButton.Click();
        }

        public void ClickOwnersButton()
        {
            _ownersButton.Click();
        }

        public void ClickArchivedRestaurantsButton()
        {
            _archivedRestaurantsButton.Click();
        }
        
        public void ClickApprovedRestaurantsButton()
        {
            _approvedRestaurantsButton.Click();
        }
        public void ClickUnapprovedRestaurantsButton()
        {
            _unapprovedRestaurantsButton.Click();
        }

        public void ClickDeleteRestaurantButton()
        {
            _deleteRestaurantButton.Click();
        }
        
        public void ClickDisapproveRestaurantButton()
        {
            _disapproveRestaurantButton.Click();
        }
        
        public void ClickApproveRestaurantButton()
        {
            _approveRestaurantButton.Click();
        }

        public void ClickRestoreRestaurantButton()
        {
            _restoreRestaurantButton.Click();
        }

        public void ClickUndoActionPopUpButton()
        {
            _undoActionPopUpButton.Click();
        }




    }
}