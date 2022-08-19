using EasyRestProjectNetTeam2.EasyRestPages;
using OpenQA.Selenium;

namespace EasyRestProjectNetTeam2.Facades
{
    public class FacadeForSignIn
    {
        private readonly  SignInPage signInPage;
        private readonly HomePage homePage;

        public FacadeForгSignIn(IWebDriver driver)
        {
            signInPage = new SignInPage(driver);
            homePage = new HomePage(driver);
        }

        public void  SignIn(string Email, string Password)
        {
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage.SendKeysToInputEmail(Email);
            signInPage.SendKeysToInputPassword(Password);
            signInPage.HeaderMenuComponent.ClickSignInButton();
        } 
        
        
    }
}