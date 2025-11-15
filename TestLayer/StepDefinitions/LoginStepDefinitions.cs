using BusinessLayer.PageObjects;
using CoreLayer;
using CoreLayer.WebDriver;
using OpenQA.Selenium;
using Reqnroll;
using Serilog;
using Shouldly;
using System;

namespace TestLayer.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver? _driver;
        private LoginPage? loginPage;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private MainPage? _mainPage;

        public LoginStepDefinitions()
        {
            LogConfig.ConfigureLogger(); 
        }
        static class TestSetupAndTeardown
        {
            public static IWebDriver CreateDriver(string name)
            {
                Log.Information("test start");
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
        [AfterScenario]
        public void AfterScenario() 
        {
            TestSetupAndTeardown.DriverDispose(_driver!);
            Log.Information("Finished test");
        }
        [Given("User is on login page using {string}")]
        public void GivenUserIsOnLoginPageUsing(string browser)
        {
            _driver = TestSetupAndTeardown.CreateDriver(browser);
        }
        [When("the user enters their username and password")]
        public void WhenTheUserEntersTheirUsernameAndPassword()
        {
            loginPage = new LoginPage(_driver!).EnterCredentials(_username,_password);
        }

        [When("clears the fields")]
        public void WhenClearsTheFields()
        {
            loginPage!.ClearUsername().ClearPassword();
        }

        [When("clicks the login button")]
        public void WhenClicksTheLoginButton()
        {
            loginPage!.ClickLoginInvalid();
        }
        [When("clicks the login button with valid credentials")]
        public void WhenClicksTheLoginButtonWithValidCredentials()
        {
            _mainPage = loginPage!.ClickLoginValid();
        }


        [Then("the user should see error message: {string}")]
        public void ThenTheUserShouldSeeErrorMessage(string p0)
        {
            loginPage!.GetErrorMessage().ShouldContain(p0);
        }

        [When("clears the password field")]
        public void WhenClearsThePasswordField()
        {
            loginPage!.ClearPassword();
        }

        [Given("username {string}")]
        public void GivenUsername(string p0)
        {
            _username = p0;
        }

        [Given("password {string}")]
        public void GivenPassword(string p0)
        {
            _password = p0;
        }

        [Then("the user should be redirected to new page and see the dashboard title: {string}")]
        public void ThenTheUserShouldBeRedirectedToNewPageAndSeeTheDashboardTitle(string p0)
        {
            _mainPage!.GetTitle().ShouldBe(p0);
        }
    }
}
