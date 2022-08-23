using EasyRestSpecFlow.PageObject;
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

        [Given(@"I click Sign in")]
        public void GivenIClickSignIn()
        {
            _homePage.ClickSignInButton();
        }

        [Given(@"I enter my '(.*)'")]
        public void GivenIEnterMy(string email)
        {
            _signInPage.SendKeysToInputEmail(email);
        }

        [Given(@"I enter my password '(.*)'")]
        public void GivenIEnterMyPassword(string password)
        {
            _signInPage.SendKeysToInputPassword(password);
        }


        [Given(@"I click Sign In Button")]
        public void GivenIClickSignInButton()
        {
            _signInPage.ClickSignInButton();
        }
    }
}
