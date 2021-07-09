using System.Threading;
using BlazorApp.UITests.Enums;
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
            session.Driver.FindElement(By.Id("counter_menu_link")).Click();
            session.Driver.FindElement(By.Id("increment_count_button")).Click();

            session.Driver.FindElement(By.Id("counter_value")).Text.Should().Be("Current count: 1");
        }

        [Test]
        public void UserClicksTheDecrementValueButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome);

            session.Driver.Navigate().GoToUrl("http://localhost:5000");
            session.Driver.FindElement(By.Id("counter_menu_link")).Click();
            session.Driver.FindElement(By.Id("decrement_count_button")).Click();

            session.Driver.FindElement(By.Id("counter_value")).Text.Should().Be("Current count: 0");
        }

        [Test]
        public void UserClicksIncrementValueButtonTwiceAndThenTheDecrementValueButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome);

            session.Driver.Navigate().GoToUrl("http://localhost:5000");
            session.Driver.FindElement(By.Id("counter_menu_link")).Click();

            var incrementCountButton = session.Driver.FindElement(By.Id("increment_count_button"));
            incrementCountButton.Click();
            incrementCountButton.Click();
            session.Driver.FindElement(By.Id("decrement_count_button")).Click();

            session.Driver.FindElement(By.Id("counter_value")).Text.Should().Be("Current count: 1");
        }

        [Test]
        public void UserClicksIncrementValueButtonTwiceAndThenResetButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome);

            session.Driver.Navigate().GoToUrl("http://localhost:5000");
            Thread.Sleep(2000);
            session.Driver.FindElement(By.Id("counter_menu_link")).Click();
            Thread.Sleep(2000);

            var incrementCountButton = session.Driver.FindElement(By.Id("increment_count_button"));
            Thread.Sleep(2000);
            incrementCountButton.Click();
            Thread.Sleep(2000);
            incrementCountButton.Click();
            Thread.Sleep(2000);
            session.Driver.FindElement(By.Id("reset_count_button")).Click();
            Thread.Sleep(2000);

            session.Driver.FindElement(By.Id("counter_value")).Text.Should().Be("Current count: 0");
        }
    }
}