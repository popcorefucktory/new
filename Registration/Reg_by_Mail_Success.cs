using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew
{

    [TestClass]
    public class Reg_by_Mail_Success
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
        public void registrationByMail_success()
        {
            NavigationActions.OpenMyIvi(_session);
            _session.FindElementByName("Регистрация").Click();
            ChromeDriver EmailGenerator = new ChromeDriver();
            EmailGenerator.Url = "http://www.yopmail.com/ru/email-generator.php";
            EmailGenerator.Navigate();

            var randomMail = EmailGenerator.FindElementByXPath("//*[@id='login']").GetAttribute("value");
            _session.FindElementByClassName("TextBlock").SendKeys(randomMail);
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("TextBlock").SendKeys("1");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("ScrollViewer").Click();
            _session.FindElementByClassName("Button").Click();

            var maintheme = _session.FindElementByClassName("ListView");
            Assert.IsNotNull(maintheme);
        }

    }
}
