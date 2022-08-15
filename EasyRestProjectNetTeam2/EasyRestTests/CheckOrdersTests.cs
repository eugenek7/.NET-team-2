using EasyRestProjectNetTeam2.EasyRestPages;
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
            restaurantsPage = GetRestaurantsPage();
            restaurantsPage.WaitAndClickResturantList(dataModel.TimeToWait);           
            restaurantsPage.WaitAndClickJonsonMenu(dataModel.TimeToWait);            
            menuPage = GetMenuPage();
        }

        [Test, Order (1)]
        public void CheckPosibilityToMakeOrder()
        {                     
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);
            menuPage.WaitForitemAddedPopUp(dataModel.TimeToWait);
            var expectPopUp = dataModel.ItemAddedPopUp;
            var actualPopUp = menuPage.GetTextFromItemAddedPopUp();
            StringAssert.Contains(expectPopUp, actualPopUp, "Problems with ItemAddedPopUp");
        }

        [Test, Order(2)]
        public void CheckPosibilityToBuyNegativeNumberDish()
        {            
            menuPage.WaitForInputItemQuantity(dataModel.TimeToWait);      
            menuPage.ClearInputItemQuantity();
            menuPage.SendKeysToInputItemQuantity(dataModel.InputNegativeQuantity);
            menuPage.WaitAndClickAddToCartButton(dataModel.TimeToWait);            
            menuPage.MenuOrderItemsListComponent.MoveToCart();
            menuPage.MenuOrderItemsListComponent.WaitForItemQuantityInTheCart(dataModel.TimeToWait);
            var expectQuantity = dataModel.ItemQuantity11;
            var actualQuantity = menuPage.MenuOrderItemsListComponent.GetValueFromItemQuantityInCart();
            StringAssert.Contains(expectQuantity, actualQuantity, "Problems with ItemQuantity");
        }

        [Test, Order(3)]
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

        [Test, Order(4)]
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

        [Test, Order(5)]
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
         public override void TearDown()
        {
            menuPage.MenuOrderItemsListComponent.WaitForCart(dataModel.TimeToWait);
            menuPage.MenuOrderItemsListComponent.MoveToCart();            
            menuPage.MenuOrderItemsListComponent.WaitAndClickRemoveItemButton(dataModel.TimeToWait);   
            DatabaseManager.SendNonQuery(queryDataModel.DeleteTokenByEmail, dataModel.EmailForClient);
            base.TearDown();                  
        }
    }
}
