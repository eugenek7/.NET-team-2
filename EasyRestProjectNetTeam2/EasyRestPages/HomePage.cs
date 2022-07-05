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
        private IWebElement viewAll ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='fast food']")]
        private IWebElement fastFood ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='vegetarian']")]
        private IWebElement vegetarian ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='pizza']")]
        private IWebElement pizza ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='sushi']")]
        private IWebElement sushi ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='pub']")]
        private IWebElement pub ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='kebab']")]
        private IWebElement kebab ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='greel']")]
        private IWebElement greel ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='burgers']")]
        private IWebElement burgers ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='beer']")]
        private IWebElement beer ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='ukrainian cuisine']")]
        private IWebElement ukrCuisine ;
        
        [FindsBy(How = How.XPath, Using = "//h6[text()='japanese cuisine']")]
        private IWebElement japCuisine ;
        
        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'sliderBtnPrev')]")]
        private IWebElement sliderPrev ;
        
        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'sliderBtnNext')]")]
        private IWebElement sliderNext ;
        
        [FindsBy(How = How.XPath, Using = "//img[contains(@alt, 'Some text 1')]")]
        private IWebElement imgSnowman ;
        
        [FindsBy(How = How.XPath, Using = "//img[contains(@alt, 'Some text 2')]")]
        private IWebElement imgPizza ;
        
        [FindsBy(How = How.XPath, Using = "//img[contains(@alt, 'Some text 3')]")]
        private IWebElement imgVegs ;

       
    }
}
