using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class Password_Success
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
        public void pass_right()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("kivyanskaya@ivi.ru");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("PasswordBox").SendKeys("12345");
            _session.FindElementByName("Войти").Click();
            _session.FindElementByName("OK").Click();
            var focusable = _session.FindElementByClassName("ListView"); //дать имея главной и переписать эту строку 

            Assert.IsNotNull(focusable);
        }
    }
}