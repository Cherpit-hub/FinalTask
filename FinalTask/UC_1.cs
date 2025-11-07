using BusinessLayer.PageObjects;
using CoreLayer;
using CoreLayer.WebDriver;
using FluentAssertions;
using OpenQA.Selenium;
using Serilog;
namespace FinalTask
{
    public class UC_1
    {
        private IWebDriver? _driver;

        public UC_1()
        {
            LogConfig.ConfigureLogger(); // Configure Serilog once
        }
        [Theory]
        [InlineData("Jimmy", "AAAAAAAA", "Firefox")]
        [InlineData("Jimmy", "AAAAAAAA", "Chrome")]

        public void Login_Empty_Credentials(string username, string password, string browserName)
        {
            switch (browserName.ToLower())
            {
                case "firefox":
                    _driver = new WebDriverFactory().CreateFirefox();
                    break;
                case "chrome":
                    _driver = new WebDriverFactory().CreateChrome();
                    break;
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
            Log.Information("Starting UC_1_Login_Empty_Credentials Test.");
            var loginPage = new LoginPage(_driver);
            try
            {
                loginPage
                    .EnterCredentials(username, password)
                    .ClearPassword()
                    .ClearUsername()
                    .ClickLoginInvalid()
                    .GetErrorMessage()
                    .Should()
                    .Contain("Username is required");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured during UC_1_Login_Empty_Credentials Test");
                throw;
            }
            finally
            {
                _driver.Quit();
                Log.Information("Finished UC_1_Login_Empty_Credentials Test");
                Log.CloseAndFlush();
            }
        }
    }
    public class UC_2
    {
        private IWebDriver? _driver;

        public UC_2()
        {
            LogConfig.ConfigureLogger(); // Configure Serilog once
        }
        [Theory]
        [InlineData("Jimmy", "AAAAAAAA", "Firefox")]
        [InlineData("Jimmy", "AAAAAAAA", "Chrome")]

        public void Login_Only_Username(string username, string password, string browserName)
        {
            switch (browserName.ToLower())
            {
                case "firefox":
                    _driver = new WebDriverFactory().CreateFirefox();
                    break;
                case "chrome":
                    _driver = new WebDriverFactory().CreateChrome();
                    break;
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
            Log.Information("Starting UC_2_Login_Only_Username Test.");
            var loginPage = new LoginPage(_driver);
            try
            {
                loginPage
                    .EnterCredentials(username, password)
                    .ClearPassword()
                    .ClickLoginInvalid()
                    .GetErrorMessage()
                    .Should()
                    .Contain("Password is required");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured during UC_2_Login_Only_Username Test");
                throw;
            }
            finally
            {
                _driver.Quit();
                Log.Information("Finished UC_2_Login_Only_Username Test");
                Log.CloseAndFlush();
            }
        }
    }
    public class UC_3
    {

        private IWebDriver? _driver;

        public UC_3()
        {
            LogConfig.ConfigureLogger(); // Configure Serilog once
        }
        [Theory]
        [InlineData("problem_user", "secret_sauce", "Firefox")]
        [InlineData("problem_user", "secret_sauce", "Chrome")]

        public void Login_With_Valid_Credentials(string username, string password, string browserName)
        {
            switch (browserName.ToLower())
            {
                case "firefox":
                    _driver = new WebDriverFactory().CreateFirefox();
                    break;
                case "chrome":
                    _driver = new WebDriverFactory().CreateChrome();
                    break;
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
            Log.Information("Starting UC_3_Login_With_Valid_Credentials Test.");
            var loginPage = new LoginPage(_driver);
            try
            {
                loginPage
                    .EnterCredentials(username, password)
                    .ClickLoginValid()
                    .GetTitle()
                    .Should()
                    .Be("Swag Labs");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occured during UC_3_Login_With_Valid_Credentials Test");
                throw;
            }
            finally
            {
                _driver.Quit();
                Log.Information("Finished UC_3_Login_With_Valid_Credentials Test");
                Log.CloseAndFlush();
            }
        }
    }

}