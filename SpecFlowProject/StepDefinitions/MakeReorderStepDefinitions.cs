using EasyRestSpecFlow.Pages;
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
            _currentOrdersPage= currentOrdersPage;
        }
      
        [Given(@"I navigate to my profile")]
        public void GivenINavigateToMyProfile()
        {
            Thread.Sleep(2000);
            _homePage.ClickProfileIcon();
            Thread.Sleep(2000);
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
            Thread.Sleep(2000);
            _orderHistoryPage.ClickReorderButton();            
        }

        [When(@"I click submit reorder")]
        public void WhenIClickSubmitReorder()
        {
            Thread.Sleep(2000);
            _orderHistoryPage.ClickSubmitButton();
        }              

        [When(@"I changing values to '([^']*)'")]
        public void WhenIChangingValuesTo(string negativevalue)
        {
            _orderHistoryPage.SendKeysToInputItemQuantity(negativevalue);
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
            Thread.Sleep(2000);
            _currentOrdersPage.ClickCurrentOrdersButton();
        }
                
        [Then(@"I check that order appears in waiting to confirm")]
        public void ThenOrderAppearsInWaitingToConfirm()
        {
            _currentOrdersPage.ClickWaitingforconfirmButton();
            Thread.Sleep(2000);
            var ifOrderInTheList = _currentOrdersPage.CheckThatOrserAppears ("151");
            Assert.IsTrue(ifOrderInTheList, "The order doesn't appear in the list of orders.");
        }

        [Then(@"I check that quantity of dish remained in the amount of one")]
        public void ThenQuantityOfDishRemainedInTheAmountOfOne()
        {
            var expectQuantity = "1";
            var actualQuantity = _orderHistoryPage.GetItemQuantity();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }
    }
}
