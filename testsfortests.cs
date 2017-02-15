using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TestProjectNew.Actions;
using OpenQA.Selenium.Chrome;

namespace TestProjectNew

{
    [TestClass]
    public class testsfortests
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

        public void madeEntrance()
        {
            _session.FindElementByName("Мой ivi").Click();
            var madeEntrance = _session.FindElementByName("Профиль");
            if (madeEntrance != null)
            {
                _session.FindElementByName("Профиль").Click();
                _session.FindElementByName("Выйти").Click();
                Thread.Sleep(3000);
                _session.FindElementByName("Да").Click();

            }
        }



        [TestMethod]
        public void Logout()
        {
            _session.FindElementByName("Мой ivi").Click();
            _session.FindElementByName("Профиль").Click();
            _session.FindElementByName("Выйти").Click();
            Thread.Sleep(3000);
            _session.FindElementByName("Да").Click();
        }

        

        [TestMethod]
        public void IfLanding()
        {
            var a = _session.FindElementByName("ПОДКЛЮЧИТЕ ПРЕМИУМ-ПОДПИСКУ ivi+").Text;
            Console.WriteLine(a);
            Assert.IsNotNull(a);

        }

        //[TestMethod]
        //public void ScrollDown()
        //{

        //    IWebElement a =_session.FindElementByClassName("ListView"); 
        //    IWebElement b = _session.FindElementByClassName("Button");
        //   // IWebElement c = _session.FindElementByName("TextBlock");
        //    Actions builder = new Actions(_session);
        //    builder.MoveToElement(a).Build().Perform();   
        //    Thread.Sleep(5000);
        //    builder.MoveToElement(b).Build().Perform();   
        //    Thread.Sleep(1000);
        //    //builder.MoveToElement(c).Build().Perform();
        //    //Thread.Sleep(1000);

        
           
        //}
    }
}



    