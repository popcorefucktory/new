using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class Clear_Input
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
        public void clearType()
        {
            NavigationActions.OpenMyIvi(_session);

            //_session.FindElementByClassName("TextBlock").SendKeys("111111");
            //_session.FindElementByClassName("TextBox").Clear();
            //Thread.Sleep(3000);
            ////WaitForElementPresent;
            //var c = _session.FindElementByClassName("TextBlock").Text;
            ////Console.WriteLine(c);

            _session.FindElementByClassName("TextBox").SendKeys("111111");
            _session.FindElementByClassName("TextBox").Clear();
            Thread.Sleep(3000);
            //WaitForElementPresent;
            var c = _session.FindElementByClassName("TextBox").Text;

            //_session.FindElementByName("mail_or_phone_input").SendKeys("111111");
            //_session.FindElementByClassName("TextBox").Clear();
            //Thread.Sleep(3000);
            ////WaitForElementPresent;
            //var c = _session.FindElementByName("mail_or_phone_input").Text;
            ////Console.WriteLine(c);

            Assert.IsNotNull(c);

        }
    }
}
