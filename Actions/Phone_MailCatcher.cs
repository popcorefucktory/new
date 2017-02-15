using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace TestProjectNew.Actions
{
    public static class Phone_MailCatcherActions
    {
        public static void OpenMailcatcher(RemoteWebDriver session)
        {

            ChromeDriver openMailCatcher = new ChromeDriver();
            openMailCatcher.Url = "http://controller.kivyanskaya.notkube.v.netstream.ru:1080/";
            openMailCatcher.Navigate();
            openMailCatcher.FindElementByXPath("//*[@id='messages']/table/tbody/tr/td[2]").Click();
            //openMailCatcher.FindElementByXPath("//*[@id='message']/header/nav/ul/li[4]/a/span").Click();
            //var key = openMailCatcher.FindElementById("/html/body/table/tbody/tr/td[2]").Text;
            //Console.WriteLine(key);
            var iframe = openMailCatcher.SwitchTo().Frame(openMailCatcher.FindElementByXPath("//*[@id='message']/iframe"));
            var key = openMailCatcher.FindElementByXPath("/html/body").Text;
            Console.WriteLine(key);
            session.FindElementByClassName("TextBlock").SendKeys(key);
            session.FindElementByName("Войти").SendKeys(Keys.Enter);
            session.FindElementByClassName("Button").SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            var mainTheme = session.FindElementByClassName("ListView");
            Assert.IsNotNull(mainTheme);
        }
    }
}