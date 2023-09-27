using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UIAutomationLibrary.Base
{
    public class Page
    {
        public IWebDriver driver;
        public Viewport viewport;
        public string url;
        public Language language;

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
            set
            {
                driver = value;
            }
        }

        public Viewport Viewport
        {
            get
            {
                return viewport;
            }
            set
            {
                viewport = value;
            }
        }

        public Language Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
            }
        }

        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        public void Open()
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                WaitForPageLoad(120);
            }
            catch (Exception)
            {
                WaitForPageLoad(120);
            }
        }

        public void WaitForPageLoad(int timeOut)
        {
            string state = string.Empty;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));

                //Checks every 500 ms whether predicate returns true otherwise keep trying till it returns ture
                wait.Until(d =>
                {
                    try
                    {
                        state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();
                    }
                    catch (InvalidOperationException)
                    {
                        //Ignore
                    }
                    catch (NoSuchWindowException)
                    {
                        //when popup is closed, switch to last windows
                        driver.SwitchTo().Window(driver.WindowHandles.Last());
                    }
                    //In IE7 there are chances we may get state as loaded instead of complete
                    return (state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase));

                });
            }
            catch (TimeoutException e)
            {
                //sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
                if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
                    throw new Exception("Exception occurred while waiting for page to load: " + e.Message);
            }
            catch (NullReferenceException e)
            {
                //sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
                if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
                    throw new Exception("Exception occurred while waiting for page to load: " + e.Message);
            }
            catch (WebDriverException e)
            {
                if (driver.WindowHandles.Count == 1)
                {
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                }
                state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();
                if (!(state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase)))
                    throw new Exception("Exception occurred while waiting for page to load: " + e.Message);
            }
        }

        public void ClickElementJS(string cssSelector)
        {
            string query = "document.querySelector('" + cssSelector + "').click()";
            ((IJavaScriptExecutor)driver).ExecuteScript(query);
        }

        private DefaultWait<IWebDriver> FluentWait(int timeOut, int interval)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeOut);
            wait.PollingInterval = TimeSpan.FromMilliseconds(interval);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait;
        }

        public IWebElement FindElement(By locator, int timeOut = 10, int interval = 500)
        {
            try
            {
                return FluentWait(timeOut, interval).Until(x => x.FindElement(locator));
            }
            catch (Exception e)
            {
                if (e.InnerException.Message.Contains("no such element") || e.InnerException.Message.Contains("An element could not be located"))
                {
                    return null;
                }
                else
                {
                    throw new Exception("Element" + locator + " not found \n\n" + e.Message);
                }
            }
        }

        public IList<IWebElement> FindElements(By locator, int timeOut = 10, int interval = 500)
        {
            try
            {
                return FluentWait(timeOut, interval).Until(x => x.FindElements(locator).Count > 0 ? x.FindElements(locator) : null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public dynamic GetTestDataFile()
        {
            var dir = Path.GetDirectoryName(typeof(LocalConfig).Assembly.Location) + @"\TestData";
            var testDataFile = Path.Combine(dir, $"TestData.json");
            return JsonConvert.DeserializeObject(File.ReadAllText(testDataFile, System.Text.Encoding.UTF8));
        }

        public string GetTestData(dynamic jsonFile, string titleSchema)
        {
            JToken token = jsonFile.SelectToken(titleSchema);
            return token.ToString();
        }

        public bool IsElementEnabled(By locator)
        {
            if (driver.FindElements(locator).Count > 0)
            {
                try
                {
                    return FindElement(locator).Enabled;
                }
                catch (Exception) { return false; }
            }
            return false;
        }

        public void WaitForElementToExistInDOM(By locator, int timeOut = 10, int interval = 300)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
                wait.PollingInterval = TimeSpan.FromMilliseconds(interval);
                wait.Timeout = TimeSpan.FromSeconds(timeOut);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch (Exception e)
            {
                throw new Exception("Exception occurred while waiting for element to become available in DOM: " + e.Message);
            }
        }
    }

    public static class Extensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                                    .GetMember(enumValue.ToString())
                                    .First()
                                    .GetCustomAttribute<TAttribute>();
        }
    }
}
