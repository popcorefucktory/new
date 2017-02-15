using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestProjectNew.Actions
{
    public static class OpenContent18Actions
    {

        public static void Open18(RemoteWebDriver session)
        {
            session.FindElementByName("Поиск").Click();
            var textfield = session.FindElementByClassName("TextBox");
            session.FindElementByClassName("TextBlock").SendKeys("Убить Билла");
            session.FindElementByClassName("TextBlock").SendKeys(Keys.Tab);
            session.FindElementByClassName("Button").SendKeys(Keys.Enter);

        }
    }
}
