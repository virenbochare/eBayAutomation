using NUnit.Framework;
using UIAutomationLibrary.Base;
using UIAutomationLibrary.Pages.AllListings;
using UIAutomationLibrary.Pages.Cart;
using UIAutomationLibrary.Pages.Home;
using UIAutomationLibrary.Pages.Item;

namespace AdvarraTests.Tests.EbayTests
{
    [TestFixture]
    public class EbayTests : Page
    {
        HomeMain homeMain;
        AllListingsMain allListingsMain;
        ItemMain itemMain;
        CartMain cartMain;
        string baseURL;
        LocalConfig localConfig;
        dynamic testDataFile;


        [OneTimeSetUp]
        public void FixtureInit()
        {
            localConfig = new LocalConfig();
            baseURL = localConfig.url;
            language = localConfig.language;
            viewport = localConfig.GetViewport();
            testDataFile = GetTestDataFile();
        }

        [SetUp]
        public void Init()
        {
            driver = localConfig.GetDriverFromLocal();
            homeMain = new HomeMain(driver, viewport, language);
            allListingsMain = new AllListingsMain(driver, viewport, language);
            itemMain = new ItemMain(driver, viewport, language);
            cartMain = new CartMain(driver, viewport, language);
            url = baseURL;
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

        [Test, Property("TestCaseId", "001")]
        public void VerifyAllTheListingsMatchSearchCriteria()
        {
            string searchText = GetTestData(testDataFile, "001.searchText");
            Open();
            homeMain.EnterTextInSearchBox(searchText);
            homeMain.ClickSearchBtn();
            Assert.IsTrue(allListingsMain.DoAllListingsMatchSearchCriteria(searchText), "Not All listings match the search criteria.");
            string titleOfTheSelectedItem = allListingsMain.GetTitle(0);
            string priceOfTheSelectedItem = allListingsMain.GetPrice(0);
            allListingsMain.ClickOnItem(0);
        }

        [Test, Property("TestCaseId", "002")]
        public void VerifyTheCorrectItemIsAddedToTheCart()
        {
            #region Variables
            string searchText = GetTestData(testDataFile, "002.searchText");
            string colorOfTheSelectedItem = string.Empty;
            string priceOfTheSelectedItem = string.Empty;
            #endregion

            Open();
            homeMain.EnterTextInSearchBox(searchText);
            homeMain.ClickSearchBtn();

            int totalListings = allListingsMain.CountAllListings();

            for (int i = 1; i < totalListings; i++)
            {
                if (i == 4)
                {
                    i = 12;
                }
                if (i == 16)
                {
                    i = 24;
                }

                allListingsMain.ClickOnItem(i);
                var windows = driver.WindowHandles;
                driver.SwitchTo().Window(windows[1]);
                if (itemMain.IsColorDropDownEnabled())
                {
                    colorOfTheSelectedItem = itemMain.GetColorFromDropDown(1);
                    itemMain.SelectItemFromColorDropDown(1);
                    if (itemMain.IsQuantityDropDownEnabled())
                    {
                        itemMain.EnterQuantity(1);
                        priceOfTheSelectedItem = itemMain.GetPrice();
                        break;
                    }
                }
                driver.Close();
                driver.SwitchTo().Window(windows[0]);
            }

            itemMain.ClickAddToCartBtn();
            itemMain.ClickGoToCartBtn();
            Assert.IsTrue(cartMain.DoesDescriptionContainSelectedColor(colorOfTheSelectedItem), "The selected item is not added on the cart.");
            Assert.IsTrue(cartMain.GetPrice().Contains(priceOfTheSelectedItem), "Price shows on Cart is incorrect.");
        }
    }
}
