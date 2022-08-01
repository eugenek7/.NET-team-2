using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class Template : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        PersonalInfoPage personalInfoPage;


      
        [Test]
        public void CheckThatLoginWithGoogleButtonSendUserToGooglePageTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickGoogleButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.GooglePageUrlSearchWords), "Search word is absent on Google page URL");
            string result = DatabaseManager.SendQuery(queryDataModel.SelectUserEmailByEmail, dataModel.FakeEmail);
        }

     

    }
}
