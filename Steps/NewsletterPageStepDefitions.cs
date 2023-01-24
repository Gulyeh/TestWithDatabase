namespace Task5_0.Steps
{
    [Binding]
    public class NewsletterPageStepDefitions
    {
        private readonly NewsletterPage newsletterPage;
        public NewsletterPageStepDefitions()
        {
            newsletterPage = new NewsletterPage();
        }

        [Then(@"Newsletter page is opened")]
        public void ThenNewsletterPageIsOpened()
        {
            Assert.IsTrue(newsletterPage.State.IsDisplayed, "Newsletter page is not opened");
        }
    }
}