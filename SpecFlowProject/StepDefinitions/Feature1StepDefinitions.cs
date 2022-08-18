using EasyRestProjectNetTeam2.EasyRestPages;
using System;
using TechTalk.SpecFlow;
using EasyRestProjectNetTeam2.EasyRestTests;
using EasyRestProjectNetTeam2.Models;
using NUnit.Framework;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class Feature1StepDefinitions: BaseTest
    {

        HomePage homePage;
        SignInPage signInPage;
        PersonalInfoPage personalInfoPage;
        DataModel dataModel;
        BaseTest baseTest;

        //[Given(@"ResetSystem")]
        //public void GivenResetSystem()
        //{
        //    baseTest.SetUp();
        //}

        [Given(@"I click Sign in")]
        public void GivenIClickSignIn()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
        }

        [Given(@"I enter my email")]
        public void GivenIEnterMyEmail()
        {
            signInPage.SendKeysToInputEmail(dataModel.EmailForClient);
        }

        [Given(@"I enter my password")]
        public void GivenIEnterMyPassword()
        {
            signInPage.SendKeysToInputPassword(dataModel.PasswordForClient);
        }

        [Given(@"I click Sign In Button")]
        public void GivenIClickSignInButton()
        {
            signInPage.HeaderMenuComponent.ClickSignInButton();
        }

        [When(@"I navigate to my profile")]
        public void WhenINavigateToMyProfile()
        {
            homePage.HeaderMenuComponent.WaitForProfileIconIsClickable();
            homePage.HeaderMenuComponent.ClickProfileIcon();
            homePage.HeaderMenuComponent.WaitRolePanelButtonIsClickable();
            homePage.HeaderMenuComponent.ClickRolePanelButton();
        }

        [Then(@"I check my email in personal info")]
        public void ThenICheckMyEmailInPersonalInfo()
        {
            personalInfoPage.WaitInputEmailIsVisible(dataModel.TimeToWait);
            Assert.AreEqual(dataModel.EmailForClient, personalInfoPage.GetTextFromEmailField(), "Emails are not equals");
        }
    }
}
