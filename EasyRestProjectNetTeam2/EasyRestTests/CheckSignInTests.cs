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


        [Test]
        public void CheckUserSignInAndLogOutTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysEmail(dataModel.Email);
            signInPage.SendKeysPassword(dataModel.Password);
            signInPage.HeaderMenuComponent.ClickSignInButton();
            homePage.WaitElementIsClickable(dataModel.TimeToWait, homePage.HeaderMenuComponent.GetProfileIcon());
            homePage.HeaderMenuComponent.ClickProfileIcon();
            homePage.WaitElementIsClickable(dataModel.TimeToWait, homePage.HeaderMenuComponent.GetMyProfileMenu());
            homePage.HeaderMenuComponent.ClickMyProfileMenu();
            personalInfoPage = GetPersonalInfoPage();
            personalInfoPage.WaitVisibilityOfElement(dataModel.TimeToWait, personalInfoPage.GetInputEmail());
            Assert.AreEqual(dataModel.Email, personalInfoPage.GetTextFromEmailField());
            personalInfoPage.HeaderMenuComponent.ClickProfileIcon();
            personalInfoPage.HeaderMenuComponent.ClickLogOutButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.SignInPageUrlSearchWords));
        }

        [Test]
        public void CheckUserLoginWithWrongEmailTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysEmail(dataModel.FakeEmail);
            signInPage.SendKeysPassword(dataModel.Password);
            signInPage.HeaderMenuComponent.ClickSignInButton();
            signInPage.WaitVisibilityOfElement(dataModel.TimeToWait, signInPage.GetWarningWindow());
            Assert.IsTrue(signInPage.GetTextFromWarningWindow().Contains(dataModel.WarningMessage));

        }

        [Test]
        public void CheckThatLoginWithGoogleButtonSendUserToGooglePageTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickGoogleButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.GooglePageUrlSearchWords));

        }

        [Test]
        public void CheckCreateAccountButtonTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickCreateAccountButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.SignUpPageUrlSearchWords));

        }
        [Test]
        public void CheckEmailFieldValidationUserSideTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.SendKeysEmail(dataModel.IncompleteEmail);
            signInPage.WaitVisibilityOfElement(dataModel.TimeToWait, signInPage.GetValidationWarningString());
            Assert.AreEqual(dataModel.EmailvalidationWarningMessage, signInPage.GetTextFromValidationWarningString());

        }

    }
}
