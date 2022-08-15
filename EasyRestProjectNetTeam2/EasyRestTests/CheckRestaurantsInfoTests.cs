using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;


namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckRestaurantsInfoTests : BaseTest
    {
        RestaurantsPage restaurantsPage;
        HomePage homePage;
        SignInPage signInPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.EmailForClient);
            signInPage.SendKeysToInputPassword(dataModel.PasswordForClient);
            homePage.HeaderMenuComponent.ClickSignInButton();
        }
        [Test]
        public void CheckReastaurantListPagetest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            var expectedUrl = dataModel.RestaurantsListPageUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }

        [Test]
        public void CheckReastaurantDetailsTest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            restaurantsPage.WaitAndClickJonsonDetails(dataModel.TimeToWait);
            var expectedUrl = dataModel.RestaurantDetailsUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }

        [Test]
        public void CheckReastaurantMenuTest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            restaurantsPage.WaitAndClickJonsonMenu(dataModel.TimeToWait);
            var expectedUrl = dataModel.RestaurantMenuUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }

        [Test]
        public void CheckNavigateToBeerTagTest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            restaurantsPage.WaitAndClickBeerTag(dataModel.TimeToWait);
            var expectedUrl = dataModel.BeerTagUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }

        [Test]
        public void CheckNavigateToKebabTagTest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            restaurantsPage.WaitAndClicKebabTag(dataModel.TimeToWait);
            var expectedUrl = dataModel.KebabTagUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }
    }
}
