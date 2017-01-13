using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;


namespace TestProjectNew
{ 
   [TestClass]
public class Search
{


    protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/wd/hub";
    protected static RemoteWebDriver IviSession;
    protected static RemoteWebElement IviResult;
    protected static string OriginalIviMode;

    [ClassInitialize]

    public static void Setup(TestContext context)

    {
        //launch the app
        DesiredCapabilities appCapabilities = new DesiredCapabilities();
        appCapabilities.SetCapability("app", "ivi.ru.ivi-xbox_17t6d7vatm0nm!App");
        appCapabilities.SetCapability("platformName", "Windows");
        appCapabilities.SetCapability("deviceName", "WindowsPC");
        IviSession = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), appCapabilities);
        Assert.IsNotNull(IviSession);
        IviSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

        //IviSession.FindElementByName("//Button[starts-with(@Name, \"ListViewItem-14\")]").Click();
        //Assert.IsNotNull(IviResult);
    }


        [ClassCleanup]
        public static void TearDown()
    {
        IviResult = null;
        IviSession.Dispose();
        IviSession = null;
    }

        [TestMethod]
        public void OpenTheSearch()
        {
        IviSession.FindElementByName("Поиск").Click();
            Thread.Sleep(1000);
        }
        
        //[TestMethod]
        //public void TextOnTheEmptySeatchPage()
        //{
        //    OpenTheSearch();
        //    IviSession.FindElementByClassName("TextBlock").Text();
        //    Thread.Sleep(1000);
        //    //console.writeline(textemptypage);
        //    //string textemptypage = ivisession.findelementbyname("что вы ищите?").text;
        //    //thread.sleep(1000);
        //    //console.writeline(textemptypage);
        //    //string textenptypage2 = ivisession.findelementbyname("введите название фильма").text;
        //    //thread.sleep(1000);
        //    //console.writeline(textenptypage2);
        //}

        [TestMethod]
        public void PictureOnTheEmptyPage()
        {
            OpenTheSearch();
            IviSession.FindElementByClassName("image");
        }

        [TestMethod]
        public void SearchContent()
        {
            OpenTheSearch();
            IviSession.FindElementByClassName("TextBlock").SendKeys("Убить Билла");
        }

        [TestMethod]
        public void SearchContentCannotFind()
        {
            OpenTheSearch();
            IviSession.FindElementByClassName("TextBlock").SendKeys("kjdhfsoklhjosrg");
            string text = IviSession.FindElementByName("Ничего не нашлось").Text;
            Console.WriteLine(text);
            string text2 = IviSession.FindElementByName("Попробуйте как-нибудь по-другому").Text;
            Console.WriteLine(text2);
        }
     }
}
