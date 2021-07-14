using System.Threading;
using BlazorApp.UITests.Enums;
using BlazorApp.UITests.Helpers;
using BlazorApp.UITests.PageObjects;
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
            
            var homePage = new HomePage(session.Driver);
            homePage.NavigateTo("Counter");

            var counterPage = new CounterPage(session.Driver);
            counterPage.IncrementCount();

           counterPage.CounterValue.Should().Be("Current count: 1");
        }

        [Test]
        public void UserClicksTheDecrementValueButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome);

            session.Driver.Navigate().GoToUrl("http://localhost:5000");

            var homePage = new HomePage(session.Driver);
            homePage.NavigateTo("Counter");

            var counterPage = new CounterPage(session.Driver);
            counterPage.DecrementCount();

            counterPage.CounterValue.Should().Be("Current count: 0");
        }

        [Test]
        public void UserClicksIncrementValueButtonTwiceAndThenTheDecrementValueButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome);

            session.Driver.Navigate().GoToUrl("http://localhost:5000");

            var homePage = new HomePage(session.Driver);
            homePage.NavigateTo("Counter");

            var counterPage = new CounterPage(session.Driver);
            counterPage.IncrementCount();
            counterPage.IncrementCount();
            counterPage.DecrementCount();
            
            counterPage.CounterValue.Should().Be("Current count: 1");
        }

        [Test]
        public void UserClicksIncrementValueButtonTwiceAndThenResetButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome);

            session.Driver.Navigate().GoToUrl("http://localhost:5000");

            var homePage = new HomePage(session.Driver);
            homePage.NavigateTo("Counter");

            var counterPage = new CounterPage(session.Driver);
            counterPage.IncrementCount();
            counterPage.IncrementCount();
            counterPage.ResetCount();
            
            counterPage.CounterValue.Should().Be("Current count: 0");
        }
    }
}