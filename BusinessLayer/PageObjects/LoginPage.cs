using CoreLayer;
using OpenQA.Selenium;

namespace BusinessLayer.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameLocator = By.CssSelector("input[name *= 'user-name']");
        private readonly By _passwordLocator = By.CssSelector("input[name *= 'password']");
        private readonly By _loginButtonLocator = By.CssSelector("input[name *= 'login'][type = 'submit']");
        private readonly By _errorLocator = By.CssSelector("div[class*='error'][class*='container'] h3");

        public LoginPage(IWebDriver driver) : base(driver) 
        {
            NavigateTo(new TestConfig().GetApplicationLink());
        }

        public LoginPage EnterCredentials(string username, string password)
        {
            FindElement(_usernameLocator).SendKeys(username);
            FindElement(_passwordLocator).SendKeys(password);
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
            return FindElement(_errorLocator).Text;
        }
    }
}
