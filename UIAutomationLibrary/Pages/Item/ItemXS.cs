using OpenQA.Selenium;
using System;
using System.ComponentModel;
using UIAutomationLibrary.Base;
using UIAutomationLibrary.Locators;

namespace UIAutomationLibrary.Pages.Item
{
    public class ItemXS : ItemAbstract
    {
        public ItemXS(IWebDriver driver, Viewport viewport, Language language) : base(driver, viewport, language) { }

        public override bool IsColorDropDownEnabled()
        {
            return IsElementEnabled(By.CssSelector(ItemLocators.XSLocators.ColorDropDown.GetAttribute<DescriptionAttribute>().Description));
        }

        public override void SelectItemFromColorDropDown(int index)
        {
            FindElement(By.CssSelector(ItemLocators.XSLocators.ColorDropDown.GetAttribute<DescriptionAttribute>().Description)).Click();
            FindElements(By.CssSelector(ItemLocators.XSLocators.ColorDropDownOptions.GetAttribute<DescriptionAttribute>().Description))[index].Click();
        }

        public override bool IsQuantityDropDownEnabled()
        {
            return IsElementEnabled(By.CssSelector(ItemLocators.XSLocators.QuantityDropDown.GetAttribute<DescriptionAttribute>().Description));
        }

        public override string GetColorFromDropDown(int index)
        {
            return FindElements(By.CssSelector(ItemLocators.XSLocators.ColorDropDownOptions.GetAttribute<DescriptionAttribute>().Description))[index].Text;
        }

        public override void EnterQuantity(int number)
        {
            FindElement(By.CssSelector(ItemLocators.XSLocators.QuantityDropDown.GetAttribute<DescriptionAttribute>().Description)).Click();
            FindElements(By.CssSelector(ItemLocators.XSLocators.QuantityDropDownOptions.GetAttribute<DescriptionAttribute>().Description))[number + 1].Click();
        }

        public override int GetQuantity(int index)
        {
            return Convert.ToInt32(FindElements(By.CssSelector(ItemLocators.XSLocators.QuantityDropDownOptions.GetAttribute<DescriptionAttribute>().Description))[index + 1].Text);
        }

        public override void ClickAddToCartBtn()
        {
            FindElement(By.CssSelector(ItemLocators.XSLocators.AddToCartBtn.GetAttribute<DescriptionAttribute>().Description)).Click();
        }

        public override string GetItemTitle()
        {
            return FindElement(By.CssSelector(ItemLocators.XSLocators.ItemTitle.GetAttribute<DescriptionAttribute>().Description)).Text.Trim();
        }
    }
}
