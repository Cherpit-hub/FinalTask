using CoreLayer;
using OpenQA.Selenium;
using Serilog;

namespace BusinessLayer.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly TestConfig _testConfig = new();
        private readonly By _usernameLocator = By.CssSelector("input[name *= 'user-name']");
        private readonly By _passwordLocator = By.CssSelector("input[name *= 'password']");
        private readonly By _loginButtonLocator = By.CssSelector("input[name *= 'login'][type = 'submit']");
        private readonly By _errorLocator = By.CssSelector("div[class*='error'][class*='container'] h3");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentException("Driver is null", nameof(driver));
            _driver.Navigate().GoToUrl(_testConfig.GetApplicationLink());
        }

        public LoginPage EnterCredentials(string username, string password)
        {
            var handlerChain = new SendKeysHandler(username);
            handlerChain.SetNext(new SendKeysHandler(password));
            handlerChain.Handle(_driver, _usernameLocator);
            handlerChain.Handle(_driver, _passwordLocator);
            return this;
        }
        public LoginPage ClearUsername()
        {
            var clear = new ClearInputHandler();
            clear.Handle(_driver,_usernameLocator);
            return this;
        }
        public LoginPage ClearPassword()
        {
            var clear = new ClearInputHandler();
            clear.Handle(_driver, _passwordLocator);
            return this;
        }
        public LoginPage ClickLoginInvalid()
        {
            var click = new ClickHandler();
            click.Handle(_driver, _loginButtonLocator);
            return this;
        }
        public MainPage ClickLoginValid()
        {
            var click = new ClickHandler();
            click.Handle(_driver, _loginButtonLocator);
            return new MainPage(_driver);
        }
        public string GetErrorMessage()
        {
            return _driver.FindElement(_errorLocator).Text;
        }
    }
}
