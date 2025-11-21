using CoreLayer;
using OpenQA.Selenium;

namespace BusinessLayer.PageObjects
{
    public class MainPage : BasePage
    {
        private readonly By _titleLocator = By.CssSelector("div[class *= 'header'] div[class*=logo]");
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetTitle()
        {
            return FindElement(_titleLocator).Text;
        }
    }
}