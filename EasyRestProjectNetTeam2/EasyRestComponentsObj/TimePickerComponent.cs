using System.Collections.Generic;
using System.Linq;
using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class TimePickerComponent : BasePage
    {
        public TimePickerComponent(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'MuiPickersClockPointer-thumb')]")]
        private IWebElement _clockHand;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'MuiTypography-root') and contains(@style, 'transform')]")]
        private IList<IWebElement> _listOfHoursAndMinutes;

        [FindsBy(How = How.XPath, Using = "//h6[text()='AM']")]
        private IWebElement _amIcon;

        [FindsBy(How = How.XPath, Using = "//h6[text()='PM']")]
        private IWebElement _pmIcon;

        [FindsBy(How = How.XPath, Using = "//span[text()='OK']/..")]
        private IWebElement _okButton;


        public void ChooseTimeFromTimePicker(string fullTime)
        {
            string[] splittedTime = fullTime.ToLower().Split(' ', ':', '.', '/');
            Actions action = new Actions(driver);
            action.DragAndDrop(_clockHand, _listOfHoursAndMinutes.Where(hour => hour.Text.Contains(splittedTime[0])).First()).Build().Perform();
            action.DragAndDrop(_clockHand, _listOfHoursAndMinutes.Where(minutes => minutes.Text.Contains(splittedTime[1])).First()).Build().Perform();

            if (splittedTime[2].Contains("am"))
            {
                _amIcon.Click();
            }
            else
            {
                _pmIcon.Click();
            }
            _okButton.Click();
        }
    }
}
