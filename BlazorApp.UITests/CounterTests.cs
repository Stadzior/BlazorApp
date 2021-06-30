using System.Threading;
using BlazorApp.UITests.Enums;
using BlazorApp.UITests.Extensions;
using BlazorApp.UITests.Helpers;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BlazorApp.UITests
{
    [TestFixture]
    public class CounterTests
    {
        [Test]
        public void UserClicksTheIncrementValueButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome);

            session.Driver.Navigate().GoToUrl("http://localhost:5000");
            session.Driver.FindElement(By.Id("counter_menu_link"), 10).Click();
            session.Driver.FindElement(By.Id("increment_count_button"), 10).Click();

            session.Driver.FindElement(By.Id("counter_value"), 10).Text.Should().Be("Current count: 1");
        }
    }
}