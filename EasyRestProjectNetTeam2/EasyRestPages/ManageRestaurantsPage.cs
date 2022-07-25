using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageRestaurantsPage : BasePage
    {
        public ManageRestaurantsPage(IWebDriver driver) : base(driver) { }

        private const int TimeToWait = 20;
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
        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        private IWebElement _inputRestaurantName;
        [FindsBy(How = How.XPath, Using = "//input[@name='address']")]
        private IWebElement _inputRestaurantAdress;
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement _createRestaurantButton;
        [FindsBy(How = How.XPath, Using = "//p[text()='Name is required']")]
        private IWebElement _nameError;
        [FindsBy(How = How.XPath, Using = "//p[text()='Address is required']")]
        private IWebElement _adressError;
        [FindsBy(How = How.XPath, Using = "//p[text()='Restaurant was successfully created']")]
        private IWebElement _popuprestaurantAdded;



        public void ClickMoreButton()
        {
            _moreButton.Click();
        }
        public void WaitForManageAndArchiveButtons()
        {
            WaitVisibilityOfElement(TimeToWait, _manageRestaurantButton);
        }
        public void ClickArchiveButton()
        {
            _archiveRestaurantButton.Click();
        }
        public void WaitForArchiveStatus()
        {
            WaitVisibilityOfElement(TimeToWait, _archivedStatus);
        }
        public void WaitForUnarchiveStaus()
        {
            WaitVisibilityOfElement(TimeToWait, _unarchivedStatus);
        }
        public void ClickAddRestaurantButton()
        {
            _addRestaurantButton.Click();
        }
        public void WaitForAppearanceRestaurantAddFunctional()
        {
            WaitVisibilityOfElement(TimeToWait, _inputRestaurantName);
        }
        public void SendKeysToInputRestaurantName(string name)
        {
            _inputRestaurantName.SendKeys(name);

        }
        public void SendKeysToInputRestaurantAdress(string adress)
        {
            _inputRestaurantAdress.SendKeys(adress);
        }
        public void ClickCreateRestaurantButton()
        {
            _createRestaurantButton.Click();
        }        
    }
}

