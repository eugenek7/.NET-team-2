using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    class CheckOrdersTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        MenuPage menuPage;
        RestaurantsPage restaurantsPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
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
            menuPage = GetMenuPage();
        }

            [Test]
        public void CheckPosibilityToBuyDish()
        {            
            menuPage.WaitForAddToCartButton(dataModel.TimeToWait);
            menuPage.ClickAddToCartButton();
            menuPage.WaitForitemAddedPopUp(dataModel.TimeToWait);
            var expectPopUp = dataModel.ItemAddedPopUp;
            var actualPopUp = menuPage.GetTextFromItemAddedPopUp();
            StringAssert.Contains(expectPopUp, actualPopUp, "Problems with ItemAddedPopUp");
        }

        [Test]
        public void CheckPosibilityToBuyNegativeNumberDish()
        {            
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);
            menuPage.ClickInputItemQuantity();
            menuPage.ClearInputItemQuantity();
            menuPage.SendKeysToInputItemQuantity("-1");
            menuPage.WaitForAddToCartButton(dataModel.TimeToWait);
            menuPage.ClickAddToCartButton();
            menuPage.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity11;
            var actualQuantity = menuPage.GetValueFromItemQuantity();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }

        [Test]
        public void CheckPosibilityToWriteSymbolsInNumberDish()
        {           
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);
            menuPage.ClickInputItemQuantity();
            menuPage.ClearInputItemQuantity();
            menuPage.SendKeysToInputItemQuantity("QW$");
            menuPage.WaitForAddToCartButton(dataModel.TimeToWait);
            menuPage.ClickAddToCartButton();
            menuPage.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity1;
            var actualQuantity = menuPage.GetValueFromItemQuantity();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }

        [Test]
        public void CheckPosibilityIncraseQuantity()
        {
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);
            menuPage.ClickInputItemQuantity();
            menuPage.IncreaseItemQuantity();
            menuPage.WaitForAddToCartButton(dataModel.TimeToWait);
            menuPage.ClickAddToCartButton();
            menuPage.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity2;
            var actualQuantity = menuPage.GetValueFromItemQuantity();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");           
        }

         [Test]
        public void CheckPosibilityDecraseQuantity()            
        {
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);
            menuPage.ClickInputItemQuantity();
            menuPage.DecreaseItemQuantity();
            menuPage.WaitForAddToCartButton(dataModel.TimeToWait);  
            menuPage.ClickAddToCartButton();
            menuPage.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity1;
            var actualQuantity = menuPage.GetValueFromItemQuantity();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }
    }
}
