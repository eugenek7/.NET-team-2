using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class MenuOrderItemsListComponent : BasePage
    {
        public OrderConfirmationPopUpComponent OrderConfirmationPopUpComponent { get; private set; }

        public MenuOrderItemsListComponent(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "(//button[@aria-label='Remove item'])[1]")]
        private IWebElement _removeItemButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Submit order']/parent::button")]
        private IWebElement _submitOrderButton;

        public void ClickRemoveItemButton() //removes first item from cart
        {
            _removeItemButton.Click();
        }

        public void ClickSubmitOrderButton() //opens Order confirmation pop-up
        {
            _submitOrderButton.Click();
            OrderConfirmationPopUpComponent = new OrderConfirmationPopUpComponent(driver);
        }

    }
}
