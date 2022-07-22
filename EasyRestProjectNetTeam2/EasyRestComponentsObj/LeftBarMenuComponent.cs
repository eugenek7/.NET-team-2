using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class LeftBarComponent : BasePage
    {
        public LeftBarComponent(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Details']")]
        private IWebElement _detailsLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Menues']")]
        private IWebElement _menuesLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Create menu']")]
        private IWebElement _createMenuLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Common']")]
        private IWebElement _commonMenuLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Image Menu']")]
        private IWebElement _imageMenuLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Waiters']")]
        private IWebElement _waitersLeftBarButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Administrators']")]
        private IWebElement _administratorsLeftBarButton;

        //Star






        public void ClickDetailsLeftBarButton()
        {
            _detailsLeftBarButton.Click();
        }

        public void ClickMenuesLeftBarButton()
        {
            _menuesLeftBarButton.Click();
        }

        public void ClickCreateMenuLeftBarButton()
        {
            _createMenuLeftBarButton.Click();
        }

        public void ClickCommonMenuLeftBarButton()
        {
            _commonMenuLeftBarButton.Click();
        }

        public void ClickImageMenuLeftBarButton()
        {
            _imageMenuLeftBarButton.Click();
        }

        public void ClickWaitersLeftBarButton()
        {
            _waitersLeftBarButton.Click();
        }

        public void ClickAdministratorsLeftBarButton()
        {
            _administratorsLeftBarButton.Click();
        }

    }
}
