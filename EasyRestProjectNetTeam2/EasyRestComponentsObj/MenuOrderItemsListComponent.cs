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

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class, 'MuiCardContent-root')]) [2]")]
        private IWebElement _Cart;       

        public void MoveToCart()
        {
            Actions act = new Actions(driver);
            act.MoveToElement(_Cart).Build().Perform();            
        }

        public void WaitForCart(int timeToWait)
        {
            WaitElementIsEnable(timeToWait, _Cart);
        }

        public void WaitForItemQuantityInTheCart(int timeToWait)
        {
            WaitElementIsEnable(timeToWait, _itemQuantityInTheCart);
        }

        public string GetValueFromItemQuantityInCart()
        {
            return _itemQuantityInTheCart.GetAttribute("value");
        }

        public void WaitAndClickRemoveItemButton(int TimeToWait) //removes first item from cart
        {
            _removeItemButton.WaitAndClick(driver, TimeToWait);
        }

        public void WaitAndClickSubmitOrderButton(int TimeToWait) //opens Order confirmation pop-up
        {
            _submitOrderButton.WaitAndClick(driver, TimeToWait);
            OrderConfirmationPopUpComponent = new OrderConfirmationPopUpComponent(driver);
        }
    }
}
