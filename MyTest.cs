using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace MyTest
{
    [TestClass]

    public class BasicScenarios
    {


        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/wd/hub";
        protected static RemoteWebDriver IviSession;
        protected static RemoteWebElement IviResult;
        protected static string OriginalIviMode;

        [ClassInitialize]

        public static void Setup(TestContext context)

        {
            //launch the app
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "ivi.ru.ivi-xbox_17t6d7vatm0nm!App");
            appCapabilities.SetCapability("platformName", "Windows");
            appCapabilities.SetCapability("deviceName", "WindowsPC");
            IviSession = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(IviSession);
            IviSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            //IviSession.FindElementByName("//Button[starts-with(@Name, \"ListViewItem-14\")]").Click();
            //Assert.IsNotNull(IviResult);
        }


        [ClassCleanup]
        public static void TearDown()
        {
            IviResult = null;
            IviSession.Dispose();
            IviSession = null;
        }
        //locate elements

        [TestMethod]
        public void Addition()
        {
            IviSession.FindElementByName("Поиск").Click();

            
            //Assert.AreEqual("Display is  8 ", IviResult.Text);
        }

        [TestMethod]
        public void DisableAds()
        {
            IviSession.FindElementByName("Отключить рекламу").Click();
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void CheckPSearch()
        {
            IviSession.FindElementByName("Поиск").Click();
           // string result = IviSession.FindEle("Введите название фильма").Text;
            //if (result.Equals("Что вы ищите?"))
            //{
            //    Console.WriteLine("passed");
            //}
            //else
            //{
            //    Console.WriteLine("failed");
            //}
        }

        [TestMethod]
        public void CheckPageMyIvi()
        {
            IviSession.FindElementByName("Мой ivi").Click();
            //string result = IviSession.FindElementByClassName("TextBlock");
            string result = IviSession.FindElementByClassName("TextBlock").Text;
            
            Thread.Sleep(3000);
            if (result.Equals("TextBlock"))
            {
                Console.WriteLine("passed");
            }
            else
            {
                Console.WriteLine("failed");

            }
            Console.WriteLine(result);
        }
    }
}
   
