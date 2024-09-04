using AutomationSeleniumChorme;

using var quotes = new QuotesWebDriver();

quotes.Login("gabriel", "Oliveira");

var listQuotes = quotes.GetQuotes();
var listQuotesTree = quotes.GetQuotes("3");

foreach (var item in listQuotes.Union(listQuotesTree))
{
    var message = $"Title: {item.Title} \n";
    message += $"Author: {item.Author} \n";
    message += $"Tags: {string.Join(", ", item.Tags)} \n";
}


//link pro robo acessar: https://quotes.toscrape.com/