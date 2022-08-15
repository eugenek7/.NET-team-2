//moderator panel 
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using EasyRestProjectNetTeam2.Decorator;
using System.Collections.Generic;
using System.Linq;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ModeratorManagePage : BasePage
    {
        public HeaderUsersListComponent HeaderUsersListComponent { get; private set; }
        
        public ModeratorManagePage(IWebDriver driver) : base(driver)
        {
            
        }
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Restaurants']")]
        private IWebElement _restaurantsButton;
        
        [FindsBy(How = How.XPath, Using = "//span[text()='Users']")]
        private IWebElement _usersButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Owners']")]
        private IWebElement _ownersButton;
        
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

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'MuiCardHeader-title')]")]
        private IList<IWebElement> _listOfRestaurantsNames;

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

        public void WaitAndClickArchivedRestaurantsButton(int TimeToWait)
        {
            _archivedRestaurantsButton.WaitAndClick(driver, TimeToWait);
        }
        
        public void WaitAndClickApprovedRestaurantsButton(int TimeToWait)
        {
            _approvedRestaurantsButton.WaitAndClick(driver, TimeToWait);
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

        public void WaitAndClickUndoActionPopUpButton(int TimeToWait)
        {
            _undoActionPopUpButton.WaitAndClick(driver, TimeToWait);
            driver.Navigate().Refresh();
        }

        public string WaitAndGetTextFromApprovedRestaurantsButton(int TimeToWait)
        {
            return _approvedRestaurantsButton.WaitAndGetText(driver, TimeToWait);
        }

        public string WaitAndGetTextFromArchivedRestaurantsButton(int TimeToWait)
        {
            return _archivedRestaurantsButton.WaitAndGetText(driver, TimeToWait);
        }

        public string GetFirstRestaurantName()
        {
            return _listOfRestaurantsNames[0].Text;
        }

        public bool CheckRestaurantNameExist(string RestaurantName)
        {
            return _listOfRestaurantsNames.Any(RestaurantNameElement => RestaurantNameElement.Text.Equals(RestaurantName));
        }
    }
}
