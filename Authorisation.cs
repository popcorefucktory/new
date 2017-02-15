using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;
using TestProjectNew.Actions;
using OpenQA.Selenium.Chrome;

namespace TestProjectNew
{
    [TestClass]
    public class Authorisation
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
        public void OpenMyIviEntrance()
        {
            // Act
            NavigationActions.OpenMyIvi(_session);

            // Assert

            Assert.IsNotNull(_session.FindElementByName("Вход"));
            
        }

        [TestMethod]
        public void EnterTheEmailSuccessful()
        {
            // Arrange
            NavigationActions.OpenMyIvi(_session);

            // Act
            _session.FindElementByClassName("TextBlock").SendKeys("kivyanskaya@ivi.ru");
            _session.FindElementByClassName("Button").Click();
            var passpage = _session.FindElementByClassName("PasswordBox");

            Assert.IsNotNull(passpage);
         
        }

        [TestMethod]
        public void AutoNon_ExistentMailVerifyPopup()
        {
            // Arrange 
            NavigationActions.OpenMyIvi(_session);

            // Act
            _session.FindElementByClassName("TextBlock").SendKeys("111111");
            _session.FindElementByClassName("Button").Click();
            string errorMsg = _session.FindElementByName("Вы ввели несуществующий телефон или email.").Text;
            Console.WriteLine(errorMsg);

            // Assert
            Assert.IsNotNull(errorMsg);
        }

        [TestMethod]
        public void AutoNon_ExistentMailPopupClickOk()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("kivyanskaya@ivi");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByName("OK").Click();
            string reg = _session.FindElementByName("Регистрация").Text;
            Console.WriteLine(reg);

            Assert.IsNotNull(reg);
        }

        [TestMethod]
        public void AutoNon_ExistentMailClickBack()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("111111");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("Button").SendKeys(Keys.Escape);
            var textBox = _session.FindElementByClassName("TextBox");

            Assert.IsNotNull(textBox);
        }

        [TestMethod]
        public void ClearType()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("111111");
            _session.FindElementByClassName("TextBox").Clear();
            Thread.Sleep(3000);
            //WaitForElementPresent;
            var c = _session.FindElementByClassName("TextBlock").Text;
            Console.WriteLine(c);

            //Assert
            
            //здесь нужно найти пустоту в поле

            //Assert проверка, что поле пусто 

        }
        [TestMethod]
        public void EnterThePasswordSuccsessful()
        {
            EnterTheEmailSuccessful();
            _session.FindElementByClassName("PasswordBox").SendKeys("12345");
            _session.FindElementByName("Войти").Click();
            _session.FindElementByName("OK").Click();
            var focusable = _session.FindElementByClassName("ListView");

            Assert.IsNotNull(focusable);
        }
        [TestMethod]
        public void EnterThePasswordFailClickOk()
        {
            EnterTheEmailSuccessful();
            _session.FindElementByClassName("PasswordBox").SendKeys("1234");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByName("OK").Click();
            var textBox = _session.FindElementByClassName("PasswordBox");

            Assert.IsNotNull(textBox);
            

        }
        [TestMethod]
        public void AuthorisationPhoneSuccess()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBox").Clear();
            _session.FindElementByClassName("TextBlock").SendKeys("79998660609");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByName("OK").Click();

            ChromeDriver openMailCatcher = new ChromeDriver();
            openMailCatcher.Url = "http://controller.kivyanskaya.notkube.v.netstream.ru:1080/";
            openMailCatcher.Navigate();

            openMailCatcher.FindElementByXPath("//*[@id='messages']/table/tbody/tr/td[2]").Click();
            var iframe = openMailCatcher.SwitchTo().Frame(openMailCatcher.FindElementByXPath("//*[@id='message']/iframe"));
            var key = openMailCatcher.FindElementByXPath("/html/body").Text;
            //Console.WriteLine(key);
            _session.FindElementByClassName("TextBlock").SendKeys(key);
            _session.FindElementByName("Войти").SendKeys(Keys.Enter);
            _session.FindElementByClassName("Button").SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            var mainTheme = _session.FindElementByClassName("ListView");

            Assert.IsNotNull(mainTheme);
        }
        [TestMethod]
        public void AuthorisationPhoneFail()
        {
            _session.FindElementByClassName("TextBlock").SendKeys("77777");

        }

        [TestMethod]
        public void AuthorisationPhoneFailVerifyPopup()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("7777");
            _session.FindElementByClassName("Button").Click();
            string errorMsg2 = _session.FindElementByName("Ошибка").Text;
            Console.WriteLine(errorMsg2);

            //Assert.IsNotNull();
            //Assert.IsNotNull(_session.FindElementByClassName("TextBox"));
        }

        [TestMethod]
        public void AuthorisationPhoneFailClickBack()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("7777777");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("Button").SendKeys(Keys.Escape);

            Assert.IsNotNull(_session.FindElementByClassName("TextBox"));
        }

        
    }
}


