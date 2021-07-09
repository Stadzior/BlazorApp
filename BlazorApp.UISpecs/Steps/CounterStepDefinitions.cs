using System.Threading;
using BlazorApp.UITests.Enums;
using BlazorApp.UITests.Helpers;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BlazorApp.UISpecs.Steps
{
    [Binding]
    public sealed class CounterStepDefinitions
    {
        private static WebSession _session;
            
        [BeforeScenario]
        public static void InitializeSession()
        {
            _session = new WebSession(BrowserType.Chrome);
        }

        [AfterScenario]
        public static void DisposeSession()
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
            var linkAutomationId = linkName switch
            {
                "Home" => "home_menu_link",
                "Counter" => "counter_menu_link",
                "FetchData" => "fetchdata_menu_link",
                "CompoundInterest" => "compoundinterest_menu_link",
                "JsInterop" => "jsinterop_menu_link",
                _ => ""
            };
            
            _session.Driver.FindElement(By.Id(linkAutomationId)).Click();
        }

        [When(@"the user clicks ""(.*)"" button")]
        public void WhenTheUserClicksButton(string buttonName)
        {
            var linkAutomationId = buttonName switch
            {
                "++" => "increment_count_button",
                "--" => "decrement_count_button",
                "Reset" => "reset_count_button",
                _ => ""
            };

            _session.Driver.FindElement(By.Id(linkAutomationId)).Click();
        }

        [When(@"the user clicks ""(.*)"" (\d+) times every (\d+) seconds")]
        public void WhenTheUserClicksButtonNTimes(string buttonName, int clickCount, int seconds)
        {
            var linkAutomationId = buttonName switch
            {
                "++" => "increment_count_button",
                "--" => "decrement_count_button",
                "Reset" => "reset_count_button",
                _ => ""
            };

            for (var i = 0; i<clickCount; i++)
            {
                _session.Driver.FindElement(By.Id(linkAutomationId)).Click();
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
            _session.Driver.FindElement(By.Id("counter_value")).Text.Should().Be($"Current count: {expectedValue}");
        }
    }
}
