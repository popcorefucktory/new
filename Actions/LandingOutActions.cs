using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestProjectNew.Actions
{
    public static class LandingOutActions
    {
        public static void LandingOut(RemoteWebDriver session)
        {
            session.FindElementByName("landing").SendKeys(Keys.Meta + Keys.Backspace);
        }
    }
}
