using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class TheLoginWindow
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
        public void loginWin()
        {
            // Act
            NavigationActions.OpenMyIvi(_session);

            // Assert

            Assert.IsNotNull(_session.FindElementByName("Вход"));

        }
    }
}