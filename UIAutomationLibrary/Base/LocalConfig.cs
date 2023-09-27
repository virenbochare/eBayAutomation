using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;

namespace UIAutomationLibrary.Base
{
    public class LocalConfig
    {
        private readonly object EnvironmentSettings;
        public string config { get; }
        public string url { get; }
        public Viewport viewport;
        public Language language;

        public LocalConfig()
        {
            dynamic jsonFile = GetJsonFile();
            config = GetTestData(jsonFile, "Configuration");
            url = GetTestData(jsonFile, "ebayURL");
            language = (url.Contains("https://www.ebay.com/")) ? Language.EN : (url.Contains("https://www.ebay.fr/")) ? Language.FR : throw new Exception("Invalid URL " + url);
        }

        private dynamic GetJsonFile()
        {
            var dir = Path.GetDirectoryName(typeof(LocalConfig).Assembly.Location) + @"\Configs";
            var envSettingsFile = Path.Combine(dir, $"TestConfig.json");
            if (!File.Exists(envSettingsFile)) throw new Exception($"Unable to locate {envSettingsFile}");
            return JsonConvert.DeserializeObject(File.ReadAllText(envSettingsFile, System.Text.Encoding.UTF8));
        }

        private string GetTestData(dynamic jsonFile, string titleSchema)
        {
            JToken token = jsonFile.SelectToken(titleSchema);
            return token.ToString();
        }

        private T GetSetting<T>(string key)
        {
            object value = EnvironmentSettings;
            var path = key.Split('.');
            foreach (var propName in path) value = ((IDictionary<string, object>)value)[propName];
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public Viewport GetViewport()
        {
            string configViewport = config.Split('-')[2];
            switch (configViewport.ToLower().Trim())
            {
                case "large":
                    return Viewport.Large;
                case "xs":
                    return Viewport.XS;
                default:
                    throw new Exception("Invalid Viewport.");
            }
        }

        public IWebDriver GetDriverFromLocal()
        {
            ChromeOptions options = new ChromeOptions();
            Viewport viewport = GetViewport();
            switch (viewport)
            {
                case (Viewport.Large):
                    {
                        options.AddArgument("--start-maximized");
                        break;
                    }
                case (Viewport.XS):
                    {
                        options.EnableMobileEmulation("Galaxy S5");
                        break;
                    }
            }
            ChromeDriver driver = new ChromeDriver(options);
            return driver;
        }
    }
}