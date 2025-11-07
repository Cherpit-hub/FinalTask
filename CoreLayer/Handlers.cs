using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CoreLayer
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        bool Handle(IWebDriver driver, By locator);
    }
    public abstract class Handler: IHandler
    {
        private IHandler? _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual bool Handle(IWebDriver driver, By locator)
        {
            if (_nextHandler != null) 
            {
                return _nextHandler.Handle(driver, locator);
            }
            else
            {
                return false;
            }
        }
    }
    public class ClickHandler : Handler
    {
        public override bool Handle(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator).Click();
                return true;
            }
            catch(NoSuchElementException) 
            {
                return base.Handle(driver, locator);
            }
        }
    }
    public class SendKeysHandler : Handler
    {
        private readonly string _textToSend;
        private int _count;

        public SendKeysHandler(string textToSend)
        {
            _textToSend = textToSend;
        }
        public override bool Handle(IWebDriver driver, By locator)
        {
            try
            {
                if(_count > 0)
                {
                    throw new NoSuchElementException();
                }
                _count = 1;
                driver.FindElement(locator).SendKeys(_textToSend);
                return true;
            }
            catch (NoSuchElementException) 
            {
                return base.Handle(driver, locator);
            }

        }
    }
    public class ClearInputHandler : Handler
    {
        public override bool Handle(IWebDriver driver, By locator)
        {
            try
            {
                var field = driver.FindElement(locator);
                new Actions(driver)
                    .MoveToElement(field)
                    .Click()
                    .KeyDown(Keys.Control)
                    .SendKeys("a")
                    .KeyUp(Keys.Control)
                    .SendKeys(Keys.Delete)
                    .Perform();
                return true;
            }
            catch (NoSuchElementException)
            {
                return base.Handle(driver, locator);
            }
        }
    }
}
