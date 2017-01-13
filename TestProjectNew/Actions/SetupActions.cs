using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectNew.Actions
{
    public static class SetupActions
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/wd/hub";

        public static RemoteWebDriver LaunchApp()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "ivi.ru.ivi-xbox_17t6d7vatm0nm!App");
            appCapabilities.SetCapability("platformName", "Windows");
            appCapabilities.SetCapability("deviceName", "WindowsPC");
            var iviSession = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(iviSession);
            iviSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
            return iviSession;
        }

    }
}
