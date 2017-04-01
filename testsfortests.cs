using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TestProjectNew.Actions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Windows.Automation;


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
        public void SearchById()
        {

            _session.FindElementByName("blockbasters").Click();

            //Thread.Sleep(2000);
            //_session.FindElementByName("Мультики").Click();
            //_session.FindElementByName("genre").Click();
            //Thread.Sleep(4000);

            
            //WebElement a = _session.FindElementByXPath("//Input[@Name=\"Жанры\"]");
            //var a = _session.FindElementsByName("Жанры").Count; <-не находит по классу, находит по name
            //a.Click();
           //a.GetAttribute();
            //Console.WriteLine(a);
            //_session.FindElementByXPath("//Button[@index=\"_genreButton\"]").Click();
            //_session.FindElementByXPath("//input[@AutomationId =\"_genreButton\"]").Click();
            //_session.FindElementByXPath("//input[@Name=\"Жанры\"]").Click();
            //IWebElement a = _session.FindElementByXPath("//Button[@ClassName=\"TextBlock\"]//[@AutomationId=\"_genreButton\"]");
            //IWebElement a = _session.FindElementByXPath("//Button[@Name=\"Жанры\"]//[@AutomationId=\"_genreButton\"]");
            //IWebElement a = _session.FindElementByXPath("//Button[@AutomationId=\"_genreButton\"]");
            //IWebElement a = _session.FindElementByXPath("//Button[@AutomationId=\"_genreButton\"]//ListItem[@IsSelected=\"True\"]");

            //Thread.Sleep(2000);

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



    