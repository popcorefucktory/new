using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class PlaceholderPic
    {
        private static RemoteWebDriver _session;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _session = SetupActions.LaunchApp();
        }
        
        [ClassCleanup]
        public static void TearDown()
        {
            _session.Dispose();
            _session = null;
        }

        [TestMethod]
        public void placeholder_pic()
        {
            SearchActions.search_setup(_session);
            var backgroundImage = _session.FindElementByClassName("Image");

            Assert.IsNotNull(backgroundImage);
        }
    }
}



    

