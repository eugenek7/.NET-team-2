using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
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
            var totalSum = menuPage.MenuOrderItemsListComponent.OrderConfirmationPopUpComponent.GetTextFromTotalSum(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.OrderConfirmationPopUpComponent.WaitAndClickSubmitButton(dataModel.TimeToWait);
            var ifOrderConfirmationPopUpDisplayed = menuPage.WaitAndCheckIfDisplayedOrderStatusConfirmPopUp(dataModel.TimeToWait);
            Assert.IsTrue(ifOrderConfirmationPopUpDisplayed, "Pop up for order confirmation not displayed");
            menuPage.HeaderMenuComponent.ClickProfileIcon();
            menuPage.HeaderMenuComponent.ClickRolePanelButton();



        }





















    }
}
