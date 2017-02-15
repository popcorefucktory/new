using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TestProjectNew.Actions;


namespace TestProjectNew
{
    [TestClass]
    public class Search
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
        public void OpenTheSearch()
        {
            _session.FindElementByName("Поиск").Click();
            var textfield = _session.FindElementByClassName("TextBox");

            Assert.IsNotNull(textfield);

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
            var backgroundImage = _session.FindElementByClassName("Image");

            Assert.IsNotNull(backgroundImage);
        }

        [TestMethod]
        //не удалось найти по названию в окне Поиска и пришлось писать с переходом на страницу
        public void SearchContent()
        {
            OpenTheSearch();
            _session.FindElementByClassName("TextBlock").SendKeys("Фиксики");
            _session.FindElementByClassName("TextBlock").SendKeys(Keys.Tab);
            _session.FindElementByClassName("Button").SendKeys(Keys.Enter);
            var pagename = _session.FindElementByName("Фиксики").Text;
            Console.WriteLine(pagename);

            Assert.IsNotNull(pagename);

            //var thefoundcontent = _session.FindElementById("_textBlockTitle");
            //Console.WriteLine(thefoundcontent);
            //Assert.IsNotNull(thefoundcontent);
        }

        [TestMethod]
        public void SearchContentCannotFind()
        {
            OpenTheSearch();
            _session.FindElementByClassName("TextBlock").SendKeys("kjdhfsoklhjosrg");
            string text = _session.FindElementByName("Ничего не нашлось").Text;
            Console.WriteLine(text);
            string text2 = _session.FindElementByName("Попробуйте как-нибудь по-другому").Text;
            Console.WriteLine(text2);

            Assert.IsNotNull(text);
            Assert.IsNotNull(text2);
        }
       

    }
}
    

