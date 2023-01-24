namespace Task5_0.Steps
{
    [Binding]
    public class MainPageStepDefinitions
    {
        private readonly MainPage mainPage;
        public MainPageStepDefinitions()
        {
            mainPage = new MainPage();
        }

        [Then(@"Main page is opened")]
        public void ThenMainPageIsOpened()
        {
            Assert.IsTrue(mainPage.State.IsDisplayed, "Main page is not opened");
        }

        [When(@"I click Games button")]
        public void WhenIClickGamesButton()
        {
            mainPage.WaitAndClickGamesButton();
        }

        [When(@"I click Newsletter button")]
        public void WhenIClickNewsletterButton()
        {
            mainPage.WaitAndClickNewsletterButton();
        }

        [When(@"I accept cookies")]
        public void WhenIAcceptCookies()
        {
            mainPage.WaitAndClickAcceptCookiesButton();
        }

    }
}