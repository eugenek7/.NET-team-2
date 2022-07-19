using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class HomePage : BasePage
    {
        public HeaderMenuComponent HeaderMenuComponent { get; set; }
        public HomePage(IWebDriver driver) : base(driver)
        {
            HeaderMenuComponent = new HeaderMenuComponent(driver);

        }

        [FindsBy(How = How.XPath, Using = "//h6[text()='vegetarian']")]
        private IWebElement _vegetarianIcon;

        [FindsBy(How = How.XPath, Using = "//h6[text()='sushi']")]
        private IWebElement _sushiIcon;
        [FindsBy(How = How.XPath, Using = "//h6[text()='fast food']")]
        private IWebElement _fastFoodIcon;

        public void ClickOnFastFoodIcon()
        {
            _fastFoodIcon.Click();
        }

        public void ClickOnVegetarianIcon()
        {
            _vegetarianIcon.Click();
        }

        public void ClickOnSushiIcon()
        {
            _sushiIcon.Click();
        }

    }

}