using BusinessLayer.PageObjects;
using CoreLayer;
using CoreLayer.WebDriver;
using OpenQA.Selenium;
using Reqnroll.xUnit.ReqnrollPlugin;
using Serilog;
using Shouldly;
using FinalTask;
[assembly: AssemblyFixture(typeof(TestSetupAndTeardown))]

namespace FinalTask
{
      class TestSetupAndTeardown
    {
        public TestSetupAndTeardown() { }
        public static IWebDriver CreateDriver(string name) 
        {
            switch (name.ToLower())
            {
                case "firefox":
                    return new WebDriverFactory().CreateFirefox();
                case "chrome":
                    return new WebDriverFactory().CreateChrome();
                default:
                    throw new ArgumentException("Unsupported browser type");
            }
        }
        public static void DriverDispose(IWebDriver driver) 
        {
            driver.Quit();
        }
    }
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
            _driver = TestSetupAndTeardown.CreateDriver(browserName);
            Log.Information("Starting UC_1_Login_Empty_Credentials Test.");
            var loginPage = new LoginPage(_driver);
                loginPage
                    .EnterCredentials(username, password)
                    .ClearPassword()
                    .ClearUsername()
                    .ClickLoginInvalid()
                    .GetErrorMessage()
                    .ShouldContain("Username is required");
                Log.Information("Finished UC_1_Login_Empty_Credentials Test");
            TestSetupAndTeardown.DriverDispose(_driver);
                Log.CloseAndFlush();
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
            _driver = TestSetupAndTeardown.CreateDriver(browserName);
            Log.Information("Starting UC_2_Login_Only_Username Test.");
            var loginPage = new LoginPage(_driver);
                loginPage
                    .EnterCredentials(username, password)
                    .ClearPassword()
                    .ClickLoginInvalid()
                    .GetErrorMessage()
                    .ShouldContain("Password is required");
                Log.Information("Finished UC_2_Login_Only_Username Test");
            TestSetupAndTeardown.DriverDispose(_driver);
            Log.CloseAndFlush();
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
            _driver = TestSetupAndTeardown.CreateDriver(browserName);
            Log.Information("Starting UC_3_Login_With_Valid_Credentials Test.");
            var loginPage = new LoginPage(_driver);
                loginPage
                    .EnterCredentials(username, password)
                    .ClickLoginValid()
                    .GetTitle()
                    .ShouldBe("Swag Labs");
                Log.Information("Finished UC_3_Login_With_Valid_Credentials Test");
            TestSetupAndTeardown.DriverDispose(_driver);
            Log.CloseAndFlush();
        }
    }

}