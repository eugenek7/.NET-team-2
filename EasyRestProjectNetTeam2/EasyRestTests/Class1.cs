using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    class Class1 : BaseTest
    {
        HomePage homePage;
        SignInPage signInPage;
        string query1 = "DELETE FROM users WHERE email='eugene@test.com';";
        string query2 = "INSERT INTO users (email) VALUES ('eugene@test.com');";


        [Test]
        public void CheckThatLoginWithGoogleButtonSendUserToGooglePageTest()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignInButton();
            signInPage = GetSignInPage();
            signInPage.ClickGoogleButton();
            Assert.IsTrue(signInPage.GetPageUrl().Contains(dataModel.GooglePageUrlSearchWords));
            DatabaseManager.SendNonQuery(query2);
            DatabaseManager.SendNonQuery(query1);
        }


    }
}
