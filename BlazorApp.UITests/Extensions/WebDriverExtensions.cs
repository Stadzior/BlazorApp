using System;
using System.Threading;
using OpenQA.Selenium;

namespace BlazorApp.UITests.Extensions
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Finds the first of elements that match the <paramref name="by"/> condition supplied.
        /// This method will try to locate the element <paramref name="numberOfRetries"/> times with the frequency of 1try/second.
        /// If after <paramref name="numberOfRetries"/> it doesn't appear it will throw nicely described <see cref="NoSuchElementException"/>.
        /// <seealso cref="IWebDriver.FindElement(By)"/>
        /// </summary>
        /// <param name="driver">Web driver remote session instance.</param>
        /// <param name="by">By condition</param>
        /// <param name="numberOfRetries">Number of retries</param>
        /// <returns>Found element</returns>
        /// <exception cref="NoSuchElementException"></exception>
        public static IWebElement FindElement(this IWebDriver driver, By by, int numberOfRetries)
        {
            var retryCount = 0;
            var element = driver.FindElementOrDefault(by);
            while (element == null && retryCount < numberOfRetries)
            {
                retryCount++;
                Thread.Sleep(1000);
                element = driver.FindElementOrDefault(by);
            }

            if (element != null)
                return element;

            throw new NoSuchElementException($"Element could not be found. Retry count: {retryCount}");
        }

        /// <summary>
        /// Finds the first of elements that match the <paramref name="by"/> condition supplied.
        /// This method returns null instead of throwing <see cref="NoSuchElementException"/>.
        /// <seealso cref="IWebDriver.FindElement(By)"/>
        /// </summary>
        /// <param name="driver">Web driver remote session instance.</param>
        /// <param name="by">By condition</param>
        /// <returns></returns>
        public static IWebElement FindElementOrDefault(this IWebDriver driver, By by)
        {
            IWebElement element;

            try
            {
                element = driver.FindElement(by);
            }
            catch (WebDriverException)
            {
                element = null;
            }

            return element;
        }
    }
}
