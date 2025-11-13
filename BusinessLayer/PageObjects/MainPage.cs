using OpenQA.Selenium;

namespace BusinessLayer.PageObjects
{
    public class MainPage
    {
        private readonly IWebDriver _driver;
        private readonly By _titleLocator = By.CssSelector("div[class *= 'header'] div[class*=logo]");
        public MainPage(IWebDriver driver) => _driver = driver ?? throw new ArgumentException("Driver is null", nameof(driver));
        public string GetTitle()
        {
            return _driver.FindElement(_titleLocator).Text;
        }
    }
}
