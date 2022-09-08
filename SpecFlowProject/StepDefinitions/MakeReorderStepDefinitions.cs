using EasyRestSpecFlow.Pages;
using NUnit.Framework;
using SpecFlowProject.Pages;


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
            _currentOrdersPage= currentOrdersPage;
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

        [Then(@"I check that '([^']*)' of dish remained in the amount of one")]
        public void ThenICheckThatOfDishRemainedInTheAmountOfOne(string quantity)
        {
            var expectQuantity = quantity;
            var actualQuantity = _orderHistoryPage.GetItemQuantity();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }

        [Then(@"I check that order with '([^']*)' appears in waiting to confirm")]
        public void ThenICheckThatOrderWithAppearsInWaitingToConfirm(string price)
        {
            _currentOrdersPage.ClickWaitingforconfirmButton();           
            var actualorderId = _currentOrdersPage.GetPrice();
            var expectedorderId = price;
            StringAssert.Contains(expectedorderId, actualorderId, "Problems with Order");
        }

        [Then(@"I check that '([^']*)' appears in popup")]
        public void ThenICheckThatAppearsInPopup(string quantitypopup)
        {
            var expectPopUp = quantitypopup;
            var actualPopUp = _orderHistoryPage.GetPopup();
            StringAssert.Contains(expectPopUp, actualPopUp, "Problems with ItemAddedPopUp");
        }
    }
}
