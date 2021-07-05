using BlazorApp.UISpecs.Enums;
using BlazorApp.UISpecs.Extensions;
using BlazorApp.UISpecs.Helpers;
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
            
            _session.Driver.FindElement(By.Id(linkAutomationId), 10).Click();
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

            _session.Driver.FindElement(By.Id(linkAutomationId), 10).Click();
        }

        [Then(@"the counter value should be (\d+)")]
        public void ThenTheCounterValueShouldBeTo(int expectedValue)
        {
            _session.Driver.FindElement(By.Id("counter_value"), 10).Text.Should().Be($"Current count: {expectedValue}");
        }
    }
}
