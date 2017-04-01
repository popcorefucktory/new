using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class SafeSearch
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
        public void safe_search()
        {
            SearchActions.search_setup(_session);
            _session.FindElementByClassName("TextBlock").SendKeys("Голограмма");
            _session.FindElementByClassName("TextBlock").SendKeys(Keys.Tab);
            var a = _session.FindElementByClassName("TextBlock").Text;
            Console.WriteLine(a);
            if (a.Equals("18+"))
            {
                _session.FindElementByClassName("TextBlock").SendKeys(Keys.Meta + Keys.Backspace);
                _session.FindElementByName("myivi").Click();
                _session.FindElementByName("Настройки").Click();
                _session.FindElementByName("_safesearch").Click();
                _session.FindElementByClassName("TextBlock").SendKeys("Голограмма");
                var b = _session.FindElementByClassName("TextBlock").Text;
            }
            //додумать
        }
        

    }
}



    

