using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;
using OpenQA.Selenium;

namespace TestProjectNew
{
    [TestClass]
    public class ContentCard
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
        public void AVODcard_new()
        {

        }

        [TestMethod]
        public void AVODcard_watched()
        {

        }

        [TestMethod]
        public void SVODcard_new()
        {

        }

        [TestMethod]
        public void SVODcard_watched()
        {

        }

        [TestMethod]
        public void TVOD_ESTcard_new()
        {

        }

        [TestMethod]
        public void TVOD_ESTcard_watched()
        {

        }
    }
}
