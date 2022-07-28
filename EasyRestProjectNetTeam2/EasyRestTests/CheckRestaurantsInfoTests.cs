using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;


namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckRestaurantsInfoTests : BaseTest
    {
        RestaurantsPage restaurantsPage;
        HomePage homePage;
        SignInPage signInPage;

        [Test]
        public void CheckReastaurantListPagetest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            homePage.HeaderMenuComponent.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForResturantListisCkickable(dataModel.TimeToWait);
            restaurantsPage.ClickRestarauntsList();
            var expectedUrl = dataModel.RestaurantsListPageUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is present for menu URL");
        }

            [Test]
        public void CheckReastaurantDetailsTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            homePage.HeaderMenuComponent.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForResturantListisCkickable(dataModel.TimeToWait);           
            restaurantsPage.ClickRestarauntsList();
            restaurantsPage.WaitForRestaruantDetails(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonDetails();
            var expectedUrl = dataModel.RestaurantDetailsUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is present for menu URL");         
        }

        [Test]
        public void CheckReastaurantMenuTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            homePage.HeaderMenuComponent.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForResturantListisCkickable(dataModel.TimeToWait);
            restaurantsPage.ClickRestarauntsList();
            restaurantsPage.WaitForRestaruantMenu(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonMenu();
            var expectedUrl = dataModel.RestaurantMenuUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is present for menu URL");             
        }

        [Test]
        public void CheckNavigateToBeerTagTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            homePage.HeaderMenuComponent.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForResturantListisCkickable(dataModel.TimeToWait);
            restaurantsPage.ClickRestarauntsList();
            restaurantsPage.WaitForBeerTag(dataModel.TimeToWait);
            restaurantsPage.ClickBeerTag();
            var expectedUrl = dataModel.BeerTagUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is present for menu URL");
        }

        [Test]
        public void CheckNavigateToKebabTagTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            homePage.HeaderMenuComponent.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForResturantListisCkickable(dataModel.TimeToWait);
            restaurantsPage.ClickRestarauntsList();
            restaurantsPage.WaitForKebabTag(dataModel.TimeToWait);
            restaurantsPage.ClickKebabTag();
            var expectedUrl = dataModel.KebabTagUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is present for menu URL");           
        }    
    }
}
