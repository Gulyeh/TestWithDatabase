namespace Task5_0.Steps
{
    [Binding]
    public class DatabaseStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;

        public DatabaseStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [Given(@"I select no more than (.*) tests with repeatitve digits and save as '([^']*)'")]
        public async Task GivenISelectNoMoreThanTestsWithRepeatitveDigitsAndSaveAs(int maxTests, string selectedTests)
        {
            scenarioContext[selectedTests] = await DatabaseUtils.GetTwoRepeatingDigitsInIdRecords<Test>(maxTests);
        }


        [When(@"I get amount of current rows in test table and save as '([^']*)'")]
        public async Task WhenIGetAmountOfCurrentRowsInTestTableAndSaveAs(string amountOfRows)
        {
            scenarioContext[amountOfRows] = await DatabaseUtils.GetAmountOfRows<Test>();
        }

        [When(@"I insert updated tests saved as '([^']*)' to database")]
        public async Task WhenIInsertUpdatedTestsSavedAsToDatabase(string selectedTests)
        {
            var tests = (IEnumerable<Test>)scenarioContext[selectedTests];
            await DatabaseUtils.AddRangeToDatabase(tests);
            scenarioContext[selectedTests] = tests;
        }

        [Then(@"Amount of existing rows in test table equals amount saved as '([^']*)' adjusted by amount of tests saved as '([^']*)'")]
        public async Task ThenAmountOfExistingRowsInTestTableEqualsAmountSavedAsAdjustedByAmountOfTestsSavedAs(string amountOfRows, string selectedTests)
        {
            var rows = (int)scenarioContext[amountOfRows];
            var tests = (IEnumerable<Test>)scenarioContext[selectedTests];
            var actualRowsCount = await DatabaseUtils.GetAmountOfRows<Test>();
            Assert.AreEqual(actualRowsCount, rows + tests.Count(), "Rows counts are not equal");
        }

        [When(@"I delete inserted records to database saved as '([^']*)' from database")]
        public async Task WhenIDeleteInsertedRecordsToDatabaseSavedAsFromDatabase(string selectedTests)
        {
            var tests = (IEnumerable<Test>)scenarioContext[selectedTests];
            await DatabaseUtils.RemoveRangeFromDatabase(tests);
        }

        [Then(@"Amount of existing records in database equals amount saved as '([^']*)'")]
        public async Task ThenAmountOfExistingRecordsInDatabaseEqualsAmountSavedAs(string amountOfRows)
        {
            var actualRowsCount = await DatabaseUtils.GetAmountOfRows<Test>();
            var rows = (int)scenarioContext[amountOfRows];
            Assert.AreEqual(actualRowsCount, rows, "Rows counts are not equal");
        }
    }
}