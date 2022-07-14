using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class PersonalInfoPage : BasePage
    {
        public HeaderMenuComponent HeaderMenuComponent { get; set; }
        public PersonalInfoPage(IWebDriver driver) : base(driver)
        {
            HeaderMenuComponent = new HeaderMenuComponent(driver);
        }

        private const int TimeToWait = 20;

        [FindsBy(How = How.XPath, Using = "//th[contains(text(), 'Email:')]/following-sibling::td")]
        private IWebElement _inputEmail;

        public string GetTextFromEmailField()
        {
            return _inputEmail.Text;
        }

        public void WaitInputEmailIsVisible()
        {
            WaitVisibilityOfElement(TimeToWait, _inputEmail);
        }

    }
}
