using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class MenuPage : BasePage
    {
        public MenuPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.XPath, Using = "(//input[@id='quantity'])[1]")]
        private IWebElement _inputItemQuantity1;
        [FindsBy(How = How.XPath, Using = "(//input[@id='quantity'])[2]")]
        private IWebElement _inputItemQuantity2;
        [FindsBy(How = How.XPath, Using = "(//button[@aria-label='Add to cart'])[1]")]
        private IWebElement _addToCartButton1;
        [FindsBy(How = How.XPath, Using = "(//button[@aria-label='Add to cart'])[2]")]
        private IWebElement _addToCartButton2;
        [FindsBy(How = How.XPath, Using = "(//button[@aria-label='Remove item'])[1]")]
        private IWebElement _removeItemButton;
        [FindsBy(How = How.XPath, Using = "//span[text()='Submit order']/parent::button")]
        private IWebElement _submitOrderButton;
        [FindsBy(How = How.XPath, Using = "//span[text()='Submit']/parent::button")]
        private IWebElement _submitButton;
        [FindsBy(How = How.XPath, Using = "//label[text()='Date picker']/following-sibling::div/input")]
        private IWebElement _inputDate;
        [FindsBy(How = How.XPath, Using = "//label[text()='Time picker']/following-sibling::div/input")]
        private IWebElement _inputTime;

        public void SendKeysToInputItemQuantity1(string quantity)
        {
            _inputItemQuantity1.SendKeys(quantity);

        }
        public void SendKeysToInputItemQuantity2(string quantity)
        {
            _inputItemQuantity2.SendKeys(quantity);

        }
        public void IncreaseItemQuantity()
        {
            _inputItemQuantity1.SendKeys(Keys.ArrowUp);
        }
        public void DecreaseItemQuantity()
        {
            _inputItemQuantity1.SendKeys(Keys.ArrowDown);
        }
        public void ClickAddToCartButton1()
        {
            _addToCartButton1.Click();
        }
        public void ClickAddToCartButton2()
        {
            _addToCartButton2.Click();
        }
        public void ClickRemoveItemButton() //removes first item from cart
        {
            _removeItemButton.Click();
        }
        public void ClickSubmitOrderButton() //opens Order confirmation pop-up
        {
            _submitOrderButton.Click();
        }
        public void ClickSubmitButton() //click submit button on Order confirmation pop-up
        {
            _submitButton.Click();
        }
        public void ClickOnDataPicker()
        {
            _inputDate.Click();
        }
        public void ClickOnTimePicker()
        {
            _inputTime.Click();
        }

    }
}
