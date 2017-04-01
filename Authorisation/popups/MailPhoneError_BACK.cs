using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class MailPhoneError_BACK
    {
        private static RemoteWebDriver _session;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _session = SetupActions.LaunchApp();
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _session.Dispose();
            _session = null;
        }


        [TestMethod]
        public void click_BACK()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("111111");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("Button").SendKeys(Keys.Escape);
            var textBox = _session.FindElementByClassName("TextBox");

            Assert.IsNotNull(textBox);
        }
    }
}