using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew
{

    [TestClass]
    public class Reg_by_Num_Success
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
        public void Reg_by_num_suc()

        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("79999999999");
            _session.FindElementByName("Регистрация").Click();
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("Button").SendKeys(Keys.Enter);
            Phone_MailCatcherActions.OpenMailcatcher(_session);
            var maintheme = _session.FindElementByClassName("ListView");

            Assert.IsNotNull(maintheme);
         }
    }
}
