using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        [FindsBy(How = How.XPath, Using = "(//input[contains (@class,'MuiInputBase-input')]) [11]")]
        private IWebElement _itemQuantityInTheCart;       

        public void WaitForItemQuantityInTheCart(int timeToWait)
        {
            WaitElementIsEnable(timeToWait, _itemQuantityInTheCart);
        }

        public string GetValueFromItemQuantityInCart()
        {
            return _itemQuantityInTheCart.GetAttribute("value");
        }

        public void WaitAndClickRemoveItemButton(int timeToWait) //removes first item from cart
        {
            _removeItemButton.WaitAndClick(driver, timeToWait);
        }

        public void WaitAndClickSubmitOrderButton(int timeToWait) //opens Order confirmation pop-up
        {
            _submitOrderButton.WaitAndClick(driver, timeToWait);
            OrderConfirmationPopUpComponent = new OrderConfirmationPopUpComponent(driver);
        }
    }
}
