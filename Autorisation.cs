using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;



namespace TestProjectNew
{    
    [TestClass]
    public class Autorisation
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
        public void OpenMyIviEntrance()
        {
            IviSession.FindElementByName("Мой ivi").Click();
            Thread.Sleep(1000);
            IviSession.FindElementByName("Войти").Click();
            Thread.Sleep(1000);
        }
        [TestMethod]
        public void EnterTheEmailSuccessful()

        {
            OpenMyIviEntrance();
            IviSession.FindElementByClassName("TextBlock").SendKeys("kivyanskaya@ivi.ru");
            Thread.Sleep(1000);
            IviSession.FindElementByClassName("Button").Click();
            Thread.Sleep(1000);
           
        }

        [TestMethod]
        public void AutoNon_ExistentMail()
        {
            OpenMyIviEntrance();
            IviSession.FindElementByClassName("TextBlock").SendKeys("111111");
            Thread.Sleep(1000);
            IviSession.FindElementByClassName("Button").Click();
            Thread.Sleep(1000);
            string a = IviSession.FindElementByName("Вы ввели несуществующий телефон или email.").Text;
            Console.WriteLine(a);
            Thread.Sleep(1000);



        }

        [TestMethod]
        public void AutoNon_ExistentMailBack()
        {
            OpenMyIviEntrance();
                IviSession.FindElementByClassName("TextBlock").SendKeys("111111");
                Thread.Sleep(1000);
                IviSession.FindElementByClassName("Button").Click();
                Thread.Sleep(1000);
                IviSession.FindElementByClassName("Button").SendKeys(Keys.Escape);
                Thread.Sleep(4000);
               
        }

        [TestMethod]
        public void ClearType()
        {
            OpenMyIviEntrance();
            IviSession.FindElementByClassName("TextBlock").SendKeys("111111");
            Thread.Sleep(1000);
            IviSession.FindElementByClassName("TextBox").Clear();
            Thread.Sleep(1000);
        }
        [TestMethod]
        public void EnterThePasswordSuccsessful()
        {
            EnterTheEmailSuccessful();
            IviSession.FindElementByClassName("PasswordBox").SendKeys("12345");
            Thread.Sleep(1000);
            IviSession.FindElementByClassName("Button").Click();
            Thread.Sleep(1000);
        }
         [TestMethod]
         public void EnterThePasswordFail()
        {
            EnterTheEmailSuccessful();
            IviSession.FindElementByClassName("PasswordBox").SendKeys("1234");
            Thread.Sleep(1000);
            IviSession.FindElementByClassName("Button").Click();
            Thread.Sleep(1000);
        }
    }
}


