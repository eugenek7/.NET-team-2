using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using EasyRestProjectNetTeam2.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace EasyRestProjectNetTeam2.EasyRestTests
{

    public class BaseTest
    {
        static string pathToReport = Directory.GetParent(@"../../../").FullName
          + Path.DirectorySeparatorChar + "Reports"
          + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("ddMMyyyy HHmmss")
          /*+ "\\index.html"*/;
        static ExtentReports extent = new ExtentReports();
        ExtentTest test;
        protected DataModel dataModel;
        protected QueryDataModel queryDataModel;

        protected IWebDriver driver;
        private const string _siteUrl = "http://localhost:3000/";


        [OneTimeSetUp]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(pathToReport);
            extent.AttachReporter(htmlreport);
        }


        [SetUp]
        public virtual void SetUp()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Info($"Test {TestContext.CurrentContext.Test.Name} started");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_siteUrl);
            InitializeData();
        }


        [TearDown]
        public virtual void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
            ? "" : string.Format("Error message: {0}", TestContext.CurrentContext.Result.Message);
            var context = TestContext.CurrentContext;
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    test.Log(logstatus, $"Test complete with status: {logstatus}");
                    test.Log(logstatus, errorMessage);
                    test.Log(logstatus, stacktrace);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    test.Log(logstatus, $"Test complete with status: {logstatus}");
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    test.Log(logstatus, $"Test complete with status: {logstatus}");
                    break;
                default:
                    logstatus = Status.Pass;
                    test.Log(logstatus, $"Test complete with status: {logstatus}");
                    break;
            }
            extent.Flush();
            driver.Quit();
        }

        private void InitializeData()
        {
            dataModel = new DataReader().ReadDataFromTestData();
            queryDataModel = new DataReader().ReadDataFromQueryData();
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }

        public HomePage GetHomePage()
        {
            return new HomePage(GetDriver());
        }
        public OrderHistoryPage GetOrderHistoryPage()
        {
            return new OrderHistoryPage(GetDriver());
        }
        public SignInPage GetSignInPage()
        {
            return new SignInPage(GetDriver());
        }
        public PersonalInfoPage GetPersonalInfoPage()
        {
            return new PersonalInfoPage(GetDriver());
        }
        public CurrentOrdersPage GetCurrentOrdersPage()
        {
            return new CurrentOrdersPage(GetDriver());
        }
        public MenuPage GetMenuPage()
        {
            return new MenuPage(GetDriver());
        }
        public RestaurantsPage GetRestaurantsPage()
        {
            return new RestaurantsPage(GetDriver());
        }
        public SignUpPage GetSignUpPage()
        {
            return new SignUpPage(GetDriver());
        }

        public ManageRestaurantsPage GetManageRestaurantsPage()
        {
            return new ManageRestaurantsPage(GetDriver());
        }

        public ManageAdministratorPage GetManageAdministratorPage()
        {
            return new ManageAdministratorPage(GetDriver());
        }

        public ManageWaitersPage GetManageWaitersPage()
        {
            return new ManageWaitersPage(GetDriver());
        }

        public ManageMenuPage GetManageMenuPage()
        {
            return new ManageMenuPage(GetDriver());
        }

        public WaiterPanelPage GetWaiterPanelPage()
        {
            return new WaiterPanelPage(GetDriver());
        }

        public ModeratorManagePage GetModeratorManagePage()
        {
            return new ModeratorManagePage(GetDriver());
        }
    }
}
