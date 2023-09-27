using OpenQA.Selenium;
using System.ComponentModel;
using UIAutomationLibrary.Base;
using UIAutomationLibrary.Locators.HomeLocators;

namespace UIAutomationLibrary.Pages.Home
{
    public abstract class HomeAbstract : Page
    {
        protected HomeAbstract(IWebDriver driver, Viewport viewport, Language language)
        { 
            base.driver = driver;
            base.viewport = viewport;
            base.language = language;
        }

        public void EnterTextInSearchBox(string text)
        {
            FindElement(By.CssSelector(HomeLocators.AllViewportLocators.SearchBox.GetAttribute<DescriptionAttribute>().Description)).SendKeys(text);
        }

        public abstract void ClickSearchBtn();

    }
}
