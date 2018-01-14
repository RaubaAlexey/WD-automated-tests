using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WD_site.Pages;
using WD_site.Steps;

namespace WD_site
{
    [TestFixture]
    public class russiantrainsTests
    {

        Steps.Steps steps = new Steps.Steps();
        public string defaultDeparture = "Helsinki";
        public string defaultArrival = "Moscow";

        public string dafaultAdult = "";
        public string defaultAge = "5";
        public string wrongAdultCount = "-2";
        public string wrongChildCount = "☻☻☻☻";

        public string wrongFName = "☻☻☻";
        public string wrongLName = "☺☺☺";
        public string phone = "";

        public int yesterDay = DateTime.Now.Day - 1;


        public string unknownSymbol = "☻☻☻";



        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        
        // 1. Тест на пустое поле.
        [Test]
        public void errorArrival()
        {
            steps.SearchEmpty(defaultDeparture, "", DateTime.Now.Month, DateTime.Now.Day);
            Assert.AreEqual(steps.Error(), true);
        }



        // 2. Тест на поездку в прошлое.
        [Test]
        public void ErrorDate()
        {
            steps.SearchDate(DateTime.Now.Month, yesterDay);
            Assert.AreEqual(steps.IsSubmit(), true);
        }



        // 3. Тест на одинаковы пункты прибытия и отправления.
        [Test]
        public void SameDepartureArrival()
        {
            steps.SearchSame(defaultDeparture, defaultDeparture, DateTime.Now.Month, DateTime.Now.Day);
            Assert.AreEqual(steps.Error(), true);
        }

        
        // 4. Тест на отрицательное количество пассажиров.
        [Test]
        public void ErrorCountPass()
        {
            steps.SearchWrongCount(wrongAdultCount, DateTime.Now.Month, DateTime.Now.Day);
            Assert.AreEqual(steps.IsSubmit(), true);
        }
        

        // 5. Тест на огромное количество пассажиров.
        [Test]
        public void ErrorBigCountPass()
        {
            steps.SearchWrongCount("5555", DateTime.Now.Month, DateTime.Now.Day);
            Assert.AreEqual(steps.IsSubmit(), true);
        }

        
        // 6. Тест на пустое поле возраста детей.
        [Test]
        public void ErrorAgeChild()
        {
            steps.SearchPeoples(DateTime.Now.Month, DateTime.Now.Day);
            Assert.AreEqual(steps.Error(), true);
        }
        

        // 7. Тест на символьное количество.
        [Test]
        public void ErrorChildCount()
        {
            steps.SearchWrongChildCount(wrongChildCount, DateTime.Now.Month, DateTime.Now.Day);
            Assert.AreEqual(steps.IsSubmit(), true);
        }

        // 8. Тест на некорректные данные заказа.
        // 9. Тест на пустые поля для заказа
        [Test]
        public void ErrorData()
        {
            steps.SearchNormalData(defaultDeparture, defaultArrival, DateTime.Now.Month, DateTime.Now.Day+4, wrongFName, wrongLName, phone);

            Assert.AreEqual(steps.Error(), true);
        }

    }


}
