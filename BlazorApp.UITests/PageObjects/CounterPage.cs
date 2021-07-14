using BlazorApp.UITests.PageObjects.Base;
using OpenQA.Selenium;

namespace BlazorApp.UITests.PageObjects
{
    public class CounterPage : PageObjectBase
    {
        public string CounterValue
            => Driver.FindElement(By.Id("counter_value")).Text;

        public CounterPage(IWebDriver driver) : base(driver) { }

        public void IncrementCount()
            => Driver.FindElement(By.Id("increment_count_button")).Click();

        public void DecrementCount()
            => Driver.FindElement(By.Id("decrement_count_button")).Click();
        
        public void ResetCount()
            => Driver.FindElement(By.Id("reset_count_button")).Click();
    }
}
