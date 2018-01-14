using OpenQA.Selenium;
using System;
using System.Threading;
using WD_site.Pages;

namespace WD_site.Steps
{
    class Steps
    {
        IWebDriver driver;

        public string defaultDeparture = "Helsinki";
        public string defaultArrival = "Moscow";

        public string wrongInfo = "☻☻☻☻";


        public void InitBrowser()
        {
            driver = DriverInstance.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            DriverInstance.DriverInstance.CloseBrowser();
        }



        public static void ChangeSysDate(int day)
        {
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.CreateNoWindow = true;
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/C date " + day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
            System.Diagnostics.Process.Start(proc);
        }


        public void SearchEmpty(string departure, string arrival, int month, int day)
        {
            SearchPage sPage = new SearchPage(driver);
            sPage.OpenPage();

            int curDay = DateTime.Now.Day;
            ChangeSysDate(day);
            sPage.setDate(month-1, day);

            sPage.setDeparture(departure);

            sPage.Submit();
            ChangeSysDate(curDay);
        }

        public void SearchSame(string departure, string arrival, int month, int day)
        {
            SearchPage sPage = new SearchPage(driver);
            sPage.OpenPage();

            int curDay = DateTime.Now.Day;
            ChangeSysDate(day);
            sPage.setDate(month - 1, day);

            sPage.setDeparture(departure);
            sPage.setArrival(arrival);

            sPage.Submit();
            ChangeSysDate(curDay);
        }

        public void SearchDate(int month, int day)
        {
            int curDay = DateTime.Now.Day;
            ChangeSysDate(day);

            SearchPage sPage = new SearchPage(driver);
            sPage.OpenPage();


            sPage.setDate(month - 1, day);

            sPage.setDeparture(defaultDeparture);
            sPage.setArrival(defaultArrival);

            ChangeSysDate(curDay);
            sPage.Submit();

        }

        public void SearchPeoples(int month, int day)
        {
            SearchPage sPage = new SearchPage(driver);
            sPage.OpenPage();

            int curDay = DateTime.Now.Day;
            ChangeSysDate(day);
            sPage.setDate(month - 1, day);

            sPage.setDeparture(defaultDeparture);
            sPage.setArrival(defaultArrival);

            sPage.SetAdultCount();
            sPage.SetChildrenCount();

            sPage.Submit();
        }

        public void SearchWrongCount(string count, int month, int day)
        {
            SearchPage sPage = new SearchPage(driver);
            sPage.OpenPage();


            int curDay = DateTime.Now.Day;
            ChangeSysDate(day);
            sPage.setDate(month - 1, day);

            sPage.setDeparture(defaultDeparture);
            sPage.setArrival(defaultArrival);

            sPage.SetWrongAdultCount(count);

            sPage.Submit();
        }


        public void SearchWrongChildCount(string count, int month, int day)
        {
            SearchPage sPage = new SearchPage(driver);
            sPage.OpenPage();


            int curDay = DateTime.Now.Day;
            ChangeSysDate(day);
            sPage.setDate(month - 1, day);

            sPage.setDeparture(defaultDeparture);
            sPage.setArrival(defaultArrival);

            sPage.SetWrongChildCount(count);

            sPage.Submit();
        }


        public void SearchNormalData(string departure, string arrival, int month, int day, string fname, string lname, string phone)
        {
            SearchPage sPage = new SearchPage(driver);
            sPage.OpenPage();

            sPage.setDate(month - 1, day);

            sPage.setDeparture(defaultDeparture);
            sPage.setArrival(defaultArrival);

            sPage.SetAdultCount();



            sPage.Submit();
            sPage.Select();
            sPage.Finish();
            sPage.SetInfoPass(fname, lname, phone);
            sPage.SaveDetails();
        }

        public bool Error()
        {
            return new SearchPage(driver).IsErrorBlockExist();
        }

        public bool IsSubmit()
        {
            return new SearchPage(driver).IsSubmitEnabled();
        }

        public bool IsSelect()
        {
            return new SearchPage(driver).IsSelectEnabled();
        }

        public bool IsFinish()
        {
            return new SearchPage(driver).IsFinishEnabled();
        }

        public bool IsSave()
        {
            return new SearchPage(driver).IsSaveEnabled();
        }
    }
}
