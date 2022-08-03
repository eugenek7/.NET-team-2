using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckNavigationTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        RestaurantsPage restaurantsPage;
        MenuPage menuPage;

        [Test]
        public void CheckNavigationToMenuCategoryHot()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForClient, dataModel.PasswordForClient);
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForJonsonMenuIsClickable(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonMenu();
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
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForClient, dataModel.PasswordForClient);
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForJonsonMenuIsClickable(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonMenu();
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
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SignInWithValidData(dataModel.EmailForClient, dataModel.PasswordForClient);
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForJonsonMenuIsClickable(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonMenu();
            menuPage = GetMenuPage();
            menuPage.WaitForCoctailsCategoryIsClickable(dataModel.TimeToWait);
            menuPage.ClikCoctailsCatagory();
            var actualPageUrl = menuPage.GetPageUrl();
            var expectedSearchWord = dataModel.NavigationCoctailsCatagoryMenuPage;
            StringAssert.Contains(expectedSearchWord, actualPageUrl, "Search word is missed for menu URL");
        }
    }
}
