using CoreLayer;
using OpenQA.Selenium;
using Serilog;

namespace BusinessLayer.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private static string Url { get; } = "https://www.saucedemo.com/";
        private readonly By _usernameLocator = By.CssSelector("#user-name");
        private readonly By _passwordLocator = By.CssSelector("#password");
        private readonly By _loginButtonLocator = By.CssSelector("#login-button");
        private readonly By _errorLocator = By.CssSelector(".error-message-container h3");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentException("Driver is null", nameof(driver));
            _driver.Navigate().GoToUrl(Url);
        }

        public LoginPage EnterCredentials(string username, string password)
        {
            var handlerChain = new SendKeysHandler(username);
            handlerChain.SetNext(new SendKeysHandler(password));
            handlerChain.Handle(_driver, _usernameLocator);
            handlerChain.Handle(_driver, _passwordLocator);
            Log.Information("Username after input is {Username}", _driver.FindElement(_usernameLocator).GetAttribute("value"));
            Log.Information("Password after input is {Psername}", _driver.FindElement(_passwordLocator).GetAttribute("value"));
            return this;
        }
        public LoginPage ClearUsername()
        {
            var clear = new ClearInputHandler();
            clear.Handle(_driver,_usernameLocator);
            Log.Information("Username after clearing is {Username}", _driver.FindElement(_usernameLocator).GetAttribute("value"));
            return this;
        }
        public LoginPage ClearPassword()
        {
            var clear = new ClearInputHandler();
            clear.Handle(_driver, _passwordLocator);
            Log.Information("Password after clearing is {Password}", _driver.FindElement(_passwordLocator).GetAttribute("value"));
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
            Log.Information("Error message: {ErrorMessage}", _driver.FindElement(_errorLocator).Text);
            return _driver.FindElement(_errorLocator).Text;
        }
    }
}
