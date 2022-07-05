using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }
         [FindsBy(How = How.XPath, Using = "//h6[text()='View All']")]
        private IWebElement _viewAllIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='fast food']")]
        private IWebElement _fastFoodIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='vegetarian']")]
        private IWebElement _vegetarianIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='pizza']")]
        private IWebElement _pizzaIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='sushi']")]
        private IWebElement _sushiIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='pub']")]
        private IWebElement _pubIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='kebab']")]
        private IWebElement _kebabIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='greel']")]
        private IWebElement _greelIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='burgers']")]
        private IWebElement _burgersIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='beer']")]
        private IWebElement _beerIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='ukrainian cuisine']")]
        private IWebElement _ukrCuisineIcon ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='japanese cuisine']")]
        private IWebElement _japCuisineIcon ;
        
        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'sliderBtnPrev')]")]
        private IWebElement _sliderPrevImg ;
        
        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'sliderBtnNext')]")]
        private IWebElement _sliderNextImg ;
        
        [FindsBy(How = How.XPath, Using = "//img[contains(@alt, 'Some text 1')]")]
        private IWebElement _imgRelaxWithUs ;
        
        [FindsBy(How = How.XPath, Using = "//img[contains(@alt, 'Some text 2')]")]
        private IWebElement _imgEnjoyYourMeals  ;
        
        [FindsBy(How = How.XPath, Using = "//img[contains(@alt, 'Some text 3')]")]
        private IWebElement _imgYouAreWhatYouEat ;

       
    }
}
