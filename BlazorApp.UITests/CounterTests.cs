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
            var driver = new ChromeDriver();

            driver.
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}