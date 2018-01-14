using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WD_site.Pages
{
    class SearchPage
    {
        public const string URL = "https://www.russiantrains.com/";
        private IWebDriver driver;


        [FindsBy(How = How.XPath, Using = "//*[@class='basic']")]
        public IWebElement selectOnewayTrip;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div[1]/div/div/div/div/form/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/input")]
        public IWebElement selectDeparture;


        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div[1]/div/div/div/div/form/div[2]/div[1]/div[1]/div[2]/div/div[1]/input")]
        public IWebElement selectArrival;

        [FindsBy(How = How.Id, Using = "edit-basic-mode-legs-1-travel-date-wrapper-travel-date-input")]
        public IWebElement blockDate;

        [FindsBy(How = How.Id, Using = "edit-basic-mode-passengers-passengers-field-number")]
        public IWebElement blockPassengers;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div[1]/div/div/div/div/form/div[2]/div[2]/div/div[2]/div[1]/div/span/div[2]")]
        public IWebElement blockAdults;
        [FindsBy(How = How.Id, Using = "edit-basic-mode-passengers-passengers-field-wrapper-adults")]
        public IWebElement blockAdultsWrong;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div[1]/div/div/div/div/form/div[2]/div[2]/div/div[2]/div[2]/div[1]/div/span/div[2]")]
        public IWebElement blockChild;
        [FindsBy(How = How.Id, Using = "edit-basic-mode-passengers-passengers-field-wrapper-children-children-number")]
        public IWebElement blockChildWrong;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div[1]/div/div/div/div/form/div[2]/div[2]/div/div[2]/div[2]/div[2]/div[1]/div/a/span")]
        public IWebElement blockAge;

        [FindsBy(How = How.Id, Using = "edit-basic-mode-actions-submit")]
        public IWebElement buttonSubmit;

        [FindsBy(How = How.XPath, Using = "//*[@class='select-btn']")]
        public IWebElement buttonSelect;

        [FindsBy(How = How.Id, Using = "edit-main-trains-train-0-coach-classes-coach-class-0-radio")]
        public IWebElement radioButtonSeat;

        [FindsBy(How = How.Id, Using = "edit-main-trains-train-0-coach-classes-actions-submit")]
        public IWebElement buttonFinishSubmit;



        [FindsBy(How = How.Id, Using = "edit-legs-1-all-passengers-passenger-1-fields-rzd-passenger-form-first-name")]
        public IWebElement inputFirstName;
        [FindsBy(How = How.Id, Using = "edit-legs-1-all-passengers-passenger-1-fields-rzd-passenger-form-last-name")]
        public IWebElement inputLastName;
        [FindsBy(How = How.Id, Using = "edit-legs-1-all-passengers-passenger-1-fields-rzd-passenger-form-id-number")]
        public IWebElement inputPhone;
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/main/form/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[4]/div/a")]
        public IWebElement inputCitizen;
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/main/form/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[5]/div/div[1]/div/a")]
        public IWebElement inputDay;
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/main/form/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[5]/div/div[2]/div/a")]
        public IWebElement inputMonth;
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/main/form/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[5]/div/div[3]/div/a")]
        public IWebElement inputYear;
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/main/form/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[6]/div/a")]
        public IWebElement inputGender;

        [FindsBy(How = How.Id, Using = "edit-legs-1-all-passengers-passenger-1-fields-save-details-button")]
        public IWebElement buttonSaveDetails;

        string errorBlock = "//*[@class='messages__list']";
        string inputCount = "//*[@aria-valuenow='{0}']";
        string inputDate = "//*[@data-month='{0}']/a[text()='{1}']";




        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(URL);
            Console.WriteLine("Search page opened");
        }



        public void setDeparture(string departure)
        {

            selectDeparture.SendKeys(departure);
            Thread.Sleep(1000);
            selectDeparture.SendKeys(OpenQA.Selenium.Keys.Enter);
            selectDeparture.Click();
        }

        public void setArrival(string arrival)
        {
            selectArrival.SendKeys(arrival);
            Thread.Sleep(1000);
            selectArrival.SendKeys(OpenQA.Selenium.Keys.Enter);
            selectArrival.Click();

        }

        public void setDate(int month, int day)
        {
            blockDate.Click();
            IWebElement buttonDate = blockDate.FindElement(By.XPath(String.Format(inputDate, month, day)));
            buttonDate.Click();
        }

        public void SetAdultCount()
        {
            blockPassengers.Click();
            blockAdults.Click();
        }

        public void SetWrongAdultCount(string count)
        {
            blockPassengers.Click();

            blockAdultsWrong.SendKeys(OpenQA.Selenium.Keys.Backspace);
            blockAdultsWrong.SendKeys(count);

            blockAdultsWrong.Click();
        }


        public void SetWrongChildCount(string count)
        {
            blockPassengers.Click();

            blockChildWrong.SendKeys(OpenQA.Selenium.Keys.Backspace);
            blockChildWrong.SendKeys(count);

            blockChildWrong.Click();
        }

        public void SetChildrenCount()
        {
            blockChild.Click();
        }



        public void SetInfoPass(string fname, string lname, string phone)
        {
            inputFirstName.Click();
            inputFirstName.SendKeys(fname);
            inputLastName.Click();
            inputLastName.SendKeys(lname);

            inputPhone.Click();
            inputPhone.SendKeys(phone);

            inputCitizen.Click();
            inputCitizen.SendKeys(OpenQA.Selenium.Keys.Enter);

            inputDay.Click();
            inputDay.SendKeys(OpenQA.Selenium.Keys.Enter);
            inputMonth.Click();
            inputMonth.SendKeys(OpenQA.Selenium.Keys.Enter);
            inputYear.Click();
            inputYear.SendKeys(OpenQA.Selenium.Keys.Enter);

            inputGender.Click();
            inputGender.SendKeys(OpenQA.Selenium.Keys.Enter);
        }



        public void Submit()
        {
            if (buttonSubmit.Enabled)
            {
                Console.WriteLine("Submit enable");
                buttonSubmit.Click();
            }
            else
            {
                Console.WriteLine("Submit not enable");
            }
        }


        public void Select()
        {
            if (radioButtonSeat.Enabled)
            {
                Console.WriteLine("Select enable");
                buttonSelect.Click();
                radioButtonSeat.Click();
            }
            else
            {
                Console.WriteLine("Select not enable");
            }
        }


        public void Finish()
        {
            if (buttonFinishSubmit.Enabled)
            {
                Console.WriteLine("Finish enable");
                buttonFinishSubmit.Click();
            }
            else
            {
                Console.WriteLine("Finish not enable");
            }
        }

        public void SaveDetails()
        {
            if (buttonSaveDetails.Enabled)
            {
                Console.WriteLine("SaveDetails enable");
                buttonSaveDetails.Click();
            }
            else
            {
                Console.WriteLine("SaveDetails not enable");
            }
        }


        public bool IsSubmitEnabled()
        {
            return buttonSubmit.Enabled;
        }

        public bool IsSelectEnabled()
        {
            return buttonSelect.Enabled;
        }

        public bool IsFinishEnabled()
        {
            return buttonFinishSubmit.Enabled;
        }

        public bool IsSaveEnabled()
        {
            return buttonSaveDetails.Enabled;
        }

        public bool IsErrorBlockExist()
        {
            try
            {
                driver.FindElement(By.XPath(errorBlock));
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

    }
}
