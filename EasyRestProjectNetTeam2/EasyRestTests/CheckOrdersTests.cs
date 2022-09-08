using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
using EasyRestProjectNetTeam2.Helpers;
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
        BaseSignIn baseSignIn;

        [SetUp]
        public void SetUp()
        {
            signInPage = GetSignInPage();
            homePage = GetHomePage();
            baseSignIn = new BaseSignIn(signInPage, homePage);
            baseSignIn.SignIn(dataModel.EmailForClient, dataModel.PasswordBase);
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);
            restaurantsPage.WaitAndClickJonsonMenu(dataModel.TimeToWait);
            menuPage = GetMenuPage();
        }

        [Test]
        [Category("(ca) Possibility to add product in the cart from restaurant menu")]
        [Category("Smoke")]
        public void CheckPosibilityToMakeOrder()
        {
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);
            menuPage.WaitForItemAddedPopUp(dataModel.TimeToWait);
            var expectPopUp = dataModel.ItemAddedPopUp;
            var actualPopUp = menuPage.GetTextFromItemAddedPopUp();
            StringAssert.Contains(expectPopUp, actualPopUp, "Problems with ItemAddedPopUp");
        }

        [Test]
        [Category("(ca) Possibility to add product in the cart from restaurant menu")]
        public void CheckPosibilityToBuyNegativeNumberDish()
        {
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);
            menuPage.ClearInputItemQuantity();
            menuPage.SendKeysToInputItemQuantity(dataModel.InputNegativeQuantity);
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity11;
            var actualQuantity = menuPage.MenuOrderItemsListComponent.GetValueFromItemQuantityInCart();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }

        [Test]
        [Category("(ca) Possibility to add product in the cart from restaurant menu")]
        public void CheckPosibilityToWriteSymbolsInNumberDish()
        {
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);
            menuPage.ClearInputItemQuantity();
            menuPage.SendKeysToInputItemQuantity(dataModel.InputSymblosInQuantity);
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity1;
            var actualQuantity = menuPage.MenuOrderItemsListComponent.GetValueFromItemQuantityInCart();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }

        [Test]
        [Category("(ca) Possibility to add product in the cart from restaurant menu")]
        public void CheckPosibilityIncraseQuantity()
        {
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);
            menuPage.ClearInputItemQuantity();
            menuPage.IncreaseItemQuantity();
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity2;
            var actualQuantity = menuPage.MenuOrderItemsListComponent.GetValueFromItemQuantityInCart();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }

        [Test]
        [Category("(ca) Possibility to add product in the cart from restaurant menu")]
        public void CheckPosibilityDecraseQuantity()
        {
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);
            menuPage.ClearInputItemQuantity();
            menuPage.DecreaseItemQuantity();
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity1;
            var actualQuantity = menuPage.MenuOrderItemsListComponent.GetValueFromItemQuantityInCart();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteFromOrderAssociationByEmail, dataModel.EmailForClient);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteFromDraftOrderByEmail, dataModel.EmailForClient);
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForClient);
        }
    }
}
