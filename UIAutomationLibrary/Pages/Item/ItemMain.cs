using OpenQA.Selenium;
using UIAutomationLibrary.Base;

namespace UIAutomationLibrary.Pages.Item
{
    public class ItemMain : Page
    {
        ItemAbstract itemAbstract;

        public ItemMain(IWebDriver driver, Viewport viewport, Language language)
        {
            base.driver = driver;
            base.viewport = viewport;
            base.language = language;

            switch (viewport)
            {
                case Viewport.Large:
                    itemAbstract = new ItemLarge(driver, viewport, language);
                    break;
                case Viewport.XS:
                    itemAbstract = new ItemXS(driver, viewport, language);
                    break;
            }
        }

        public bool IsColorDropDownEnabled()
        {
            return itemAbstract.IsColorDropDownEnabled();
        }

        public void SelectItemFromColorDropDown(int index)
        {
            itemAbstract.SelectItemFromColorDropDown(index);
        }

        public bool IsQuantityDropDownEnabled()
        {
            return itemAbstract.IsQuantityDropDownEnabled();
        }

        public string GetColorFromDropDown(int index)
        {
            return itemAbstract.GetColorFromDropDown(index);
        }

        public void EnterQuantity(int number)
        {
            itemAbstract.EnterQuantity(number);
        }

        public int GetQuantity(int index = 0)
        {
            return GetQuantity(index);
        }

        public void ClickAddToCartBtn()
        {
            itemAbstract.ClickAddToCartBtn();
        }

        public void ClickGoToCartBtn()
        {
            itemAbstract.ClickGoToCartBtn();
        }

        public string GetItemTitle()
        {
            return itemAbstract.GetItemTitle();
        }

        public string GetPrice()
        {
            return itemAbstract.GetPrice();
        }
    }
}
