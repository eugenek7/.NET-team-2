using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckMakingOrder : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        BaseSignIn baseSignIn;
        RestaurantsPage restaurantsPage;
        MenuPage menuPage;
        PersonalInfoPage personalInfoPage;
        CurrentOrdersPage currentOrdersPage;

        [SetUp]
        public void SetUp()
        {
            signInPage = GetSignInPage();
            homePage = GetHomePage();
            baseSignIn = new BaseSignIn(signInPage, homePage);
            baseSignIn.SignIn(dataModel.EmailForClient, dataModel.PasswordBase);
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickJonsonMenu(dataModel.TimeToWait);
        }

        [Test]
        [Category("(co)Possibility to submit order in order confirmation pop up menu")]
        [Category("Smoke")]
        public void CheckPossibilityToMakeOrder()
        {
            menuPage = GetMenuPage();
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.WaitAndClickSubmitOrderButton(dataModel.TimeToWait);
            var totalSum = menuPage.MenuOrderItemsListComponent.OrderConfirmationPopUpComponent.WaitAndGetTextFromTotalSumOfLastOrder(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.OrderConfirmationPopUpComponent.WaitAndClickSubmitButton(dataModel.TimeToWait);
            var ifOrderConfirmationPopUpDisplayed = menuPage.WaitAndCheckIfDisplayedOrderStatusConfirmPopUp(dataModel.TimeToWait);
            Assert.IsTrue(ifOrderConfirmationPopUpDisplayed, "Pop up for order confirmation not displayed");
            menuPage.HeaderMenuComponent.ClickEasyrestButton();
            menuPage.HeaderMenuComponent.ClickProfileIcon();
            menuPage.HeaderMenuComponent.ClickRolePanelButton();
            personalInfoPage = GetPersonalInfoPage();
            personalInfoPage.ClickCurrentOrdersButton();
            currentOrdersPage = GetCurrentOrdersPage();
            var ifOrderDisplayed = currentOrdersPage.WaitAndCheckIfOrderDisplayed(dataModel.TimeToWait);
            Assert.IsTrue(ifOrderDisplayed, "There is no order displayed");
            var totalSumOfLastOrder = currentOrdersPage.WaitAndGetSumFromLastOrder(dataModel.TimeToWait);
            StringAssert.Contains(totalSum, totalSumOfLastOrder, "In last order there is no expected sum.");
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteLastFromOrderAssociationsByEmail, dataModel.EmailForClient);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteLastFromOrdersByEmail, dataModel.EmailForClient);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForClient);
        }
    }
}
