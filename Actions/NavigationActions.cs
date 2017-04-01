using OpenQA.Selenium.Remote;


namespace TestProjectNew.Actions
{
    public static class NavigationActions
    {
        //public static object _login_by_emailSuccessfull { get; internal set; }

        public static void OpenMyIvi(RemoteWebDriver session)
            {
            session.FindElementByName("Мой ivi").Click();
            session.FindElementByName("Войти").Click();
            }
    }
}
