using OpenQA.Selenium;
using System;
using System.ComponentModel;
using UIAutomationLibrary.Base;
using UIAutomationLibrary.Locators;

namespace UIAutomationLibrary.Pages.Item
{
    public class ItemLarge : ItemAbstract
    {
        public ItemLarge(IWebDriver driver, Viewport viewport, Language language) : base(driver, viewport, language) { }

        public override bool IsColorDropDownEnabled()
        {
            return IsElementEnabled(By.CssSelector(ItemLocators.LargeLocators.ColorDropDown.GetAttribute<DescriptionAttribute>().Description));
        }

        public override void SelectItemFromColorDropDown(int index)
        {
            FindElement(By.CssSelector(ItemLocators.LargeLocators.ColorDropDown.GetAttribute<DescriptionAttribute>().Description)).Click();
            FindElements(By.CssSelector(ItemLocators.LargeLocators.ColorDropDownOptions.GetAttribute<DescriptionAttribute>().Description))[index].Click();
        }

        public override string GetColorFromDropDown(int index)
        {
            return FindElements(By.CssSelector(ItemLocators.LargeLocators.ColorDropDownOptions.GetAttribute<DescriptionAttribute>().Description))[index].Text;
        }

        public override bool IsQuantityDropDownEnabled()
        {
            return IsElementEnabled(By.CssSelector(ItemLocators.LargeLocators.QuantityTextBox.GetAttribute<DescriptionAttribute>().Description));
        }

        public override void EnterQuantity(int number)
        {
            FindElement(By.CssSelector(ItemLocators.LargeLocators.QuantityTextBox.GetAttribute<DescriptionAttribute>().Description)).Clear();
            FindElement(By.CssSelector(ItemLocators.LargeLocators.QuantityTextBox.GetAttribute<DescriptionAttribute>().Description)).SendKeys(number.ToString());
        }

        public override int GetQuantity(int index = 0)
        {
            return Convert.ToInt32(FindElement(By.CssSelector(ItemLocators.LargeLocators.QuantityTextBox.GetAttribute<DescriptionAttribute>().Description)).GetAttribute("value"));
        }

        public override void ClickAddToCartBtn()
        {
            FindElement(By.CssSelector(ItemLocators.LargeLocators.AddToCartBtn.GetAttribute<DescriptionAttribute>().Description)).Click();
        }

        public override string GetItemTitle()
        {
            return FindElement(By.CssSelector(ItemLocators.LargeLocators.ItemTitle.GetAttribute<DescriptionAttribute>().Description)).Text.Trim();
        }
    }
}
