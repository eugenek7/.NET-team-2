using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckNavigationTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        RestaurantsPage restaurantsPage;
        MenuPage menuPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForClient, dataModel.PasswordForClient);
            restaurantsPage = GetRestaurantsPage();
        }

        [Test]
        public void CheckNavigationToMenuCategoryHot()
        {
            restaurantsPage.WaitAndClickJonsonMenu(dataModel.TimeToWait);        
            menuPage = GetMenuPage();
            menuPage.WaitForHotCategoryIsClickable(dataModel.TimeToWait);
            menuPage.ClikHotCatagory();
            var actualPageUrl = menuPage.GetPageUrl();
            var expectedSearchWord = dataModel.NavigationHotCatagoryMenuPage;
            StringAssert.Contains(expectedSearchWord, actualPageUrl, "Search word is missed for menu URL");
        }

        [Test]
        public void CheckNavigationToMenuCategorySoup()
        {
            restaurantsPage.WaitAndClickJonsonMenu(dataModel.TimeToWait);          
            menuPage = GetMenuPage();
            menuPage.WaitForSoupCategoryIsClickable(dataModel.TimeToWait);
            menuPage.ClikSoupCatagory();
            var actualPageUrl = menuPage.GetPageUrl();
            var expectedSearchWord = dataModel.NavigationSoupCatagoryMenuPage;
            StringAssert.Contains(expectedSearchWord, actualPageUrl, "Search word is missed for menu URL");
        }

        [Test]
        public void CheckNavigationToMenuCategoryCoctails()
        {
            restaurantsPage.WaitAndClickJonsonMenu(dataModel.TimeToWait);         
            menuPage = GetMenuPage();
            menuPage.WaitForCoctailsCategoryIsClickable(dataModel.TimeToWait);
            menuPage.ClikCoctailsCatagory();
            var actualPageUrl = menuPage.GetPageUrl();
            var expectedSearchWord = dataModel.NavigationCoctailsCatagoryMenuPage;
            StringAssert.Contains(expectedSearchWord, actualPageUrl, "Search word is missed for menu URL");
        }
    }
}
