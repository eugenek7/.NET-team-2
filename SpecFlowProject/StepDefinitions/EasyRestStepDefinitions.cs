using EasyRestSpecFlow.Pages;
using TechTalk.SpecFlow;

namespace EasyRestProjectSpecflow.Steps
{
    [Binding]
    public sealed class EasyRestStepDefinitions
    {

        private readonly HomePage _homePage;
        private readonly SignInPage _signInPage;

        public EasyRestStepDefinitions(HomePage homePage, SignInPage signInPage)
        {
            _homePage = homePage;
            _signInPage = signInPage;
        }

        [Given(@"a user is signed in with '(.*)' and '(.*)'")]
        public void GivenAUserIsSignedInWithAnd(string email, string password)
        {
            _homePage.ClickSignInButton();
            _signInPage.SendKeysToInputEmail(email);
            _signInPage.SendKeysToInputPassword(password);
            _signInPage.ClickSignInButton();
        }

    }
}