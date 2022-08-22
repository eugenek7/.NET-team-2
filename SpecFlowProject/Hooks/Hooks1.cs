using OpenQA.Selenium;
using SpecFlowProject1.Drivers;


[Binding]
public sealed class Hooks1
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks1(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

    [BeforeScenario]
    public void BeforeScenario()
    {
        Drivers driver = new Drivers(_scenarioContext);
        _scenarioContext.Set(driver, "Driver");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine("Driver quit");
        _scenarioContext.Get<IWebDriver>("Webdriver").Quit();
    }
}
