using System.ComponentModel;

namespace UIAutomationLibrary.Locators.HomeLocators
{
    internal class HomeLocators
    {
        public enum AllViewportLocators
        {
            [Description("input[type='text']")]
            SearchBox
        }
        public enum LargeLocators
        {
            [Description("#gh-btn")]
            SearchBtn
        }

        public enum XSLocators
        {
            [Description("button.gh-search__submitbtn")]
            SearchBtn
        }
    }
}
