using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestProjectNew.Actions
{
    public static class Popup18plusActions
    {

        public static void plus_popup(RemoteWebDriver session)
        {
            session.FindElementByName("search").Click();
            var textfield = session.FindElementByClassName("TextBox");
            session.FindElementByClassName("TextBlock").SendKeys("Эскорт");
            session.FindElementByClassName("TextBlock").SendKeys(Keys.Tab);
            session.FindElementByClassName("Button").SendKeys(Keys.Enter);
        }
    }
}
