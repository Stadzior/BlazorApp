using BlazorApp.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BlazorApp.Specs.Steps
{
    [Binding]
    public sealed class CounterStepDefinitions
    {
        private readonly Counter _counter = new Counter();
        
        [Given(@"the counter value is (\d+)")]
        public void GivenTheCounterValueIs(int value)
        {
            _counter.CurrentCount = value;
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
        }

        [Then(@"the counter value should be (\d+)")]
        public void ThenTheCounterValueShouldBeTo(int expectedValue)
        {
            _counter.CurrentCount.Should().Be(expectedValue);
        }
    }
}
