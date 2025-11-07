using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace CoreLayer.WebDriver
{
    public interface IAbstractFactory
    {
        IWebDriver CreateFirefox();

        IWebDriver CreateChrome();
    }
    public class WebDriverFactory : IAbstractFactory
    {
        public IWebDriver CreateChrome()
        {
            var options = new ChromeOptions();
            options.AddArguments("--headless","--start-maximized");
            return new ChromeDriver(options);
        }

        public IWebDriver CreateFirefox()
        {
            var options = new FirefoxOptions();
            options.AddArguments("--headless", "--start-maximized");
            return new FirefoxDriver(options);
        }
    }
}
