using System.ComponentModel;

namespace UIAutomationLibrary.Locators
{
    public class AllListingsLocators
    {
        public enum AllViewportLocators
        {
            [Description("span[role='heading']")]
            ItemTitle,
            [Description("span.s-item__price")]
            Price
        }
    }
}
