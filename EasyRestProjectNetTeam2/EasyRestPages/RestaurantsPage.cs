using EasyRestProjectNetTeam2.Decorator;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class RestaurantsPage : BasePage
    {
        public RestaurantsPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants']")]
        private IWebElement _restaurantsList;              
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=beer']")]
        private IWebElement _beerTag;

        [FindsBy(How = How.XPath, Using = "//a[@href='/?tag=kebab']  ")]
        private IWebElement _kebabTag;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurants/2']")]
        private IWebElement _johnsonDetails;

        [FindsBy(How = How.XPath, Using = "//a[@href='/restaurant/2/menu/3']/..")]
        private IWebElement _johnsonMenu;                    
                          
        public void WaitAndClickJonsonDetails(int timeToWait)
        {
            _johnsonDetails.WaitAndClick(driver, timeToWait);
        }

        public void WaitAndClickJonsonMenu(int timeToWait)
        {
            _johnsonMenu.WaitAndClick(driver, timeToWait);
        }                        
        
        public void WaitAndClickResturantList(int timeToWait)
        {
            _restaurantsList.WaitAndClick(driver, timeToWait);
        }

        public void WaitAndClicBeerTag(int timeToWait)
        {
            _beerTag.WaitAndClick(driver, timeToWait);
        }

        public void WaitAndClicKebabTag(int timeToWait)
        {
            _kebabTag.WaitAndClick(driver, timeToWait);
        }       
    }
}