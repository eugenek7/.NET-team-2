using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class AdministratorPanelPage : BasePage
    {
        public AdministratorPanelPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Waiting for confirm']")]
        private IWebElement _waitingToConfirmOrderTab;

        [FindsBy(How = How.XPath, Using = "//span[text()='Accepted']")]
        private IWebElement _acceptedOrderTab;

        [FindsBy(How = How.XPath, Using = "//span[text()='Accept']")]
        private IWebElement _acceptOrderButton;

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class, 'expandIcon')])[1]")]  //First one in the list
        private IWebElement _arrowToGetInfoAboutOrderButton;

        [FindsBy(How = How.XPath, Using = "(//input[@name='waiters'])[1]")]   //First one in the list
        private IWebElement _choseWaiterRadioButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Assign']")]
        private IWebElement _assignOrderToWaiterButton;


        public void ClickWaitingToConfirmTab()
        {
            _waitingToConfirmOrderTab.Click();
        }

        public void ClickAcceptedTab()
        {
            _acceptedOrderTab.Click();
        }

        public void ClickAcceptOrderButton()
        {
            _acceptOrderButton.Click();
        }

        public void ClickToGetInfoAboutOrderArrow()
        {
            _arrowToGetInfoAboutOrderButton.Click();
        }

        public void ClickChoseWaiterRadioButton()
        {
            _choseWaiterRadioButton.Click();
        }

        public void ClickAssignToWaiterButton()
        {
            _assignOrderToWaiterButton.Click();
        }
    }
}