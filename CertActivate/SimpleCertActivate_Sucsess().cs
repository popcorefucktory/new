using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew

{
    [TestClass]
    public class SimpleCertActivate
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
        public void SimpleCertActivate_Sucsess()
        {

            var a = GenerateCertActions.GenerateCert(_session);
            _session.FindElementByName("myivi").Click();
            _session.FindElementByName("Активировать сертификат").Click();
            _session.FindElementByClassName("TextBox").SendKeys(a);

        }
    }
}
