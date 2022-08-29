using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Facades;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckSignInTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        PersonalInfoPage personalInfoPage;
        BaseSignIn baseSignIn;


        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckUserSignInAndLogOutTest()
        {
            signInPage = GetSignInPage();
            homePage = GetHomePage();
            baseSignIn = new BaseSignIn(signInPage, homePage);
            baseSignIn.SignIn(dataModel.EmailForClient, dataModel.PasswordBase);
            homePage.HeaderMenuComponent.ClickSignInButton();
            homePage.HeaderMenuComponent.WaitForProfileIconIsClickable();
            homePage.HeaderMenuComponent.ClickProfileIcon();
            homePage.HeaderMenuComponent.WaitRolePanelButtonIsClickable();
            homePage.HeaderMenuComponent.ClickRolePanelButton();
            personalInfoPage = GetPersonalInfoPage();
            personalInfoPage.WaitInputEmailIsVisible(dataModel.TimeToWait);
            Assert.AreEqual(dataModel.EmailForClient, personalInfoPage.GetTextFromEmailField(), "Emails are not equals");
            personalInfoPage.HeaderMenuComponent.ClickProfileIcon();
            personalInfoPage.HeaderMenuComponent.ClickLogOutButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.SignInPageUrlSearchWords), "Search word is absent on SignIn page URL");
        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckUserLoginWithWrongEmailTest()
        {
            signInPage = GetSignInPage();
            homePage = GetHomePage();
            baseSignIn = new BaseSignIn(signInPage, homePage);
            baseSignIn.SignIn(dataModel.FakeEmail, dataModel.PasswordBase);
            signInPage.HeaderMenuComponent.ClickSignInButton();
            signInPage.WaitForWarningWindow();
            Assert.IsTrue(signInPage.GetTextFromWarningWindow().Contains(dataModel.WarningMessage), "Problems with warning window");

        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckThatLoginWithGoogleButtonSendUserToGooglePageTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickGoogleButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.GooglePageUrlSearchWords), "Search word is absent on Google page URL");

        }

        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckCreateAccountButtonTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickCreateAccountButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.SignUpPageUrlSearchWords), "Search word is absent on Sign up page URL");

        }
        [Test]
        [Category("(uu) Possibility to Sign in")]
        public void CheckEmailFieldValidationUserSideTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.IncompleteEmail);
            signInPage.WaitForLoginValidationWarningString();
            Assert.AreEqual(dataModel.EmailvalidationWarningMessage, signInPage.GetTextFromValidationWarningString(), "Problems with warning message");

        }

    }
}
