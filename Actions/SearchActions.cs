using OpenQA.Selenium.Remote;

namespace TestProjectNew.Actions
{
    public static class SearchActions
    {
        public static void search_setup(RemoteWebDriver session)
        {
            session.FindElementByName("Поиск").Click();
            var textfield = session.FindElementByClassName("TextBox");
        }
    }
}
