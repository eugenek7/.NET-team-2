using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using EasyRestProjectNetTeam2.EasyRestPages;
using EasyRestProjectNetTeam2.Helpers;
using EasyRestProjectNetTeam2.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;



namespace EasyRestProjectNetTeam2.EasyRestTests
{

    public class BaseTest 
    {
        static string pathToReport = Directory.GetParent(@"../../../").FullName
          + Path.DirectorySeparatorChar + "Reports"
          + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("ddMMyyyy HHmmss")
          /*+ "\\index.html"*/;
        static ExtentReports extent;
        ExtentTest test;
        protected DataModel dataModel;
       
        private IWebDriver driver;
        private const string _siteUrl = "http://localhost:3000/";


        [OneTimeSetUp]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(pathToReport);
            extent = new ExtentReports();
            extent.AttachReporter(htmlreport);
            
        }

         

        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Info($"Test {TestContext.CurrentContext.Test.Name} started");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_siteUrl);
            InitializeData();
        }


        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test complete with status: " + logstatus + stacktrace);
            extent.Flush();
            driver.Quit();
            
        }

        private void InitializeData()
        {
            dataModel =  new DataReader().ReadData();  
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }

        public HomePage GetHomePage()
        {
            return new HomePage(GetDriver());
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
    }
}
