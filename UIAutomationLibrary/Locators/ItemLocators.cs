using System.ComponentModel;

namespace UIAutomationLibrary.Locators
{
    internal class ItemLocators
    {
        public enum AllViewportLocators
        {
            [Description("Go to cart")]
            GotoCartBtn,
            [Description("div.x-price-primary")]
            PriceText
        }

        public enum LargeLocators
        {
            [Description("#x-msku__select-box-1000")]
            ColorDropDown,
            [Description("#x-msku__select-box-1000 option")]
            ColorDropDownOptions,
            [Description("#qtyTextBox")]
            QuantityTextBox,
            [Description("div[data-testid='x-price-primary']")]
            PriceText,
            [Description("div[data-testid='x-atc-action'] a")]
            AddToCartBtn,
            [Description("h1.x-item-title__mainTitle")]
            ItemTitle
        }

        public enum XSLocators
        {
            [Description("#vi-msku__select-box-1000")]
            ColorDropDown,
            [Description("#vi-msku__select-box-1000 option")]
            ColorDropDownOptions,
            [Description("#vi-quantity__select-box")]
            QuantityDropDown,
            [Description("#vi-quantity__select-box option")]
            QuantityDropDownOptions,
            [Description("vi-cart-button")]
            AddToCartBtn,
            [Description("div.vi-title__main")]
            ItemTitle
        }
    }
}
