using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SpecFlowProject1.Drivers
{
    public class Drivers
    {

        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public const string _siteUrl = "http://localhost:3000/";

        public Drivers(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        public IWebDriver SetUp()
        {
            driver = new ChromeDriver();
            _scenarioContext.Set(driver, "Webdriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_siteUrl);
            return driver;
        }       
    }
}
