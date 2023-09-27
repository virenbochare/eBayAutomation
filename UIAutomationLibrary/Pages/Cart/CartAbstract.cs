using OpenQA.Selenium;
using System.ComponentModel;
using System.Text.RegularExpressions;
using UIAutomationLibrary.Base;
using UIAutomationLibrary.Locators;

namespace UIAutomationLibrary.Pages.Cart
{
    public abstract class CartAbstract : Page
    {
        protected CartAbstract(IWebDriver driver, Viewport viewport, Language language)
        {
            base.driver = driver;
            base.viewport = viewport;
            base.language = language;
        }

        public string GetPrice()
        {
            return FindElement(By.CssSelector(CartLocators.AllViewportLocators.PriceText.GetAttribute<DescriptionAttribute>().Description)).Text.Trim().Split('$')[1];
        }

        public bool DoesDescriptionContainSelectedColor(string selectedColor)
        {
            string description =  FindElement(By.CssSelector(CartLocators.AllViewportLocators.ItemTitle.GetAttribute<DescriptionAttribute>().Description)).Text.Trim();
            Regex validateWordRegex = new Regex("\\b(?:" + selectedColor + ")\\b");
            return validateWordRegex.IsMatch(description);
        }
    }
}
