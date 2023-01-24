namespace Task5_0.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario("TC1")]
        public void BeforeScenarioTC1()
        {
            AqualityServices.Browser.Maximize();
        }

        [AfterScenario("TC1")]
        public async Task AfterScenarioTC1()
        {
            AqualityServices.Browser.Quit();
            await LogsUtils.AddTestResultToDb();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            SqlDriver.Dispose();
        }

    }
}