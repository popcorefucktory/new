using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class SimpleSearch
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
        //не удалось найти по названию в окне Поиска и пришлось писать с переходом на страницу
        public void SearchContent()
        {
            SearchActions.search_setup(_session);
            _session.FindElementByClassName("TextBlock").SendKeys("Фиксики");
            _session.FindElementByClassName("TextBlock").SendKeys(Keys.Tab);
            _session.FindElementByClassName("Button").SendKeys(Keys.Enter);
            var pagename = _session.FindElementByName("Фиксики").Text;
            Console.WriteLine(pagename);

            Assert.IsNotNull(pagename);

            //var thefoundcontent = _session.FindElementById("_textBlockTitle");
            //Console.WriteLine(thefoundcontent);
            //Assert.IsNotNull(thefoundcontent);
        }
    }
}



    

