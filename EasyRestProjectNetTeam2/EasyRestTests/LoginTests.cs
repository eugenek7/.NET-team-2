
using EasyRestProjectNetTeam2.EasyRestPages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class LoginTests : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        PersonalInfoPage personalInfoPage;

        private const string Email = "katiedoyle@test.com";
        private const string Password = "1111";
        private const int TimeToWait = 10;
        private const string FakeEmail = "stepanbandera@test.com";
        private const string WarningMessage = "Email or password is invalid";
        private const string SearchWords = "google.com";
        private const string IncompleteEmail = "stepanbandera@test"; 
        private const string EmailvalidationWarningMessage = "Email is not valid";
        private const string SignInUrlSearchWords = "log-in";

        [Test]
        public void CheckUserSignInTest()
        {
            homePage = GetHomePage();
            homePage.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysEmail(Email);
            signInPage.SendKeysPassword(Password);
            signInPage.ClickSignInButton();
            homePage.WaitElementIsClicable(TimeToWait, homePage.GetProfileIcon());
            homePage.ClickProfileIcon();
            homePage.WaitElementIsClicable(TimeToWait, homePage.GetMyProfileMenu());
            homePage.ClickMyProfileMenu();
            personalInfoPage = GetPersonalInfoPage();
            personalInfoPage.WaitVisibilityOfElement(TimeToWait, personalInfoPage.GetInputEmail());
            Assert.AreEqual(personalInfoPage.GetTextFromEmailField(), Email);
            personalInfoPage.ClickProfileIcon();
            personalInfoPage.ClickLogOutButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(SignInUrlSearchWords));
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
            Assert.IsTrue(signInPage.GetPageUrl().Contains(SearchWords));

        }
        [Test]
        public void CheckEmailFieldValidationUserSideTest()
        {
            homePage = GetHomePage();
            homePage.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysEmail(IncompleteEmail);
            signInPage.WaitVisibilityOfElement(TimeToWait, signInPage.GetValidationWarningString());
            Assert.AreEqual(signInPage.GetTextFromValidationWarningString(), EmailvalidationWarningMessage);

        }
    }
}
