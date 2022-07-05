using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class CheckSignInTests : BaseTest 
    {
        HomePage homePage;
        SignInPage signInPage;
        PersonalInfoPage personalInfoPage;

        private const string Email = "katiedoyle@test.com";
        private const string Password = "1111";
        private const int TimeToWait = 10;
        private const string FakeEmail = "stepanbandera@test.com";
        private const string WarningMessage = "Email or password is invalid";
        private const string GooglePageUrlSearchWords = "google.com";
        private const string IncompleteEmail = "stepanbandera@test";
        private const string EmailvalidationWarningMessage = "Email is not valid";
        private const string SignInPageUrlSearchWords = "log-in";
        private const string SignUpPageUrlSearchWords = "sign-up";


        [Test]
        public void CheckUserSignInAndLogOutTest()
        {
            homePage = GetHomePage();
            homePage.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysEmail(Email);
            signInPage.SendKeysPassword(Password);
            signInPage.ClickSignInButton();
            homePage.WaitElementIsClickable(TimeToWait, homePage.GetProfileIcon());
            homePage.ClickProfileIcon();
            homePage.WaitElementIsClickable(TimeToWait, homePage.GetMyProfileMenu());
            homePage.ClickMyProfileMenu();
            personalInfoPage = GetPersonalInfoPage();
            personalInfoPage.WaitVisibilityOfElement(TimeToWait, personalInfoPage.GetInputEmail());
            Assert.AreEqual(Email, personalInfoPage.GetTextFromEmailField());
            personalInfoPage.ClickProfileIcon();
            personalInfoPage.ClickLogOutButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(SignInPageUrlSearchWords));
        }

        [Test]
        public void CheckUserLoginWithWrongEmailTest()
        {
            homePage = GetHomePage();
            homePage.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysEmail(FakeEmail);
            signInPage.SendKeysPassword(Password);
            signInPage.ClickSignInButton();
            signInPage.WaitVisibilityOfElement(TimeToWait, signInPage.GetWarningWindow());
            Assert.IsTrue(signInPage.GetTextFromWarningWindow().Contains(WarningMessage));

        }

        [Test]
        public void CheckThatLoginWithGoogleButtonSendUserToGooglePageTest()
        {
            homePage = GetHomePage();
            homePage.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickGoogleButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(GooglePageUrlSearchWords));

        }

        [Test]
        public void CheckCreateAccountButtonTest()
        {
            homePage = GetHomePage();
            homePage.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickCreateAccountButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(SignUpPageUrlSearchWords));

        }
        [Test]
        public void CheckEmailFieldValidationUserSideTest()
        {
            homePage = GetHomePage();
            homePage.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysEmail(IncompleteEmail);
            signInPage.WaitVisibilityOfElement(TimeToWait, signInPage.GetValidationWarningString());
            Assert.AreEqual(EmailvalidationWarningMessage, signInPage.GetTextFromValidationWarningString());

        }

    }
}
