using OpenQA.Selenium;


namespace Page_Object_Pattern_Practice.Pages
{
    internal class Page
    {
        private static string Url { get; } = "https://pastebin.com/";

        private readonly IWebDriver driver;

        public Page(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public Page Open()
        {
            driver.Url = Url;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return this;
        }

        public void Paste(string text, string name)
        {
            IWebElement cookiesButton = driver.FindElement(By.XPath("//button[span[text()='AGREE']]"));
            cookiesButton.Click();

            IWebElement newPasteField = driver.FindElement(By.Id("postform-text"));
            newPasteField.Click();
            newPasteField.SendKeys(text);

            IWebElement pasteExpirationField = driver.FindElement(By.Id("select2-postform-expiration-container"));
            pasteExpirationField.Click();

            IWebElement highlightedExpirationOption = driver.FindElement(By.XPath("//li[contains(@class, 'select2-results__option') and text()='10 Minutes']"));
            highlightedExpirationOption.Click();

            IWebElement pasteName = driver.FindElement(By.Id("postform-name"));
            pasteName.Click();
            pasteName.SendKeys(name);

            IWebElement savePaste = driver.FindElement(By.XPath("//button[text()='Create New Paste']"));
            savePaste.Click();
        }
    }
}
