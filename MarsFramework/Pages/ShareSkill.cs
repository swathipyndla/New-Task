using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Goto shareskill
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement SSbutton { get; set; }

        //goto Title
        [FindsBy(How = How.XPath, Using = "//input[@type='text'  and @name='title'] ")]
        private IWebElement Title { get; set; }

        //goto Description
        [FindsBy(How = How.XPath, Using = "//textarea[@name='description']")]
        private IWebElement Description { get; set; }

        //goto Category
        [FindsBy(How=How.XPath,Using = "//select[@name='categoryId']")]
        private IWebElement Category { get; set; }

        //goto subcategory
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")]
        private IWebElement SubCategory { get; set; } 

        //goto Tags
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper field  ']/div[@class='ReactTags__tags']/div/div/input")]
        private IWebElement Tags { get; set; }

        //goto Tags
        [FindsBy(How = How.XPath, Using = "//div[@class='ReactTags__tagInput']/input")]
        private IWebElement Tags2 { get; set; }
        
        //goto Service type radio buttons
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType']")]
        private IWebElement ServiceType { get; set; }

        //goto Hourly service
        [FindsBy(How = How.XPath, Using = "//div[1]/div/input[@name='serviceType' and @value='0']")]
        private IWebElement HourlyService { get; set; }

        //goto oneoff service
        [FindsBy(How = How.XPath, Using = "//div[2]/div/input[@name='serviceType' and @value='1']")]
        private IWebElement One_off_service { get; set; }

        //goto Location type
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType']")]
        private IWebElement LocationType { get; set; }

        //goto on-site
        [FindsBy(How = How.XPath, Using = "//div[1]/div/input[@name='locationType' and @value='0']")]
        private IWebElement Onsite { get; set; }

        //goto online
        [FindsBy(How = How.XPath, Using = "//div[2]/div/input[@name='locationType' and @value='1']")]
        private IWebElement Online { get; set; }

        //goto Startdate
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")]
        private IWebElement Startdate { get; set; }

        //go to Enddate
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")]
        private IWebElement Enddate { get; set; }

        //goto days
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private IWebElement Days { get; set; }

        //goto start time
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime']")]
         private IWebElement Start_Time {get;set;}

        //goto End time
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime']")]
         private IWebElement End_Time { get; set; }

        //goto skilltrade
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades']")]
        private IWebElement Skill_trade { get; set; }

        //goto Skillexchange
        [FindsBy(How = How.XPath, Using = "//div[1]/div/input[@name='skillTrades' and @type='radio']")]
        private IWebElement Skill_Exchange { get; set; }

        //goto credit
        [FindsBy(How = How.XPath, Using = "//div[2]/div/input[@name='skillTrades' and @type='radio']")]
        private IWebElement Credit { get; set; }

        //goto skill_Exchange for adding skills
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']/div[@class='ReactTags__tags']/div/div/input")]
        private IWebElement Add_tags { get; set; }

        //goto Credit
        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        private IWebElement Add_credit { get; set; }
         
        //goto worksamples
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement PlusIcon { get; set; }

        //goto link of uploaded document
        [FindsBy(How = How.LinkText, Using = "Doc1.txt")]
        private IWebElement Download { get; set; }

        //goto delete document
        [FindsBy(How = How.XPath, Using = "//i[@class='remove sign icon floatRight']")]
        private IWebElement Delete { get; set; }

        //goto Active
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive']")]
        private IWebElement Active { get; set; }

        //goto submit buttons
        [FindsBy(How = How.XPath, Using = "//input[@type='button']")]
        private IWebElement Buttons { get; set; }

        //goto save
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Save']")]
        private IWebElement Save { get; set; }

        //goto cancel
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Cancel']")]
        private IWebElement Cancel { get; set; }



        internal void Addingdate()
        {
            Actions actions = new Actions(Global.GlobalDefinitions.driver);



            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Share_Skill");

            //click on share skill
            SSbutton.Click();
            Thread.Sleep(2000);

            //Click on title
            Title.Click();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //clic on description
            Description.Click();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Click on Category
            actions.MoveToElement(Category).Build().Perform();
            Thread.Sleep(1000);
            IList<IWebElement> Select_Cat = Category.FindElements(By.TagName("option"));
            Console.WriteLine("List of category" + Select_Cat);
            int categorycount = Select_Cat.Count;
            for (int i = 0; i < categorycount; i++)
            {
                if (Select_Cat[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                   Select_Cat[i].Click();
                    Console.WriteLine("Category is" + Select_Cat[i].Text);
                    Base.test.Log(LogStatus.Info, "Selected Category");
                }
            }
            
            //Click on Sub Category
            actions.MoveToElement(SubCategory).Build().Perform();
            Thread.Sleep(1000);
            IList<IWebElement> Select_SubCat = SubCategory.FindElements(By.TagName("option"));
            Console.WriteLine("List of category" + Select_SubCat);
            int Scategorycount = Select_SubCat.Count;
            for (int i = 0; i < Scategorycount; i++)
            {
                if (Select_SubCat[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Sub-Category"))
                {
                    Select_SubCat[i].Click();
                    Console.WriteLine("Category is" + Select_SubCat[i].Text);
                    Base.test.Log(LogStatus.Info, "Selected Category");
                    

                }
            }

            //Add tags
            actions.MoveToElement(Tags).Build().Perform();
            string tag1 = GlobalDefinitions.ExcelLib.ReadData(2, "Tags");
            string tag2 = GlobalDefinitions.ExcelLib.ReadData(3, "Tags");
            string tag3 = GlobalDefinitions.ExcelLib.ReadData(4, "Tags");
            Tags.SendKeys(tag1);
            Tags.SendKeys(Keys.Enter);
           
            Thread.Sleep(2000);
            Tags2.Click();
           // actions.MoveToElement(Tags2).Build().Perform();
            Tags2.SendKeys(tag2);

            Thread.Sleep(1000);
            //actions.MoveToElement(Tags).Build().Perform();
            //Tags.SendKeys(tag3);



            //Select service type
            actions.MoveToElement(ServiceType).Build().Perform();
            IList<IWebElement> ST = ServiceType.FindElements(By.XPath("//div/input[@name='serviceType']/following-sibling :: label"));
            for (int i =0; i < ST.Count; i++)
            {
                Console.WriteLine("service from web" + ST[i].Text);
                if(ST[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") )
                { 
                    HourlyService.Click();
                }
                else
                {
                    One_off_service.Click();
                }
                break;
            }

            //Select Location type
            actions.MoveToElement(LocationType).Build().Perform();
            IList<IWebElement> LT = ServiceType.FindElements(By.XPath("//div/input[@name='locationType']/following-sibling :: label"));
            for (int i = 0; i < LT.Count; i++)
            {
                Console.WriteLine("service from web" + LT[i].Text);
                if (LT[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"))
                {
                    Onsite.Click();
                }
                else
                {
                    Online.Click();
                }
                break;
            }

            
            //Click on start date
            Startdate.Click();

            Thread.Sleep(1000);
            //Enter start date
            string s1 = Global.GlobalDefinitions.ExcelLib.ReadData(2, "StartDate");
            string[] s = s1.Split(' ');
            Console.WriteLine("1st part of string:" + s[0]);
            Console.WriteLine("2nd part of string:" + s[1]);
            string SD = s[0];
            Startdate.SendKeys(SD);

            //click on enddate
            Enddate.Click();
            //Enter End date
            string E1 = Global.GlobalDefinitions.ExcelLib.ReadData(2, "EndDate");
            string[] E = E1.Split(' ');
            Console.WriteLine("Enddate 1st part is:" + E[0]);
            Console.WriteLine("End date second part is:" + E[1]);
            string ED = E[0];
            Enddate.SendKeys(ED);

            Thread.Sleep(1000);
            //Enter day
            actions.MoveToElement(Days).Build().Perform();
            IList<IWebElement> Day_Name = Days.FindElements(By.XPath("//div[@class='ui checkbox']/input/following-sibling :: label"));
            Console.WriteLine("Days are" + Day_Name);
            IList<IWebElement> Day_check = Days.FindElements(By.XPath("//input[@tabindex='0' and @type='checkbox']"));
            Console.WriteLine("Day checkbox" + Day_check);
            Thread.Sleep(1000);
            int Day_Count = Day_Name.Count;
            int DayCheck_Count = Day_check.Count;
            for (int i = 0; i < Day_Count; i++)
            {
                if (Day_Name[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Day"))
                {
                    int j = i ;
                    Day_check[j].Click();
                    Console.WriteLine("selected day is" + Day_Name[i]);

                }
            }

            //Enter starttime
            Start_Time.Click();
            string t1 = Global.GlobalDefinitions.ExcelLib.ReadData(2, "StartTime");
            Console.WriteLine("Starttime is:" + t1);
            Start_Time.SendKeys(t1);

            //Enter Endtime
            End_Time.Click();
            string ET = Global.GlobalDefinitions.ExcelLib.ReadData(2, "EndTime");
            Console.WriteLine("Endtime is:" + ET);
            End_Time.SendKeys(ET);

            //Select SkillExchange
            actions.MoveToElement(Skill_trade).Build().Perform();
            IList<IWebElement> Skill_E = Skill_trade.FindElements(By.XPath("//div/input[@name='skillTrades']/following-sibling :: label"));
            int SkillCount = Skill_E.Count;
            Console.WriteLine("count of radio buttons:" + SkillCount);
            for (int i = 0; i < SkillCount; i++)
            {
                if (Skill_E[i].Text == GlobalDefinitions.ExcelLib.ReadData(3, "SkillTrade"))
                {

                    Console.WriteLine("Skil is" + Skill_E[i].Text);
                    Skill_Exchange.Click();
                    actions.MoveToElement(Add_tags).Build().Perform();
                    string Tag = GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange");
                    Add_tags.SendKeys(Tag);
                    Base.test.Log(LogStatus.Info, "Selected skill");
                }

                else
                {
                    Credit.Click();
                    actions.MoveToElement(Add_credit).Build().Perform();
                    string Cr = GlobalDefinitions.ExcelLib.ReadData(2, "Credit");
                    Add_credit.SendKeys(Cr);

                }
                break;
            }

            
            //Click on Worksample
            PlusIcon.Click();

            //Performing the upload file operation using AutoIT

            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("Open");
            Thread.Sleep(3000);
            string sample1 = GlobalDefinitions.ExcelLib.ReadData(2, "WorkSample");
            Console.WriteLine("file path is" + sample1);
            Thread.Sleep(2000);
            autoIT.Send(@sample1);
            Thread.Sleep(3000);
            autoIT.Send("{Enter}");
            Thread.Sleep(2000);
          
            //Downloading the file
            Download.Click();

            //Deleting a file
            Delete.Click();
            Thread.Sleep(500);

            actions.MoveToElement(Active).Build().Perform();
            IList<IWebElement> Active_Name = Active.FindElements(By.XPath("//div[@class='ui radio checkbox']/input[@name='isActive']/following-sibling :: label"));
            Console.WriteLine("Days are" + Active_Name);
            IList<IWebElement> Active_radio = Active.FindElements(By.XPath("//input[@name='isActive' and @type='radio']"));
            Console.WriteLine("Day checkbox" + Active_radio);
            Thread.Sleep(1000);
            int Active_Count = Active_Name.Count;
            for (int i = 0; i < Active_Count; i++)
            {
                if (Active_Name[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Active"))
                {
                    int j = i;
                    Active_radio[j].Click();
                }
            }

            //click on save
            actions.MoveToElement(Buttons).Build().Perform();
            IList<IWebElement> BT = ServiceType.FindElements(By.XPath("//input[@type='button']"));
            for (int i = 0; i < BT.Count; i++)
            {
                Console.WriteLine("Button from web" + BT.Count);
                if (GlobalDefinitions.ExcelLib.ReadData(2, "Buttons") == "Save")
                {
                    Save.Click();
                }
                else
                {
                    Cancel.Click();
                }
                break;
            }


            string text = Global.GlobalDefinitions.driver.Title;
            if (text == "ServiceListing")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Share skill page");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Not valid page");

        }

    }
}
namespace MarsFramework.Pages
{
    class Worksample
    {


        public Worksample()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement SSbutton { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement PlusIcon { get; set; }

        [FindsBy(How = How.LinkText, Using = "Doc2.txt")]
        private IWebElement Download { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='remove sign icon floatRight']")]
        private IWebElement Delete { get; set; }


        internal void GotoShareskill()
        {
            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Share_Skill");
          
            //click on shareskill button
            SSbutton.Click();

            //Click on Worksample
            PlusIcon.Click();

            //Performing the upload file operation using AutoIT

            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("Open");
            string sample1 = GlobalDefinitions.ExcelLib.ReadData(2,"WorkSample");
            Console.WriteLine("file path is" + sample1);
            autoIT.Send(@sample1);

            Thread.Sleep(3000);
            autoIT.Send("{Enter}");


            Actions actions = new Actions(Global.GlobalDefinitions.driver);

           // actions.MoveToElement(PlusIcon).Build().Perform();

            Thread.Sleep(2000);
            PlusIcon.Click();

            //Performing the upload file operation using AutoIT

            AutoItX3 autoIT2 = new AutoItX3();

            autoIT.WinActivate("Open");
            Thread.Sleep(1000);
            string sample2 = GlobalDefinitions.ExcelLib.ReadData(3, "WorkSample");
            autoIT.Send(@sample2);

            Thread.Sleep(2000);
            autoIT.Send("{Enter}");
            Thread.Sleep(2000);
            PlusIcon.Click();

            //Performing the upload file operation using AutoIT
            AutoItX3 autoIT3 = new AutoItX3();
            autoIT.WinActivate("Open");
            string sample3 = GlobalDefinitions.ExcelLib.ReadData(4, "WorkSample");
            Thread.Sleep(1000);
            autoIT.Send(@sample3);
            Thread.Sleep(2000);
            autoIT.Send("{Enter}");

             Thread.Sleep(2000);
            //Downloading the file
            Download.Click();

            //Deleting a file
            Delete.Click();
            Thread.Sleep(500);

            string text = Global.GlobalDefinitions.driver.Title;
            if (text == "ServiceListing")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Share skill page");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Not valid page");
        }

    }
}
namespace MarsFramework.Pages
{
    class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Goto Manage Listings
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement Manage_List { get; set; }

        //goto title
        [FindsBy(How = How.XPath, Using = "//tr/td[3]")] 
        private IWebElement Title { get; set; }

        //goto delete
        [FindsBy(How = How.XPath, Using = "//tr/td[3]")]
        private IWebElement Delete { get; set; }

        //goto confirm delete
        [FindsBy(How = How.XPath, Using = "//div/button[@class='ui icon positive right labeled button']")]
        private IWebElement Confirm_Delete { get; set; }

        //Goto Previous page 
        [FindsBy(How = How.XPath, Using = "//tr/td/i[@class='remove icon']")]
        private IWebElement Previous_page { get; set; }

        //Goto first page
        [FindsBy(How = How.XPath, Using = "//button[@role='button'][2]")]
        private IWebElement Page1 { get; set; }

        //Goto Second page
        [FindsBy(How = How.XPath, Using = "//button[@role='button'][3]")]
        private IWebElement Page2 { get; set; }

        internal void ML()
        {

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Share_Skill");

            //Click on manage Listings
            Manage_List.Click();
            Thread.Sleep(1000);

            Actions actions = new Actions(GlobalDefinitions.driver);
            actions.MoveToElement(Title).Build().Perform();
            IList<IWebElement> title = Title.FindElements(By.XPath("//tr/td[3][@class='two wide']"));
            IList<IWebElement> delete = Delete.FindElements(By.XPath("//tr/td/i[@class='remove icon']"));
            for (int i = (title.Count) - 1; i >= 0; i--)
            {
                Console.WriteLine("tiltle list: " + title.Count);
                if (title[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Title"))

                {
                    Thread.Sleep(1000);
                    Console.WriteLine("title is: " + title[i].Text);
                    int j = i;
                    Thread.Sleep(1000);
                    delete[j].Click();
                    Confirm_Delete.Click();
                }
            }

             if (title.Count > 5)
            {
                Page2.Click();
                for (int i2 = (title.Count) - 1; i2 >= 0; i2--)
                {
                    Console.WriteLine("tiltle list: " + title.Count);
                    if (title[i2].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Title"))

                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("title is: " + title[i2].Text);
                        int j2 = i2;
                        Thread.Sleep(1000);
                        delete[j2].Click();
                        Confirm_Delete.Click();
                    }
                }

            }
              
            //Extent report
            string text = Global.GlobalDefinitions.driver.Title;
            if (text == "ListingManagement")
            {
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Manage Listings page");
            }
            else
                Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Not valid page");
        }

    }
}

