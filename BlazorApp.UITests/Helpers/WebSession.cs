using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.UITests.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;

namespace BlazorApp.UITests.Helpers
{
    public class WebSession : IDisposable
    {
        public IWebDriver Driver { get; }

        public WebSession(BrowserType browserType)
        {
            Driver = browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Edge => new EdgeDriver(),
                BrowserType.Safari => new SafariDriver(),
                BrowserType.InternetExplorer => new InternetExplorerDriver(),
                BrowserType.Opera => new OperaDriver(),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, "Specified browser is not supported by the WebDriver.")
            };
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
