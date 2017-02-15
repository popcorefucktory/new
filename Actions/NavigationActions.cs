using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProjectNew.Actions
{
    public static class NavigationActions
    {
        public static object OpenMyIviEntrance { get; internal set; }

        public static void OpenMyIvi(RemoteWebDriver session)
            {
            session.FindElementByName("Мой ivi").Click();
            session.FindElementByName("Войти").Click();
            }


    }
}
