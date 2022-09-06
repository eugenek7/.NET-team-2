using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class OrderConfirmationPopUpComponent : BasePage
    {
        public DatePickerComponent DatePickerComponent { get; private set; }
        public TimePickerComponent TimePickerComponent { get; private set; }

        public OrderConfirmationPopUpComponent(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "(//td//input[@type= 'number'])[1]")]
        private IWebElement _inputItemQuantity;

        [FindsBy(How = How.XPath, Using = "(//td//button[@aria-label = 'Remove item'])[1]")]
        private IWebElement _removeItemButton;

        [FindsBy(How = How.XPath, Using = "//label[text()='Date picker']/following-sibling::div/input")]
        private IWebElement _inputDate;

        [FindsBy(How = How.XPath, Using = "//label[text()='Time picker']/following-sibling::div/input")]
        private IWebElement _inputTime;

        [FindsBy(How = How.XPath, Using = "//span[text()='Submit']/parent::button")]
        private IWebElement _submitButton;

        [FindsBy(How = How.XPath, Using = "//td[text()='Total:']/following-sibling::td")]
        private IWebElement _totalSum;

        public void SendKeysToInputItemQuantity(string quantity)
        {
            _inputItemQuantity.SendKeys(quantity);
        }

        public void IncreaseItemQuantity()
        {
            _inputItemQuantity.SendKeys(Keys.ArrowUp);
        }

        public void DecreaseItemQuantity()
        {
            _inputItemQuantity.SendKeys(Keys.ArrowDown);
        }

        public void GetItemQuantity()
        {
            _inputItemQuantity.GetAttribute("value");
        }

        public void ClickOnDatePicker()
        {
            _inputDate.Click();
            DatePickerComponent = new DatePickerComponent(driver);
        }

        public void ClickOnTimePicker()
        {
            _inputTime.Click();
            TimePickerComponent = new TimePickerComponent(driver);
        }

        public void WaitAndClickSubmitButton(int TimeToWait) //click submit button on Order confirmation pop-up
        {
            _submitButton.WaitAndClick(driver, TimeToWait);
        }

        public void ClickRemoveItemButton() //removes first item from cart
        {
            _removeItemButton.Click();
        }

        public string GetTextFromTotalSum(int timeToWait)
        {
            string sum = _totalSum.WaitAndGetText(driver, timeToWait);
            sum = sum.Remove(sum.Length - 1, 1);
            return sum;
        }
    }
}
