namespace Task5_0.Utils
{
    public static class LogsUtils
    {
        public static async Task AddTestResultToDb()
        {
            var failureMessage = TestContext.CurrentContext.Result.Message;
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var logs = new Log();

            switch (status)
            {
                case TestStatus.Passed:
                    logs.Is_Exception = false;
                    break;
                default:
                    logs.Is_Exception = true;
                    logs.Content = failureMessage is null ? string.Empty : failureMessage;
                    break;
            }

            var randomTests = await DatabaseUtils.GetRandomRecords<Test>(1);
            logs.Test_Id = randomTests.First().Id;
            await DatabaseUtils.AddToDatabase(logs);
        }
    }
}