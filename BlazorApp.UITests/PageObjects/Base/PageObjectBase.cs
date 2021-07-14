using OpenQA.Selenium;

namespace BlazorApp.UITests.PageObjects.Base
{
    public abstract class PageObjectBase
    {
        public IWebDriver Driver { get; }

        protected PageObjectBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
