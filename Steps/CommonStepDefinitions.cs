namespace Task5_0.Steps
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;

        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to url")]
        public void GivenINavigateToUrl()
        {
            AqualityServices.Browser.GoTo(ConfigReader.GetValue<string>("url"));
        }

        [When(@"I update start time of each test saved as '([^']*)'")]
        public void WhenIUpdateStartTimeOfEachTestSavedAs(string selectedTests)
        {
            var tests = (List<Test>)scenarioContext[selectedTests];
            tests.ForEach(x => x.Start_Time = DateTime.Now);
            tests.ForEach(x => x.Id = 0);
            scenarioContext[selectedTests] = tests;
        }
    }
}
