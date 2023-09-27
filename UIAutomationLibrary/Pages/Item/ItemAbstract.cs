using OpenQA.Selenium;
using System.ComponentModel;
using UIAutomationLibrary.Base;
using UIAutomationLibrary.Locators;

namespace UIAutomationLibrary.Pages.Item
{
    public abstract class ItemAbstract : Page
    {
        protected ItemAbstract(IWebDriver driver, Viewport viewport, Language language)
        {
            base.driver = driver;
            base.viewport = viewport;
            base.language = language;
        }

        public abstract bool IsColorDropDownEnabled();

        public abstract void SelectItemFromColorDropDown(int index);

        public abstract string GetColorFromDropDown(int index);

        public abstract void EnterQuantity(int number);

        public abstract int GetQuantity(int index = 0);

        public abstract bool IsQuantityDropDownEnabled();

        public abstract void ClickAddToCartBtn();

        public void ClickGoToCartBtn()
        {
            By locator = By.LinkText(ItemLocators.AllViewportLocators.GotoCartBtn.GetAttribute<DescriptionAttribute>().Description);
            WaitForElementToExistInDOM(locator);
            FindElement(locator).Click();
        }

        public string GetPrice()
        {
            return FindElement(By.CssSelector(ItemLocators.AllViewportLocators.PriceText.GetAttribute<DescriptionAttribute>().Description)).Text.Trim().Split('$')[1];
        }

        public abstract string GetItemTitle();
        
    }
}
