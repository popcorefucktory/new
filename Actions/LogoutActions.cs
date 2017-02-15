using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectNew.Actions
{
    public static class LogoutActions

    {
        public static void LogoutAction(RemoteWebDriver session)

        {
            session.FindElementByName("Мой ivi").Click();
            session.FindElementByName("Профиль").Click();
            session.FindElementByName("Выйти").Click();
            session.FindElementByName("Да").Click();
        }
    }
}
