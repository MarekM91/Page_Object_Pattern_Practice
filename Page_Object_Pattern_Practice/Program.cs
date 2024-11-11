using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Page_Object_Pattern_Practice.Pages;

IWebDriver driver = new ChromeDriver();

try
{
    var page = new Page(driver);

    page.Open().Paste("Hello from WebDriver", "helloweb");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    driver.Quit();
}