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
        private readonly string _pathToApp = @"\..\..\..\..\BlazorApp";
        private Process _process;
        private bool _appIsRunning;

        public IWebDriver Driver { get; }

        public WebSession(BrowserType browserType, bool acceptInsecureCertificates)
        {
            Driver = browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(new ChromeOptions { AcceptInsecureCertificates = acceptInsecureCertificates }),
                BrowserType.Firefox => new FirefoxDriver(new FirefoxOptions { AcceptInsecureCertificates = acceptInsecureCertificates }),
                BrowserType.Edge => new EdgeDriver(new EdgeOptions { AcceptInsecureCertificates = acceptInsecureCertificates }),
                BrowserType.Safari => new SafariDriver(new SafariOptions { AcceptInsecureCertificates = acceptInsecureCertificates }),
                BrowserType.InternetExplorer => new InternetExplorerDriver(new InternetExplorerOptions { AcceptInsecureCertificates = acceptInsecureCertificates }),
                BrowserType.Opera => new OperaDriver(new OperaOptions { AcceptInsecureCertificates = acceptInsecureCertificates }),
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
