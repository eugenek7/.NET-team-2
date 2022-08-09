using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using EasyRestProjectNetTeam2.Models;
using NUnit.Framework;
namespace EasyRestProjectNetTeam2.EasyRestTests
{
    [TestFixture] 
    class CheckSignUpWithQueryTests : BaseTest
    {
        HomePage _homePage;
        SignUpPage _signUpPage;
        
        [SetUp]
        public  void SetUp()
        {
            _homePage = GetHomePage();
            _homePage.HeaderMenuComponent.ClickSignUpButton();
            _signUpPage = GetSignUpPage();
        }
        
        [Test]
        public void CheckUserIsAbleToSignUpWithLettersInPhoneNumber()
        {
            _signUpPage.SendKeysToInputName(dataModel.NameForSignUp);
            _signUpPage.SendKeysToInputEmail(dataModel.EmailForSignUp);
            _signUpPage.SendKeysToInputPhoneNumber(dataModel.LettersInPhoneNumber);
            _signUpPage.SendKeysToInputPassword(dataModel.PasswordForSignUp);
            _signUpPage.SendKeysToInputConfirmPassword(dataModel.PasswordForSignUp);
            _signUpPage.ClickToInputBirthDate();
            _signUpPage.DatePickerComponent.ChooseDateFromDatePicker(dataModel.BirthDateSignUp);
            _signUpPage.ClickCreateAccountButton();
            var query = "SELECT email FROM users WHERE email = 'tesh@gmail.com';";
            var expectedResult = DatabaseManager.SendQuery(query, dataModel.EmailForSignUp);
           Assert.AreNotEqual(null, expectedResult, "User is unable to sign up with invalid phone number");
        }

        [TearDown]
        public void TearDown()
        {
            //var query = "DELETE FROM users WHERE email='{0}'";
           // DatabaseManager.SendNonQuery(query);
           DatabaseManager.SendNonQuery(QueryDataModel.DeleteUserByEmail);
        }

    }
}