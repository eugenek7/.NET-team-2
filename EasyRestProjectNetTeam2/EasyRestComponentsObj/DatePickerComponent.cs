using System.Collections.Generic;
using System.Linq;
using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestComponentsObj
{
    public class DatePickerComponent : BasePage
    {
        public DatePickerComponent(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'MuiPickersDay')][not(@tabindex='-1')]")]
        private IList<IWebElement> _datePickerDaysList;

        [FindsBy(How = How.XPath, Using = "//h6[contains(@class, 'MuiTypography-root-41 MuiTypography-subtitle1-59 MuiP')]")]
        private IWebElement _yearIcon;

        [FindsBy(How = How.XPath, Using = "//div[@role='button' and contains(@class, 'MuiTypography-root')]")]
        private IList<IWebElement> _datePickerYearsList;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'MuiPickersSlideTransition-transitionContainer')]//p[contains(@class, 'MuiTypography-root-')]")]
        private IWebElement _monthIcon;

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class, 'MuiPickersCalendar')]//button[contains(@class, 'MuiButtonBase-root')])[1]")]
        private IWebElement _arrowForSwitchingMonth;

        [FindsBy(How = How.XPath, Using = "//span[text()='OK']/..")]
        private IWebElement _okButtonFromDatePicker;

        public void ChooseDateFromDatePicker(string fullDate)
        {
            string[] splitedDate = fullDate.Split('/', '.', ',', ' ');
            _yearIcon.Click();
            _datePickerYearsList.Where(year => year.Text.Equals(splitedDate[2])).First().Click();
            while (!_monthIcon.Text.Contains(splitedDate[1]))
            {
                _arrowForSwitchingMonth.Click();
            }
            _datePickerDaysList.Where(day => day.Text.Equals(splitedDate[0])).First().Click();
            _okButtonFromDatePicker.Click();
        }
    }
}
