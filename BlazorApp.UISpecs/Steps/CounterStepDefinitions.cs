using System.Threading;
using BlazorApp.UITests.Enums;
using BlazorApp.UITests.Helpers;
using BlazorApp.UITests.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BlazorApp.UISpecs.Steps
{
    [Binding]
    public sealed class CounterStepDefinitions
    {
        private WebSession _session;
        private HomePage _homePage;
        private CounterPage _counterPage;
            
        [BeforeScenario]
        public void InitializeSession()
        {
            _session = new WebSession(BrowserType.Chrome);
            _homePage = new HomePage(_session.Driver);
            _counterPage = new CounterPage(_session.Driver);
        }

        [AfterScenario]
        public void DisposeSession()
        {
            _session.Dispose();
        }

        [Given("main page of the website is opened")]
        public void MainPageOfTheWebsiteIsOpened()
        {
            _session.Driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [When(@"the user clicks ""(.*)"" link from menu")]
        public void WhenTheUserClicksLinkFromMenu(string linkName)
        {
            _homePage.NavigateTo(linkName);
        }

        [When(@"the user clicks ""(.*)"" button")]
        public void WhenTheUserClicksButton(string buttonName)
        {
            switch (buttonName)
            {
                case "++":
                    _counterPage.IncrementCount();
                    break;
                case "--":
                    _counterPage.DecrementCount();
                    break;
                case "Reset":
                    _counterPage.ResetCount();
                    break;
            };
        }

        [When(@"the user clicks ""(.*)"" (\d+) times every (\d+) seconds")]
        public void WhenTheUserClicksButtonNTimes(string buttonName, int clickCount, int seconds)
        {
            for (var j = 0; j < clickCount; j++)
            {
                WhenTheUserClicksButton(buttonName);
                Thread.Sleep(seconds*1000);
            }
        }

        [When(@"the user waits for (\d+) seconds")]
        public void WhenTheUserWaitsForNSeconds(int seconds)
        {
            Thread.Sleep(seconds*1000);
        }

        [Then(@"the counter value should be (\d+)")]
        public void ThenTheCounterValueShouldBe(int expectedValue)
        {
            _counterPage.CounterValue.Should().Be($"Current count: {expectedValue}");
        }
    }
}
