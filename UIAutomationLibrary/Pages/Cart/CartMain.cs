using OpenQA.Selenium;
using UIAutomationLibrary.Base;

namespace UIAutomationLibrary.Pages.Cart
{
    public class CartMain : Page
    {
        readonly CartAbstract cartAbstract;

        public CartMain(IWebDriver driver, Viewport viewport, Language language)
        {
            base.driver = driver;
            base.viewport = viewport;
            base.language = language;

            switch (viewport)
            {
                case Viewport.Large:
                    cartAbstract = new CartLarge(driver, viewport, language);
                    break;
                case Viewport.XS:
                    cartAbstract = new CartXS(driver, viewport, language);
                    break;
            }
        }

        public string GetPrice()
        {
            return cartAbstract.GetPrice();
        }

        public bool DoesDescriptionContainSelectedColor(string selectedColor)
        {
            return cartAbstract.DoesDescriptionContainSelectedColor(selectedColor);
        }
    }
}
