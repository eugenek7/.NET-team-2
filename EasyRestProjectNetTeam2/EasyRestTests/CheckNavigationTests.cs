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
        public void cn1_CheckNavigationToMenuCategory()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            homePage.HeaderMenuComponent.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForJonsonMenuIsClickable(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonMenu();
            menuPage = GetMenuPage();
            menuPage.WaitForHotCategoryIsClickable(dataModel.TimeToWait);
            menuPage.ClikHotCatagory();
            var actualPageUrl = menuPage.GetPageUrl();
            var expectedPageUrl = dataModel.NavigationHotCatagoryMenuPage;
            StringAssert.Contains(expectedPageUrl, actualPageUrl, "Search word is missed for menu URL");
            menuPage.HeaderMenuComponent.ClickProfileIcon();
            menuPage.HeaderMenuComponent.ClickLogOutButton();
        }

        [Test]
        public void cn2_CheckNavigationToMenuCategory()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            homePage.HeaderMenuComponent.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForJonsonMenuIsClickable(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonMenu();
            menuPage = GetMenuPage();
            menuPage.WaitForHotCategoryIsClickable(dataModel.TimeToWait);
            menuPage.ClikSoupCatagory();
            var actualPageUrl = menuPage.GetPageUrl();
            var expectedPageUrl = dataModel.NavigationSoupCatagoryMenuPage;
            StringAssert.Contains(expectedPageUrl, actualPageUrl, "Search word is missed for menu URL");
            menuPage.HeaderMenuComponent.ClickProfileIcon();
            menuPage.HeaderMenuComponent.ClickLogOutButton();
        }

        [Test]
        public void cn3_CheckNavigationToMenuCategory()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            homePage.HeaderMenuComponent.ClickSignInButton();
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitForJonsonMenuIsClickable(dataModel.TimeToWait);
            restaurantsPage.ClickJohnsonMenu();
            menuPage = GetMenuPage();
            menuPage.WaitForCoctailsCatagoryIsClickable(dataModel.TimeToWait);
            menuPage.ClikCoctailsCatagory();
            var actualPageUrl = menuPage.GetPageUrl();
            var expectedPageUrl = dataModel.NavigationCoctailsCatagoryMenuPage;
            StringAssert.Contains(expectedPageUrl, actualPageUrl, "Search word is missed for menu URL");
            menuPage.HeaderMenuComponent.ClickProfileIcon();
            menuPage.HeaderMenuComponent.ClickLogOutButton();
        }
    }
}













