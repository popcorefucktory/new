using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class Num_Success
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
        public void num_suc()
        {

            //LogoutActions.LogoutAction(_session);
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBox").Clear();
            _session.FindElementByClassName("TextBlock").SendKeys("79998660609");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByName("OK").Click();

            Phone_MailCatcherActions.OpenMailcatcher(_session);

        }
    }
}