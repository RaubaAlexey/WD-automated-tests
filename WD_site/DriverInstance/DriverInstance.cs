using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace WD_site.DriverInstance
{
    class DriverInstance
    {
        public static IWebDriver driver;

        public DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
