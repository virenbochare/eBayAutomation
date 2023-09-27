using System.ComponentModel;

namespace UIAutomationLibrary.Locators
{
    internal class CartLocators
    {
        public enum AllViewportLocators
        {
            [Description(".listsummary")]
            ItemTitle,
            [Description("select[data-test-id='qty-dropdown']")]
            QuantityTextBox,
            [Description("div.price-details")]
            PriceText
        }
    }
}
