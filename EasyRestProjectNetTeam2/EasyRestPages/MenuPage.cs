using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class MenuPage : BasePage
    {

        public DatePickerComponent DatePickerComponent { get; private set; }
        public TimePickerComponent TimePickerComponent { get; private set; }

        public MenuPage(IWebDriver driver) : base(driver)
        {
        }
          
        [FindsBy(How = How.XPath, Using = "(//input[@id='quantity'][not(@disabled)])[1]")]
        private IWebElement _inputItemQuantity;

        [FindsBy(How = How.XPath, Using = "(//button[@aria-label='Add to cart'][not(@disabled)])[1]")]
        private IWebElement _addToCartButton;

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

        [FindsBy(How = How.XPath, Using = "//p[text()='Sorry, you can`t pick past book time']")]
        private IWebElement _errorPopUp;

        [FindsBy(How = How.XPath, Using = "//span[text()='Hot']")]
        private IWebElement _hotCatagoryButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Soup']")]
        private IWebElement _soupCatagoryButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Coctails']")]
        private IWebElement _coctailsCatagoryButton;


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

        public void ClickAddToCartButton()
        {
            _addToCartButton.Click();
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


        public void ClikHotCatagory()
        {
            _hotCatagoryButton.Click();
        }

        public void ClikSoupCatagory()
        {
            _soupCatagoryButton.Click();
        }

        public void ClikCoctailsCatagory()
        {
            _coctailsCatagoryButton.Click();
        }

        public void WaitForSoupCategoryIsClickable(int timeToWait)
        {
            WaitElementIsClickable(timeToWait, _soupCatagoryButton);
        }

        public void WaitForHotCategoryIsClickable(int timeToWait)
        {
            WaitElementIsClickable(timeToWait, _hotCatagoryButton);
        }

        public void WaitForCoctailsCategoryIsClickable(int timeToWait)
        {
            WaitElementIsClickable(timeToWait, _coctailsCatagoryButton);
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

        public string GetErrorPopupText()
        {
            return _errorPopUp.Text;
        }

    }
}
