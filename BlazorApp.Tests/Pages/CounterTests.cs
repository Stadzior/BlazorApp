using NUnit.Framework;
using BlazorApp.Pages;
using FluentAssertions;

namespace BlazorApp.Tests.Pages
{
    [TestFixture]
    public class CounterTests
    {
        [TestCase(50, 51, TestName="IncrementCount_BeforeWas50_AfterShouldBe51")]
        [TestCase(0, 1, TestName="IncrementCount_BeforeWas0_AfterShouldBe1")]
        public void IncrementCountTest(int initialValue, int expectedValue)
        {
            var counter = new Counter
            {
                CurrentCount = initialValue
            };

            counter.IncrementCount();

            counter.CurrentCount.Should().Be(expectedValue);
        }
        
        [TestCase(50, 49, TestName="DecrementCount_BeforeWas50_AfterShouldBe49")]
        [TestCase(0, 0, TestName="DecrementCount_BeforeWas0_AfterShouldBe0")]
        public void DecrementCountTest(int initialValue, int expectedValue)
        {
            var counter = new Counter
            {
                CurrentCount = initialValue
            };

            counter.DecrementCount();
            
            counter.CurrentCount.Should().Be(expectedValue);
        }
         
        [TestCase(50, 0, TestName="ResetCount_BeforeWas50_AfterShouldBe0")]
        [TestCase(0, 0, TestName="ResetCount_BeforeWas0_AfterShouldBe0")]
        public void ResetCountTest(int initialValue, int expectedValue)
        {
            var counter = new Counter
            {
                CurrentCount = initialValue
            };

            counter.ResetCount();
            
            counter.CurrentCount.Should().Be(expectedValue);
        }
    }
}