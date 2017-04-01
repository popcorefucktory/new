using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace TestProjectNew.Actions
{
    public static class ScrollActions
    {
        public static void ScrollDown(RemoteWebDriver session)

        { 

            var a = session.FindElementByClassName("Button");
            a.SendKeys(Keys.PageDown);

        }
        public static void ScrollUp(RemoteWebDriver session)
        {
            var b = session.FindElementByClassName("Button");
            b.SendKeys(Keys.PageUp);
        }
    }
}
