using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageMenuPage : BasePage
    {
        public ManageMenuPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'MuiList-root')]/a/div/span")]
        private IList <IWebElement> _listOfMenus;

        [FindsBy(How = How.XPath, Using = "//span[text()='Create menu']/parent::div/parent::a")]
        private IWebElement _createMenuButton;

        [FindsBy(How = How.XPath, Using = "//input[@name='menuName']")]
        private IWebElement _inputMenuName;

        [FindsBy(How = How.XPath, Using = "//input[@value='list']")]
        private IWebElement _listMenuRadio;

        [FindsBy(How = How.XPath, Using = "//input[@value='image']")]
        private IWebElement _imageMenuRadio;

        [FindsBy(How = How.XPath, Using = "//span[text()='Next']/parent::button")]
        private IList <IWebElement> _nextButton;

        [FindsBy(How = How.XPath, Using = "(//span[text()='Finish']/parent::button)[3]")]
        private IWebElement _finishButton;

        public void ClickCreateMenuButton()
        {
            _createMenuButton.Click();
        }

        public void SendKeysInputMenuName(string menuName)
        {
            _inputMenuName.SendKeys(menuName);
        }

        public void ClickListMenuRadio()
        {
            _listMenuRadio.Click();
        }

        public void ClickImageMenuRadio()
        {
            _imageMenuRadio.Click();
        }

        public void ClickNextAndFinishButtons()
        {
            _nextButton[0].Click();
            _nextButton[1].Click();
            _finishButton.Click();
        }

        public bool CheckThatNewMenuAppears(string menuName)
        {
            
            foreach (IWebElement menu in _listOfMenus)
            {
                if (menu.Text.Equals(menuName))
                    return true;
            }
            return false;
        }
    }
}
