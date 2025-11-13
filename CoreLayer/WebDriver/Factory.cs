using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

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
            options.AddArgument("--headless");
            options.AddArgument("--start-maximized");
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(options);
        }

        public IWebDriver CreateFirefox()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(options);
        }
    }
}
