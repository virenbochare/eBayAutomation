using OpenQA.Selenium;
using System.ComponentModel;
using UIAutomationLibrary.Base;
using UIAutomationLibrary.Locators.HomeLocators;
using Viewport = UIAutomationLibrary.Base.Viewport;

namespace UIAutomationLibrary.Pages.Home
{
    public class HomeLarge : HomeAbstract
    {
        public HomeLarge(IWebDriver driver, Viewport viewport, Language language) : base(driver, viewport, language) { }
        
        public override void ClickSearchBtn()
        {
            FindElement(By.CssSelector(HomeLocators.LargeLocators.SearchBtn.GetAttribute<DescriptionAttribute>().Description)).Click();
        }
    }
}
