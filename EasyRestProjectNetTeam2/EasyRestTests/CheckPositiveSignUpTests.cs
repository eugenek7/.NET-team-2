using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using NUnit.Framework;

namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture]
    public class CheckPositiveSignUpTests : BaseTest
    {
        HomePage homePage;
        SignUpPage signUpPage;

        [Test]
        [Category("(uu) Possibility to Sign up")]
        public void CheckUserIsAbleToSignUpWithLettersInPhoneNumber()
        {
            homePage = GetHomePage();
            homePage.HeaderMenuComponent.ClickSignUpButton();
            signUpPage = GetSignUpPage();
            signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            signUpPage.SendKeysToInputPhoneNumber(dataModel.LettersInPhoneNumber);
            signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            signUpPage.SendKeysToInputConfirmPassword(dataModel.PasswordForSignUp);
            signUpPage.ClickCreateAccountButton();
            var actual = DatabaseManager.SendQuery(queryDataModel.SelectUserEmailByEmail, dataModel.EmailForSignUp);
            var expected = dataModel.EmailForSignUp;
            Assert.AreEqual(expected, actual, "User is unable to sign up with invalid phone number");
        }

        [TearDown]
        public override void TearDown()
        {
            DatabaseManager.SendNonQuery(queryDataModel.DeleteUserByEmail, dataModel.EmailForSignUp);
            base.TearDown();
        }

    }
}

