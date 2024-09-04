using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationSeleniumChorme
{
    internal class QuotesWebDriver : IDisposable
    {
        private readonly IWebDriver _driver;

        public QuotesWebDriver()
        {
            _driver = new ChromeDriver();
        }

        public void Login(string username, string password)
        {
            _driver.Navigate().GoToUrl("https://quotes.toscrape.com/");

            _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/p/a")).Click();

            _driver.FindElement(By.Id("username")).SendKeys(username);
            _driver.FindElement(By.Id("password")).SendKeys(password);
            _driver.FindElement(By.XPath("/html/body/div/form/input[2]")).Click();


            //_driver.Close();
        }

        public List<Quotes> GetQuotes(string numberPage = "1")
        {
            var quotesList = new List<Quotes>();

            _driver.Navigate().GoToUrl($"https://quotes.toscrape.com/page/{numberPage}/");

            var elementsQuotes = _driver.FindElements(By.ClassName("quote"));
            foreach (var elementQuote in elementsQuotes)
            {
                var quotes = new Quotes();

                quotes.Title = elementQuote.FindElement(By.ClassName("text")).Text;
                quotes.Author = elementQuote.FindElement(By.ClassName("author")).Text;

                var elementTags = elementQuote.FindElements(By.ClassName("tag"));
                foreach (var tag in elementTags)
                {
                    quotes.Tags.Add(tag.Text);
                }

                quotesList.Add(quotes);
            }

            return quotesList;
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
