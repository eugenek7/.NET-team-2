using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckSignInTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        PersonalInfoPage personalInfoPage;


        [Test]
        public void CheckUserSignInAndLogOutTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.Email);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            signInPage.HeaderMenuComponent.ClickSignInButton();
            homePage.HeaderMenuComponent.WaitForProfileIconIsClickable();
            homePage.HeaderMenuComponent.ClickProfileIcon();
            homePage.HeaderMenuComponent.WaitMyProfileMenuIsClickable();
            homePage.HeaderMenuComponent.ClickMyProfileMenu();
            personalInfoPage = GetPersonalInfoPage();
            personalInfoPage.WaitInputEmailIsVisible();
            Assert.AreEqual(dataModel.Email, personalInfoPage.GetTextFromEmailField(), "Emails are not equals");
            personalInfoPage.HeaderMenuComponent.ClickProfileIcon();
            personalInfoPage.HeaderMenuComponent.ClickLogOutButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.SignInPageUrlSearchWords), "Search word is absent on SignIn page URL");
        }

        [Test]
        public void CheckUserLoginWithWrongEmailTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysToInputEmail(dataModel.FakeEmail);
            signInPage.SendKeysToInputPassword(dataModel.Password);
            signInPage.HeaderMenuComponent.ClickSignInButton();
            signInPage.WaitForWarningWindow();
            Assert.IsTrue(signInPage.GetTextFromWarningWindow().Contains(dataModel.WarningMessage), "Problems with warning window");

        }

        [Test]
        public void CheckThatLoginWithGoogleButtonSendUserToGooglePageTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickGoogleButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.GooglePageUrlSearchWords), "Search word is absent on Google page URL");

        }

        [Test]
        public void CheckCreateAccountButtonTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickCreateAccountButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.SignUpPageUrlSearchWords), "Search word is absent on Sign up page URL");

        }
        [Test]
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
