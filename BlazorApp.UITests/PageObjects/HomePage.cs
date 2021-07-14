using BlazorApp.UITests.PageObjects.Base;
using OpenQA.Selenium;

namespace BlazorApp.UITests.PageObjects
{
    public class HomePage : PageObjectBase
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public void NavigateTo(string linkName)
        {
            switch (linkName)
            {
                case "Home":
                    Driver.FindElement(By.Id("home_menu_link")).Click();
                    break;
                case "Counter":
                    Driver.FindElement(By.Id("counter_menu_link")).Click();
                    break;
                case "FetchData":
                    Driver.FindElement(By.Id("fetchdata_menu_link")).Click();
                    break;
                case "CompoundInterest":
                    Driver.FindElement(By.Id("compoundinterest_menu_link")).Click();
                    break;
                case "JsInterop":
                    Driver.FindElement(By.Id("jsinterop_menu_link")).Click();
                    break;
            }
        }
    }
}
