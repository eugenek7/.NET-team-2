using EasyRestProjectNetTeam2.EasyRestPages;

namespace EasyRestProjectNetTeam2.Facades
{
    public class BaseSignIn
    {
        private readonly  SignInPage signInPage;
        private readonly HomePage homePage;

        public BaseSignIn(SignInPage signInPage, HomePage homePage)
        {
            this.signInPage = signInPage;
            this.homePage = homePage;
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