﻿using EasyRestProjectNetTeam2.Decorator;
using EasyRestProjectNetTeam2.EasyRestComponentsObj;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class ManageWaitersPage : BasePage
    {

        public AddEmployeeComponent AddEmploeeComponent { get; private set; }

        public ManageWaitersPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class, 'MuiButtonBase-root')])[2]")]
        private IWebElement _deleteButton;

        [FindsBy(How = How.XPath, Using = "//p[text()='User successfully added']")]
        private IWebElement _userSuccessfullyAddedPopUp;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'MuiPaper-rounded')]/ul/li/div/span")]
        private IList<IWebElement> _listOfWaiters;

        [FindsBy(How = How.XPath, Using = "//button[@title='Add Waiter']")]
        private IWebElement _addWaiterButton;

        public bool CheckThatNewWaiterAppears(string NameForNewEmployee)
        {
            return _listOfWaiters.Any(waiterElement => waiterElement.Text.Equals(NameForNewEmployee));
        }

        public void ClickDeleteButton()
        {
            _deleteButton.Click();
        }

        public void ClickAddWaiterButton()
        {
            _addWaiterButton.Click();
            AddEmploeeComponent = new AddEmployeeComponent(driver);
        }

        public bool WaitAndCheckIfDisplayedUserSuccesfullyAddedConfirmationPopUp(int TimeToWait)
        {
            return _userSuccessfullyAddedPopUp.WaitElementAndCheckIfDisplayed(driver, TimeToWait);
        }
    }
}

