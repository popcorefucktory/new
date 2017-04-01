using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;



namespace TestProjectNew.Actions
{
    public static class LaunchFiddlerAcions
    {

        private const string WindowsApplicationDriverUrl2 = "http://127.0.0.1:4723/wd/hub";

        public static RemoteWebDriver LaunchFiddler()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", @"{7C5A40EF - A0FB - 4BFC - 874A - C0F2E0B9FA8E}\Fiddler2\Fiddler.exe");
            appCapabilities.SetCapability("platformName", "Windows");
            appCapabilities.SetCapability("deviceName", "WindowsPC");
            var launchfiddler = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl2), appCapabilities);
            Assert.IsNotNull(launchfiddler);
            launchfiddler.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
            return launchfiddler;
        }

    }
}
