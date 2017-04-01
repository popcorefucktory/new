using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class SearchButNotFound
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
        public void not_found_cont()
        {
            SearchActions.search_setup(_session);
            _session.FindElementByClassName("TextBlock").SendKeys("kjdhfsoklhjosrg");
            string text = _session.FindElementByName("Ничего не нашлось").Text;
            Console.WriteLine(text);
            string text2 = _session.FindElementByName("Попробуйте как-нибудь по-другому").Text;
            Console.WriteLine(text2);

            Assert.IsNotNull(text);
            Assert.IsNotNull(text2);
        }
    }
}



    

