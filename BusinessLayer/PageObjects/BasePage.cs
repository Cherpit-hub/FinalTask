using OpenQA.Selenium;

namespace BusinessLayer.PageObjects
{
    public abstract class BasePage

    {

        protected readonly IWebDriver _driver;

        protected BasePage(IWebDriver driver)

        {

            _driver = driver ?? throw new ArgumentNullException(nameof(driver));

        }

        protected IWebElement FindElement(By locator)

        {

            return _driver.FindElement(locator);

        }

        public void NavigateTo(string url)

        {

            _driver.Navigate().GoToUrl(url);

        }

    }
}
