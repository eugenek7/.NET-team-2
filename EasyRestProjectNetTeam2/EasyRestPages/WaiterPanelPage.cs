﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EasyRestProjectNetTeam2.EasyRestPages
{
    public class WaiterPanelPage : BasePage
    {
        public WaiterPanelPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//a[@href='/waiter/orders/Assigned waiter']")]
        private IWebElement _assignedWaiterTab;

        [FindsBy(How = How.XPath, Using = "//a[@href='/waiter/orders/In progress']")]
        private IWebElement _inProgressTab;

        [FindsBy(How = How.XPath, Using = "//a[@href='/waiter/orders/History']")]
        private IWebElement _historyTab;

        [FindsBy(How = How.XPath, Using = "(//button[@aria-label='Show more'])[1]")]
        private IWebElement _arrowDownButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Start order']/..")]
        private IWebElement _startOrderButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Close order']/..")]
        private IWebElement _closeOrderButton;

        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']")]
        private IWebElement _confirmationWindow;


        public void ClickAssignedWaiteTab()
        {
            _assignedWaiterTab.Click();
        }
        public void ClickInProgressTab()
        {
            _inProgressTab.Click();
        }
        public void ClickHistoryTab()
        {
            _historyTab.Click();
        }
        public void ClickArrowDownButton()
        {
            _arrowDownButton.Click();
        }
        public void ClickStartOrderButton()
        {
            _startOrderButton.Click();
        }
        public void ClickCloseOrderButton()
        {
            _closeOrderButton.Click();
        }
        public bool IsConfirmationWindowExist()
        {
            return _confirmationWindow.Displayed;
        }
    }
}

