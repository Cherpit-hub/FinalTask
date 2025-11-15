using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CoreLayer.WebDriver
{
    public interface IAbstractFactory
    {
        IWebDriver CreateFirefox();

        IWebDriver CreateChrome();
    }
    public class WebDriverFactory : IAbstractFactory
    {
        private readonly TestConfig _testConfig = new TestConfig();
        public IWebDriver CreateChrome()
        {
            var browserInfo = _testConfig.GetBrowserInfo("Chrome");
            var options = new ChromeOptions();
            options.AddArguments($"{browserInfo.Options}");
            options.AddArgument("--start-maximized");
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(options);
        }

        public IWebDriver CreateFirefox()
        {
            var browserInfo = _testConfig.GetBrowserInfo("Firefox");
            var options = new FirefoxOptions();
            options.AddArgument($"{browserInfo.Options}");
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(options);
        }
    }
}
