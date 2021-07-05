﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
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

        public IWebDriver Driver { get; }

        public WebSession(BrowserType browserType)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
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

        private void StartLatestAppVersion(int numberOfRetries = 30)
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

            for (var retryCount = 1; retryCount < numberOfRetries; retryCount++)
            {
                var appIsRunning = CheckIfAppIsRunning();

                if (appIsRunning)
                    return;

                Console.WriteLine($"Checking if app is running ({retryCount}/{numberOfRetries}).");
            }

            Dispose();
            throw new TimeoutException($"Unable to start webapp. After {numberOfRetries} checks the process was terminated.");
        }

        private static bool CheckIfAppIsRunning()
        {
            var client = new HttpClient();
            HttpResponseMessage checkingResponse;

            try
            {
                checkingResponse = client.GetAsync("http://localhost:5000").Result;
            }
            catch (Exception)
            {
                return false;
            }

            return checkingResponse.IsSuccessStatusCode;
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
