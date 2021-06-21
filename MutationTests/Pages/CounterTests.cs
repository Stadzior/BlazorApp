using NUnit.Framework;
using BlazorApp.Pages;

namespace MutationTests.Pages
{
    [TestFixture]
    public class CounterTests
    {
        [TestCase("IncrementCount_Invoked_IncrementedToOne")]
        public void IncrementCountTest()
        {
            var counterComponent = new Counter();
            counterComponent.IncrementCount();
            Assert.AreEqual(1, counterComponent.CurrentCount);
        }
    }
}