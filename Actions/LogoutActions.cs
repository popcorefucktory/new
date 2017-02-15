using OpenQA.Selenium.Remote;


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
