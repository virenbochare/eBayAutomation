using OpenQA.Selenium;
using UIAutomationLibrary.Base;

namespace UIAutomationLibrary.Pages.Home
{
    public class HomeMain : Page
    {
        HomeAbstract homeAbstract;

        public HomeMain(IWebDriver driver, Viewport viewport, Language language)
        {
            base.driver = driver;
            base.viewport = viewport;
            base.language = language;

            switch (viewport)
            {
                case Viewport.Large:
                    homeAbstract = new HomeLarge(driver, viewport, language);
                    break;
                case Viewport.XS:
                    homeAbstract = new HomeXS(driver, viewport, language);
                    break;
            }
        }

        public void EnterTextInSearchBox(string text)
        {
            homeAbstract.EnterTextInSearchBox(text);
        }

        public void ClickSearchBtn()
        {
            homeAbstract.ClickSearchBtn();
        }
    }
}
