using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace MeDirect_FrontendComponentTest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }
        

        [BeforeScenario("@runsWithTag")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            objectContainer.RegisterInstanceAs(driver);
        }


        /*
        [BeforeStep]
        public void AfterStep()
        {
            Thread.Sleep(2000);
        }
        */


        [AfterScenario]
        public void AfterScenario()
        {
            var driver = objectContainer.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}