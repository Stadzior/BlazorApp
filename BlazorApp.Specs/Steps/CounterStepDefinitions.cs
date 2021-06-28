using BlazorApp.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BlazorApp.Specs.Steps
{
    [Binding]
    public sealed class CounterStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Counter _counter = new Counter();

        public CounterStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [Given(@"the counter value is (\d+)")]
        public void GivenTheCounterValueIs(int value)
        {
            _counter.CurrentCount = value;

            _scenarioContext.Pending();
        }

        [When(@"the user clicks ""(.*)"" button")]
        public void WhenTheUserClicksButton(string buttonName)
        {
            switch (buttonName)
            {
                case "++":
                {
                    _counter.IncrementCount();
                    break;
                }
                case "--":
                {
                    _counter.DecrementCount();
                    break;
                }
                case "Reset":
                {
                    _counter.ResetCount();
                    break;
                }
            }

            _scenarioContext.Pending();
        }

        [Then(@"the counter value should be (\d+)")]
        public void ThenTheCounterValueShoudBeTo(int expectedValue)
        {
            _counter.CurrentCount.Should().Be(expectedValue);
        }
    }
}
