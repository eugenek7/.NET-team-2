using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class PersonalInfoPage : BasePage
    {
        public HeaderMenuComponent HeaderMenuComponent { get; private set; }
        public PersonalInfoPage(IWebDriver driver) : base(driver)
        {
            HeaderMenuComponent = new HeaderMenuComponent(driver);
        }

        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Email:')]/following-sibling::td")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Name:')]/following-sibling::td")]
        private IWebElement _inputName;

        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Birth date:')]/following-sibling::td")]
        private IWebElement _inputBirthDate;

        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Phone number:')]/following-sibling::td")]
        private IWebElement _inputPhoneNumber;

        [FindsBy(How = How.XPath, Using = "//span[(text()= 'Personal Info')]")]
        private IWebElement _personalInfoButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Current Orders']/parent::span")]
        private IWebElement _currentOrdersButton;

        public string GetTextFromEmailField()
        {
            return _inputEmail.Text;
        }

        public void WaitInputEmailIsVisible(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _inputEmail);
        }

        public string GetTextFromNameField()
        {
            return _inputName.Text;
        }

        public void WaitInputNameIsVisible(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _inputName);
        }

        public string GetTextFromBirthDateField()
        {
            return _inputBirthDate.Text;
        }

        public void WaitInputBirthDateIsVisible(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _inputBirthDate);
        }

        public string GetTextFromPhoneNumberlField()
        {
            return _inputPhoneNumber.Text;
        }

        public void WaitInputPhoneNumberIsVisible(int TimeToWait)
        {
            WaitVisibilityOfElement(TimeToWait, _inputPhoneNumber);
        }

        public void ClickPersonalInfoButton()
        {
            _personalInfoButton.Click();
        }

        public void ClickCurrentOrdersButton()
        {
            _currentOrdersButton.Click();
        }
    }
}
