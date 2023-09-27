using OpenQA.Selenium;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using UIAutomationLibrary.Base;
using UIAutomationLibrary.Locators;

namespace UIAutomationLibrary.Pages.AllListings
{
    public abstract class AllListingsAbstract : Page
    {
        protected AllListingsAbstract(IWebDriver driver, Viewport viewport, Language language)
        {
            base.driver = driver;
            base.viewport = viewport;
            base.language = language;
        }

        public int CountAllListings()
        {
            return FindElements(By.CssSelector(AllListingsLocators.AllViewportLocators.ItemTitle.GetAttribute<DescriptionAttribute>().Description)).Count;
        }

        public bool DoAllListingsMatchSearchCriteria(string searchText)
        {
            IList<IWebElement> items = FindElements(By.CssSelector(AllListingsLocators.AllViewportLocators.ItemTitle.GetAttribute<DescriptionAttribute>().Description));

            string text = searchText.Replace(' ', '|');
            Regex validateWordRegex = new Regex("\\b(?:" + text + ")\\b");
            bool result = false;

            for (int i = 1; i < items.Count; i++)
            {
                result = validateWordRegex.IsMatch(items[i].Text);
                if (!result)
                {
                    return result;
                }
            }
            return result;
        }

        public string GetTitle(int index)
        {
            IList<IWebElement> items = FindElements(By.CssSelector(AllListingsLocators.AllViewportLocators.ItemTitle.GetAttribute<DescriptionAttribute>().Description));
            return items[index].Text;
        }

        public string GetPrice(int index)
        {
            IList<IWebElement> items = FindElements(By.CssSelector(AllListingsLocators.AllViewportLocators.Price.GetAttribute<DescriptionAttribute>().Description));
            return items[index].Text;
        }

        public void ClickOnItem(int index)
        {
            IList<IWebElement> items = FindElements(By.CssSelector(AllListingsLocators.AllViewportLocators.ItemTitle.GetAttribute<DescriptionAttribute>().Description));
            items[index].Click();
        }
    }
}
