using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;


namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckRestaurantsInfoTests : BaseTest
    {
        RestaurantsPage restaurantsPage;
        HomePage homePage;
        SignInPage signInPage;
        BaseSignIn baseSignIn;

        [SetUp]
        public void SetUp()
        {
            base.SetUp();
            signInPage = GetSignInPage();
            homePage = GetHomePage();
            baseSignIn = new BaseSignIn(signInPage, homePage);
            baseSignIn.SignIn(dataModel.EmailForClient, dataModel.PasswordBase);
            homePage.HeaderMenuComponent.ClickSignInButton();
        }

        [Test]
        [Category("(cr) Possibility to navigate in restaurant list page")]
        public void CheckRestaurantListPageTest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            var expectedUrl = dataModel.RestaurantsListPageUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }

        [Test]
        [Category("(cr) Possibility to navigate in restaurant list page")]
        public void CheckRestaurantDetailsTest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            restaurantsPage.WaitAndClickJonsonDetails(dataModel.TimeToWait);
            var expectedUrl = dataModel.RestaurantDetailsUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }

        [Test]
        [Category("(cr) Possibility to navigate in restaurant list page")]
        public void CheckRestaurantMenuTest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            restaurantsPage.WaitAndClickJonsonMenu(dataModel.TimeToWait);
            var expectedUrl = dataModel.RestaurantMenuUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }

        [Test]
        [Category("(cr) Possibility to navigate in restaurant list page")]
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
        [Category("(cr) Possibility to navigate in restaurant list page")]
        public void CheckNavigateToKebabTagTest()
        {
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            restaurantsPage.WaitAndClicKebabTag(dataModel.TimeToWait);
            var expectedUrl = dataModel.KebabTagUrl;
            var actualUrl = restaurantsPage.GetPageUrl();
            StringAssert.Contains(expectedUrl, actualUrl, "Search word is absent for menu URL");
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForClient);
        }
    }
}
