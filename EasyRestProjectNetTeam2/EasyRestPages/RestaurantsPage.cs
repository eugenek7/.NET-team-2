using EasyRestProjectNetTeam2.Decorator;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class RestaurantsPage : BasePage
    {
       using EasyRestProjectNetTeam2.Decorator;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
        private IWebElement _restaurantsList;              
        
        {
            public RestaurantsPage(IWebDriver driver) : base(driver)
            {
        [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=kebab']  ")]
        private IWebElement _kebabTag;
        
            private IWebElement _restaurantsList;

            [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=beer']")]
            private IWebElement _beerTag;

            [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=kebab']  ")]
            private IWebElement _kebabTag;

            _johnsonDetails.WaitAndClick(driver, TimeToWait);
            private IWebElement _johnsonDetails;

        public void WaitAndClickJonsonMenu(int TimeToWait)
            private IWebElement _johnsonMenu;


            public void WaitAndClickJonsonDetails(int TimeToWait)
            {
                _johnsonDetails.WaitAndClick(driver, TimeToWait);
            }

            public void WaitAndClickJonsonMenu(int TimeToWait)
            {
                _johnsonMenu.WaitAndClick(driver, TimeToWait);
            }


        public void WaitAndClicKebabTag(int TimeToWait)
                _restaurantsList.WaitAndClick(driver, TimeToWait);
            _kebabTag.WaitAndClick(driver, TimeToWait);
        }       
        }
    }