using System.Threading;
using BlazorApp.UITests.Enums;
using BlazorApp.UITests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace BlazorApp.UITests
{
    [TestFixture]
    public class CounterTests
    {
        [Test]
        public void UserClicksTheIncrementValueButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome);

            session.Driver.Navigate().GoToUrl("https://google.com");
            Thread.Sleep(2000);
            session.Driver.Navigate().GoToUrl("https://localhost:5000");
        }
    }
}