namespace Task5_0.Pages
{
    public class NewsletterPage : Form
    {
        public NewsletterPage() : base(By.XPath("//section[contains(@id, 'cpt-newletters-archive')]"), "Newsletter")
        {

        }
    }
}