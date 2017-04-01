using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace TestProjectNew.Actions
{
    public static class GenerateCertActions
    {
        public static string GenerateCert(RemoteWebDriver session)
        {

            ChromeDriver openCertificate_pool = new ChromeDriver();
            openCertificate_pool.Url = "http://webadmin.kivyanskaya.notkube.v.netstream.ru/waprofit/certificate_pool/"; //открывает страницу
            openCertificate_pool.Navigate();
            openCertificate_pool.FindElementById("id_username").SendKeys("da");
            openCertificate_pool.FindElementById("id_password").SendKeys("111111");
            openCertificate_pool.FindElementByXPath("//input[@value='Войти']").Click();
            openCertificate_pool.FindElementByXPath("//*[@id='toolbar_button_add']").Click(); //добавить сертификат
            openCertificate_pool.FindElementById("id_partner").SendKeys(Keys.Down + Keys.Enter); //выбрать партнёра сертификата
            openCertificate_pool.FindElementById("id_title").SendKeys("Cert for $");
            openCertificate_pool.FindElementById("id_certificate_pool_category").SendKeys(Keys.Down); 
            openCertificate_pool.FindElementById("id_description").SendKeys(Keys.Enter);
            openCertificate_pool.FindElementById("id_description").SendKeys(Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab);
            openCertificate_pool.FindElementById("id_credit_b2b_certificate_money_sum").SendKeys(Keys.Down + Keys.Enter); //выбрать сумму
            openCertificate_pool.FindElementById("id_credit_bonus_certificate_money_sum").SendKeys(Keys.Down + Keys.Enter); //выбрать сумму бонуса
            openCertificate_pool.FindElementById("id_count_certificate").Clear(); //удалить 0 в количестве добавляемых сертификатов 
            openCertificate_pool.FindElementById("id_count_certificate").SendKeys("1"); //добавить количество сертификата в размере 1
            openCertificate_pool.FindElementByXPath("//*[@id='the_one_and_the_only_form']/div[2]/input").Click(); //добавить
            openCertificate_pool.FindElementByXPath("//*[@id='data_table']/tbody/tr[2]/td[2]/div").Click(); //выбрать сертификат в таблице 
            openCertificate_pool.FindElementByXPath("//*[@id='data_table']/tbody/tr[2]/td[4]/div").Click(); //войти в него
            openCertificate_pool.FindElementByXPath("//*[@id='id_notes']").SendKeys(Keys.Tab); //спуститься ниже 
            openCertificate_pool.FindElementByXPath("//*[@id='id_finish_time']").SendKeys(Keys.Enter + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab); //спуститься ниже
            openCertificate_pool.FindElementByXPath("//*[@id='form_tr_for_count_certificate']/td/div/div[1]/a").Click(); //кликнуть "сертификаты пула"
            string a = openCertificate_pool.FindElementById("id='data_table']/tbody/tr[2]/td[4]/div").Text; //взять текст у первого сертификата сверху
            Console.WriteLine(a);
        //    openCertificate_pool.FindElementByXPath("//*[@id='SubTubs']/ul/li/ul/li[27]/a").Click(); // прежний вариант клика по пулам сертификата
            openCertificate_pool.FindElementByXPath("//a[@href='/waprofit/certificate_pool/']").Click(); //кликнуть пулы сертификата
            openCertificate_pool.FindElementByXPath("//*[@id='data_table']/tbody/tr[2]/td[1]/div/input").Click(); //выбрать чекбокс сертификата
            openCertificate_pool.FindElementByXPath("//*[@id='toolbar_button_delete']").Click(); //удОли
            openCertificate_pool.FindElementByXPath("/html/body/div[5]/div[11]/div/button[1]/span").Click(); //подтвердить удаление
            return a;
            


            //var iframe = openCertificate_pool.SwitchTo().Frame(openCertificate_pool.FindElementByXPath("//*[@id='message']/iframe"));
            //var key = openCertificate_pool.FindElementByXPath("/html/body").Text;
            //Console.WriteLine(key);
            //session.FindElementByClassName("TextBlock").SendKeys(key);
            //session.FindElementByName("Войти").SendKeys(Keys.Enter);
            //session.FindElementByClassName("Button").SendKeys(Keys.Enter);
            //Thread.Sleep(3000);

            //var mainTheme = session.FindElementByClassName("ListView");
            //Assert.IsNotNull(mainTheme);
        }
    }
}