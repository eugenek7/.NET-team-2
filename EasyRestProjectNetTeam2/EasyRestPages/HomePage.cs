using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;



namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class HomePage : BasePage
    {
        public HeaderMenuComponent HeaderMenuComponent { get; set; }
        public HomePage(IWebDriver driver) : base(driver)
        {
            HeaderMenuComponent = new HeaderMenuComponent(driver);
        }

    }
}
