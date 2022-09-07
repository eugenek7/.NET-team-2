using EasyRestProjectSpecflow.PageObjects;
using NUnit.Framework;
using SpecFlowProject.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class MakeReorderStepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly OrderHistoryPage _orderHistoryPage;
        private readonly CurrentOrdersPage _currentOrdersPage;

        public MakeReorderStepDefinitions(HomePage homePage, OrderHistoryPage orderHistoryPage, CurrentOrdersPage currentOrdersPage)
        {
            _homePage = homePage;
            _orderHistoryPage = orderHistoryPage;
            _currentOrdersPage = currentOrdersPage;
        }

        [Given(@"I navigate to my profile")]
        public void GivenINavigateToMyProfile()
        {
            _homePage.ClickProfileIcon();
            _homePage.ClickRolePanelButton();
        }

        [Given(@"I navigate to order history")]
        public void GivenINavigateToOrderHistory()
        {
            _orderHistoryPage.ClickOrderHistoryButton();
        }

        [Given(@"I click reorder")]
        public void WhenIClickReorder()
        {
            _orderHistoryPage.ClickDropDownButton();
            _orderHistoryPage.WaitForReorderButton();
            _orderHistoryPage.ClickReorderButton();
        }

        [When(@"I click submit reorder")]
        public void WhenIClickSubmitReorder()
        {
            _orderHistoryPage.ClickSubmitButton();
        }

        [When(@"I changing values to '([^']*)'")]
        public void WhenIChangingValuesTo(string negativevalue)
        {
            _orderHistoryPage.ClearInputItemQuantity();
            _orderHistoryPage.SendKeysToInputItemQuantity(negativevalue);
            _orderHistoryPage.ClickCancelOrderButton();
        }

        [When(@"I remove from the order list")]
        public void WhenIRemoveFromTheOrderList()
        {
            _orderHistoryPage.ClickRemoveItemButton();
        }

        [When(@"I increase dish quantity")]
        public void WhenIIncreaseDishQuantity()
        {
            _orderHistoryPage.IncreaseItemQuantity();
        }

        [When(@"I navigate to current orders")]
        public void WhenINavigateToCurrentOrders()
        {
            _currentOrdersPage.ClickCurrentOrdersButton();
        }

        [Then(@"I check that order with '([^']*)' appears in waiting to confirm")]
        public void ThenICheckThatOrderWithAppearsInWaitingToConfirm(string price)
        {
            _currentOrdersPage.ClickWaitingForConfirmButton();
            var actualPrice = _currentOrdersPage.GetPrice();
            var expectedPrice = price;
            StringAssert.Contains(expectedPrice, actualPrice, "Problems with Order");
        }

        [Then(@"I check that '([^']*)' appears")]
        public void ThenICheckThatAppears(string quantitypopup)
        {
            var expectPopUp = quantitypopup;
            var actualPopUp = _orderHistoryPage.GetPopUp();
            StringAssert.Contains(expectPopUp, actualPopUp, "Problems with ItemAddedPopUp");
        }
    }
}
