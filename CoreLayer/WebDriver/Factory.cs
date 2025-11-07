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
            return new ChromeDriver();
        }

        public IWebDriver CreateFirefox()
        {
            return new FirefoxDriver();
        }
    }
}
