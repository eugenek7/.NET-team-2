using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class Template : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        PersonalInfoPage personalInfoPage;
        RestaurantsPage restaurantsPage;
        MenuPage menuPage;


        [Test]
        public void CheckUserSignInAndLogOutTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.EmailForClient);
            signInPage.SendKeysToInputPassword(dataModel.PasswordForClient);
            signInPage.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForJonsonMenuIsClickable(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonMenu();
            menuPage = GetMenuPage();
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);
            //menuPage.ClickAddToCartButton();
            menuPage.MenuOrderItemsListComponent.WaitAndClickSubmitOrderButton(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.OrderConfirmationPopUpComponent.WaitAndClickSubmitButton(dataModel.TimeToWait);
            personalInfoPage = GetPersonalInfoPage();
            personalInfoPage.HeaderMenuComponent.ClickProfileIcon();
            personalInfoPage.HeaderMenuComponent.ClickLogOutButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.SignInPageUrlSearchWords), "Search word is absent on SignIn page URL");
        }

       

    }
}
