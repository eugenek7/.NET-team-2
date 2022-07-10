using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    class PersonalInfoPage : BasePage
    {
        public PersonalInfoPage(IWebDriver driver) : base(driver)
        { }
        [FindsBy(How = How.XPath, Using = "//span [contains(@class, 'MuiButtonBase-root')]")]
        private IWebElement _editPhoto;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'Personal Info')]")]
        private IWebElement _personalInfoButton;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'Current Orders')]")]
        private IWebElement _currentOrdersButton;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'Order History')]")]
        private IWebElement _orderhistoryButton;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'My Restaurants')]")]
        private IWebElement _myRestaurantsButton;

        public void ClickEditPhoto()
        {
            _editPhoto.Click();

        }
        public void ClickPersonalInfoButton()
        {
            _personalInfoButton.Click();

        }
        public void ClickCurrentOrdersButton()
        {
            _currentOrdersButton.Click();

        }
        public void ClickOrderHistoryButton()
        {
            _orderhistoryButton.Click();

        }
        public void MyRestaurantsButton()
        {
           _myRestaurantsButton.Click();    

        }
    }
}
