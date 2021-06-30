using System.Threading;
using BlazorApp.UITests.Enums;
using BlazorApp.UITests.Helpers;
using NUnit.Framework;

namespace BlazorApp.UITests
{
    [TestFixture]
    public class CounterTests
    {
        [Test]
        public void UserClicksTheIncrementValueButtonTest()
        {
            using var session = new WebSession(BrowserType.Chrome, true);

            session.Driver.Navigate().GoToUrl("https://localhost:5000");
        }
    }
}