using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;
using TestProjectNew.Actions;
namespace TestProjectNew
{
    [TestClass]
    public class Scroll
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
        public void ScrollDown()
        {

            var a = _session.FindElementByClassName("Button");
            a.SendKeys(Keys.PageDown);
            
            //IJavaScriptExecutor js = (IJavaScriptExecutor)_session;
            //js.ExecuteScript("scrollBy(0, 2500)");
            //((IJavaScriptExecutor)_session).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

            //((IJavaScriptExecutor)_session).ExecuteScript("window.scrollBy(0,250)", "");

            //((IJavaScriptExecutor)_session).ExecuteScript("arguments[0].scrollIntoView();", _session.FindElementByClassName("TextBlock')]"));

            //IWebElement element = _session.FindElementByClassName("Button");
            //ICoordinates coordinate = ((ILocatable)element).GetType();


            //Point item = _session.FindElementByClassName("Button").Location();
            //((IJavaScriptExecutor)_session).ExecuteScript("return window.title;");
            //Thread.Sleep(6000);
            //((IJavaScriptExecutor)_session).ExecuteScript("window.scrollBy(0," + (item.getY()) + ");");


            //IJavaScriptExecutor ja = _session as IJavaScriptExecutor;
            //ja.ExecuteScript("window.scrollBy(0,(window.scrollTo(MaxY));");
            //Console.Read();
            //((IJavaScriptExecutor)getDriver()).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            //((IJavaScriptExecutor)_session).ExecuteScript("window.scrollBy(" + 307 + "," + 556 + ");");


            //IWebElement a = _session.FindElementByClassName("ListView");
            //IWebElement b = _session.FindElementByClassName("Button");

            //Actions actions = new Actions(_session);
            //actions.moveToElement(b);
            //actions.perform();


            //var elem = _session.FindElementByClassName("ListView");
            //((IJavaScriptExecutor)_session).ExecuteScript("arguments[]".scrollIntoView(true):", elem);
        }


    }
}








