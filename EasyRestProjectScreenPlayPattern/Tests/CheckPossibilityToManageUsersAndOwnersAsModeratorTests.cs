using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoaConstrictorTestProject.Interactions.Questions;
using BoaConstrictorTestProject.Interactions.Tasks;
using BoaConstrictorTestProject.Pages;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace BoaConstrictorTestProject.Tests
{
    public class CheckPossibilityToManageUsersAndOwnersAsModeratorTests
    {
        private IActor moderator;
        private const string _moderatorEmail = "petermoderator@test.com";
        private const string _password = "1";


        [SetUp]
        public void InitializeScreenplay()
        {
            moderator = new Actor(name: "Stepan", logger: new ConsoleLogger());
            moderator.Can(BrowseTheWeb.With(new ChromeDriver()));
            moderator.AttemptsTo(Navigate.ToUrl(HomePage.Url));
            moderator.AttemptsTo(task: MaximizeWindow.ForBrowser());
            moderator.AttemptsTo(SignIn.WithEmailAndPassword(_moderatorEmail, _password));
        }

        [TearDown]
        public void QuitBrowser()
        {
            moderator.AttemptsTo(QuitWebDriver.ForBrowser());
        }


        [Test, Order(1)]
        public void CheckPossibilityBanActiveUserAsModeratorTest()
        {
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.UsersButton));
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.ActiveButton));
            var nameOfFirstActiveUser = moderator.AskingFor(KeepInMind.NameOfFirstUserFrom(ModeratorManagePage.NamesFields));
            moderator.AttemptsTo(Add.PersonInBanListByClicking(ModeratorManagePage.BanOrUnbanButton));
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.BannedButton));
            var namesOfAllBannedUsers = moderator.AskingFor(Remember.AllInfoFrom(ModeratorManagePage.NamesFields));
            moderator.AskingFor(Verify.isTheSearWordPresentInTheList(nameOfFirstActiveUser, namesOfAllBannedUsers))
                .Should().BeTrue();
        }

        [Test, Order(2)]
        public void CheckPossibilityUnbanBannedUserAsModeratorTest()
        {
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.UsersButton));
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.BannedButton));
            var nameOfFirstBannedUser = moderator.AskingFor(KeepInMind.NameOfFirstUserFrom(ModeratorManagePage.NamesFields));
            moderator.AttemptsTo(Add.PersonInActiveListByClicking(ModeratorManagePage.BanOrUnbanButton));
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.ActiveButton));
            var namesOfAllActiveUsers = moderator.AskingFor(Remember.AllInfoFrom(ModeratorManagePage.NamesFields));
            moderator.AskingFor(Verify.isTheSearWordPresentInTheList(nameOfFirstBannedUser, namesOfAllActiveUsers))
                .Should().BeTrue();
        }

        [Test, Order(3)]
        public void CheckPossibilityBanActiveOwnerAsModeratorTest()
        {
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.OwnersButton));
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.ActiveButton));
            var nameOfFirstActiveOwner = moderator.AskingFor(KeepInMind.NameOfFirstOwnerFrom(ModeratorManagePage.NamesFields));
            moderator.AttemptsTo(Add.PersonInBanListByClicking(ModeratorManagePage.BanOrUnbanButton));
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.BannedButton));
            var namesOfAllBannedOwners = moderator.AskingFor(Remember.AllInfoFrom(ModeratorManagePage.NamesFields));
            moderator.AskingFor(Verify.isTheSearWordPresentInTheList(nameOfFirstActiveOwner, namesOfAllBannedOwners))
                .Should().BeTrue();
        }

        [Test, Order(4)]
        public void CheckPossibilityUnbanBannedOwnerAsModeratorTest()
        {
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.OwnersButton));
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.BannedButton));
            var nameOfFirstBannedOwner = moderator.AskingFor(KeepInMind.NameOfFirstOwnerFrom(ModeratorManagePage.NamesFields));
            moderator.AttemptsTo(Add.PersonInActiveListByClicking(ModeratorManagePage.BanOrUnbanButton));
            moderator.AttemptsTo(MoveForward.ByClicking(ModeratorManagePage.ActiveButton));
            var namesOfAllActiveOwners = moderator.AskingFor(Remember.AllInfoFrom(ModeratorManagePage.NamesFields));
            moderator.AskingFor(Verify.isTheSearWordPresentInTheList(nameOfFirstBannedOwner, namesOfAllActiveOwners))
                .Should().BeTrue();
        }
    }
}
