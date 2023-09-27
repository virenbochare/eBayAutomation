using OpenQA.Selenium;
using UIAutomationLibrary.Base;

namespace UIAutomationLibrary.Pages.AllListings
{
    public class AllListingsMain : Page
    {
        readonly AllListingsAbstract allListingsAbstract;

        public AllListingsMain(IWebDriver driver, Viewport viewport, Language language)
        {
            base.driver = driver;
            base.viewport = viewport;
            base.language = language;

            switch (viewport)
            {
                case Viewport.Large:
                    allListingsAbstract = new AllListingsLarge(driver, viewport, language);
                    break;
                case Viewport.XS:
                    allListingsAbstract = new AllListingsXS(driver, viewport, language);
                    break;
            }
        }

        public int CountAllListings()
        {
            return allListingsAbstract.CountAllListings();
        }

        public bool DoAllListingsMatchSearchCriteria(string searchText)
        {
            return allListingsAbstract.DoAllListingsMatchSearchCriteria(searchText);
        }

        public string GetTitle(int index)
        {
            return allListingsAbstract.GetTitle(index);
        }

        public string GetPrice(int index)
        {
            return allListingsAbstract.GetPrice(index);
        }

        public void ClickOnItem(int index)
        {
            allListingsAbstract.ClickOnItem(index);
        }
    }
}
