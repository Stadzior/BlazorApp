using System;
using System.Diagnostics;
using System.Threading;
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
        private readonly string _pathToApp = @"..\..\..\..\BlazorApp";
        private Process _process;
        private bool _appIsRunning;

        public IWebDriver Driver { get; }

        public WebSession(BrowserType browserType)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--headless");

            Driver = browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(options),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Edge => new EdgeDriver(),
                BrowserType.Safari => new SafariDriver(),
                BrowserType.InternetExplorer => new InternetExplorerDriver(),
                BrowserType.Opera => new OperaDriver(),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, "Specified browser is not supported by the WebDriver.")
            };

            StartLatestAppVersion();
        }

        private void StartLatestAppVersion()
        {
            _process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"run --project {_pathToApp}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };
            
            _process.Start();

            while (!_appIsRunning)
            {
                var output = _process.StandardOutput.ReadLine();
                _appIsRunning = output?.Contains("Application started") ?? false;
                Thread.Sleep(100);
            }
        }

        public void Dispose()
        {
            Driver.Quit();
            _process.Kill();
            Driver?.Dispose();
            _process?.Dispose();
        }
    }
}
