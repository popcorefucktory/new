using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class Num_Fail
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
        public void num_fail()
        {
            NavigationActions.OpenMyIvi(_session);
            _session.FindElementByClassName("TextBlock").SendKeys("77777");

        }
    }
}
