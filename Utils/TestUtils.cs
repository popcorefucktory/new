using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestProjectNew
{ 
    public class TestUtils
    {
        public static void set_en_keyboard_layout(RemoteWebDriver _session, IWebElement textField)
        {
            textField.SendKeys("z");
            bool isRu = !textField.Text.Equals("z");
            textField.Clear();
            if (isRu)
            {
                IKeyboard kb = _session.Keyboard;
                kb.PressKey(Keys.Shift + Keys.LeftAlt);
                kb.ReleaseKey(Keys.Shift + Keys.LeftAlt);
            }
        }
    }
}
