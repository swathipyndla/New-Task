using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MarsFramework.Pages
{
    class ProfilePage
    {
        public ProfilePage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
       
        //Click on Profile
        [FindsBy(How = How.LinkText, Using = "Profile")]
        private IWebElement Profile { get; set; }

        //Availability 
        [FindsBy(How = How.XPath, Using = "//div[2]/div[@class='right floated content']/span/i[@class='right floated outline small write icon']")]
        private IWebElement Availability { get; set; }


        //Availability list
        [FindsBy(How = How.XPath, Using = "//select[@class='ui right labeled dropdown' and @name='availabiltyType']")]
        private IWebElement Availability_list { get; set; }

        //Hours icon
        [FindsBy(How = How.XPath, Using = "//div[3]/div[@class='right floated content']/span/i[@class='right floated outline small write icon']")]
        private IWebElement Hours { get; set; }

        //Hours list
        [FindsBy(How = How.XPath, Using = "//select[@class='ui right labeled dropdown' and @name='availabiltyHour']")]
        private IWebElement Hours_list { get; set; }

        //Earn Target icon
        [FindsBy(How = How.XPath, Using = "//div[4]/div[@class='right floated content']/span/i[@class='right floated outline small write icon']")]
        private IWebElement Earn_Target { get; set; }


        //Earn Target list
        [FindsBy(How = How.XPath, Using = "//select[@class='ui right labeled dropdown' and @name='availabiltyTarget']")]
        private IWebElement Target_list { get; set; }

        //Description
        [FindsBy(How = How.XPath, Using = "//h3[@class='ui dividing header']/span/i[@class='outline write icon']")]
        private IWebElement Description { get; set; }

        //Save Description
        [FindsBy(How = How.XPath, Using = "//div[1]/div/div/button[@class='ui teal button' and contains(text(),'Save')]")]
        private IWebElement Save_D { get; set; }

        //Edit Description
        [FindsBy(How = How.XPath, Using = "//textarea[@name='value' and @placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']")]
        private IWebElement Edit_D { get; set; }

        
        //tootltip message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement Tooltip1 { get; set; }

        
        internal void Profile_P()
        {
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");
            Actions action = new Actions(GlobalDefinitions.driver);
            
            //Click on Profile
            Profile.Click();

           
            //Availability Time option
            GlobalDefinitions.driver.Navigate().Refresh();
            Profile.Click();
            Thread.Sleep(1500);
            Availability.Click();
            Availability_list.Click();
            Thread.Sleep(1000);
            IList<IWebElement> AvailableTime = Availability_list.FindElements(By.TagName("option"));
            int count = AvailableTime.Count;
            for (int i = 0; i < count; i++)
            {
                if (AvailableTime[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"))
                {
                    AvailableTime[i].Click();
                    Base.test.Log(LogStatus.Info, "Select the available time");
                    string Time = "Availability updated";
                    Thread.Sleep(1000);
                    string ActualValue_Avail = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                    Thread.Sleep(2000);
                    Console.WriteLine("Availability is" + ActualValue_Avail);
                    if (Time==ActualValue_Avail)
                    {
                        Base.test.Log(LogStatus.Info, "Availability updated");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error");
                    }
                }
            }

            //Hours option
            Thread.Sleep(1500);
            Hours.Click();
            Hours_list.Click();
            Thread.Sleep(1000);
            IList<IWebElement> Num_of_Hours = Hours_list.FindElements(By.TagName("option"));
            int H_count = Num_of_Hours.Count;
            for (int i = 0; i < H_count; i++)
            {
                Thread.Sleep(1000);
                if (Num_of_Hours[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Hours"))
                {
                    Num_of_Hours[i].Click();
                    Base.test.Log(LogStatus.Info, "Select the available hours");
                    string Hours_text = "Availability updated";
                    Thread.Sleep(1000);
                    string ActualValue_Hour = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                    Thread.Sleep(2000);
                    Console.WriteLine("Hours is" + ActualValue_Hour);
                    if (Hours_text == ActualValue_Hour)
                    {
                        Base.test.Log(LogStatus.Info, "Hours updated ");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Hours not updated");
                    }
                    break;
                }
            }

            //Earn target option
            Thread.Sleep(5000);
            Earn_Target.Click();
            Thread.Sleep(1000);
            Target_list.Click();
            IList<IWebElement> Target_Amount = Target_list.FindElements(By.TagName("option"));
            int T_count = Target_Amount.Count;
            for (int i = 0; i < T_count; i++)
            {
                if (Target_Amount[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Target"))
                {
                    Target_Amount[i].Click();
                    Base.test.Log(LogStatus.Info, "Select the target amount");
                    string Target_text = "Availability updated";
                    Thread.Sleep(1000);
                    string ActualValue_Earn = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                    Thread.Sleep(1000);
                    Console.WriteLine("Target is" + ActualValue_Earn);
                    Thread.Sleep(2000);//Availability updated
                    if (Target_text==ActualValue_Earn)
                    {
                        Base.test.Log(LogStatus.Info, "Earn Target updated ");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "No updated target");
                    }
                }
            }

            //Adding Description
            Description.Click();
            Edit_D.Click();
            Thread.Sleep(1000);
            Edit_D.Clear();
            Edit_D.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Save_D.Click();
            string Description_text = "Description has been saved successfully";
            string ActualValue_Descp = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
            Thread.Sleep(2000);
            if (Description_text==ActualValue_Descp)
            {
                Base.test.Log(LogStatus.Info, "Description has been added successfully");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in adding description ");

            }

            //Adding description with special character as first letter
            Description.Click();
            Edit_D.Click();
            Thread.Sleep(1000);
            Edit_D.Clear();
            Edit_D.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));
            Save_D.Click();
            string Description_text2 = "First character can only be digit or letters";
            Thread.Sleep(1000);
            string ActualValue_Descp2 = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
            Console.WriteLine("Description is" + ActualValue_Descp2);
            Thread.Sleep(2000);      
            if (Description_text2 == ActualValue_Descp2)
            {
                Base.test.Log(LogStatus.Info, "Description should contain only letter or digit as first charecter");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in adding description ");

            }

            //Trying to give null values as description
            GlobalDefinitions.driver.Navigate().Refresh();
            Thread.Sleep(1000);
            Description.Click();
            Edit_D.Click();
            Thread.Sleep(1000);
            Edit_D.Clear();
            Edit_D.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Description"));
            Save_D.Click();
            string Description_text3 = "Please, a description is required";
            Thread.Sleep(1000);
            string ActualValue_Descp3 = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
            Thread.Sleep(2000);        
            if (Description_text3 == ActualValue_Descp3)
            {
                Base.test.Log(LogStatus.Info, "Description cannot be empty");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in adding description ");

            }



            
        }
        }
} //Profile page
namespace MarsFramework.Pages
{
    class ChangePassword
    {
        public ChangePassword()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        //Greeting [Hi Swathi] dropdown
        [FindsBy(How = How.XPath, Using = "//div[@class='ui compact menu']/div/following-sibling::a/following-sibling::span")]
        private IWebElement Greet_dropdown { get; set; }

        //Change password
        [FindsBy(How = How.XPath, Using = "//span/div/a[contains(text(),'Change Password')]")]
        private IWebElement Change_Pwd { get; set; }

        //Current password
        [FindsBy(How = How.XPath, Using = "//input[@type='password' and @name='oldPassword']")]
        private IWebElement Current_Pwd { get; set; }

        //New password
        [FindsBy(How = How.XPath, Using = "//input[@type='password' and @name='newPassword']")]
        private IWebElement New_Pwd { get; set; }

        //Confirm password
        [FindsBy(How = How.XPath, Using = "//input[@type='password' and @name='confirmPassword']")]
        private IWebElement Confirm_Pwd { get; set; }

        //Save password
        [FindsBy(How = How.XPath, Using = "//button[@type='button' and @class='ui button ui teal button']")]
        private IWebElement Save_Pwd { get; set; }

        //tootltip message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement Tooltip1 { get; set; }

        //tootltip message2
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div/div[@class='ns-box-inner']")]
        private IWebElement Tooltip2 { get; set; }

        internal void Password()
        {
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");
            Actions action = new Actions(GlobalDefinitions.driver);

            //Change password
            Greet_dropdown.Click();
            Thread.Sleep(1000);
            Change_Pwd.Click();
            Current_Pwd.Click();
            Current_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Change_Pwd"));
            New_Pwd.Click();
            New_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Change_Pwd"));
            Confirm_Pwd.Click();
            Confirm_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Change_Pwd"));
            Save_Pwd.Click();
            string ExpectedValue = "Password Changed Successfully";
            Thread.Sleep(1000);
            string ActualValue = Tooltip1.Text;
            if (ExpectedValue == ActualValue)
            {
                Base.test.Log(LogStatus.Info, "Password changed Successfully");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Passwords doesnot match");
            }

            //Changing password with same as current password
            Thread.Sleep(2000);
            Greet_dropdown.Click();
            Thread.Sleep(8000);
            Change_Pwd.Click();
            Current_Pwd.Click();
            Current_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Change_Pwd"));
            New_Pwd.Click();
            New_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Change_Pwd"));
            Confirm_Pwd.Click();
            Confirm_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Change_Pwd"));
            Save_Pwd.Click();
            string ExpectedValue2 = "Current Password and New Password should not be same";
            string ActualValue2 = Tooltip2.Text;
            Thread.Sleep(1000);
            Console.WriteLine("Password with sameas current password is" + ActualValue2);
            if (ExpectedValue2 == ActualValue2)
            {
                Base.test.Log(LogStatus.Info, "Current password should not match with new password");
            }

            else
            {
                Base.test.Log(LogStatus.Info, "Error in changing password");
            }

            //Changing password by giving null values
            Thread.Sleep(2000);
            GlobalDefinitions.driver.Navigate().Refresh();
            Greet_dropdown.Click();
            Thread.Sleep(6000);
            Change_Pwd.Click();
            Current_Pwd.Click();
            Current_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Change_Pwd"));
            New_Pwd.Click();
            New_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Change_Pwd"));
            Confirm_Pwd.Click();
            Confirm_Pwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Change_Pwd"));
            Save_Pwd.Click();
            string ExpectedValue3 = "Error while Updating Password details";
            Thread.Sleep(1000);
            string ActualValue_Null = GlobalDefinitions.driver.FindElement(By.XPath("//body[@class='dimmable dimmed']/div/div[@class='ns-box-inner']")).Text;
            Thread.Sleep(1000);
            Console.WriteLine("Password with null is" + ActualValue_Null);
            if (ExpectedValue3 == ActualValue_Null)
            {
                Base.test.Log(LogStatus.Info, "Current password should not be empty");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in changing password");
            }



        }

    }

} //Change Password
namespace MarsFramework.Pages
{
    class Language
    {
        public Language()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        //Click on Profile
        [FindsBy(How = How.LinkText, Using = "Profile")]
        private IWebElement Profile { get; set; }

        //Click on Language tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='first']")]
        private IWebElement Lang { get; set; }

        //Click on Addnew language
        [FindsBy(How = How.XPath, Using = "//th[@class='right aligned']/div[1]")]
        private IWebElement AddNew { get; set; }

        //Click on Add language text box.
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @placeholder='Add Language']")]
        private IWebElement lang { get; set; }

        //Click on Language level dropdown
        [FindsBy(How = How.XPath, Using = "//select[@class='ui dropdown']")]
        private IWebElement level { get; set; }

        //Click on Add button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Add']")]
        private IWebElement Add { get; set; }

        //Click on Cancel button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Cancel']")]
        private IWebElement Cancel { get; set; }

        //Click on Update
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Update']")]
        private IWebElement Update { get; set; }

        //Click on Cancel update
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Cancel']")]
        private IWebElement Cancel_Update { get; set; }

        //List of languages
        [FindsBy(How = How.XPath, Using = "//tr/td[1]")]
        private IWebElement List_of_lang { get; set; }

        //tootltip message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement Tooltip1 { get; set; }

        internal void Language_T()
        {
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");
            Actions action = new Actions(GlobalDefinitions.driver);

            //Click on Profile
            Profile.Click();
            //Adding a language
            Lang.Click();
            for (int j = 0; j <= 3; j++)
            {
                Thread.Sleep(1000);
                AddNew.Click();
                Thread.Sleep(3000);
                lang.Click();
                lang.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(j + 2, "Language"));

                //Select level
                level.Click();
                IList<IWebElement> Lang_level = level.FindElements(By.TagName("option"));
                int levelcount = Lang_level.Count;
                Console.WriteLine("level count is" + levelcount);
                Thread.Sleep(1000);

                for (int i = 0; i < levelcount; i++)
                {
                    if (Lang_level[i].Text == GlobalDefinitions.ExcelLib.ReadData(j + 2, "Language-Level"))
                    {
                        Console.WriteLine("level is" + Lang_level[i].Text);
                        Thread.Sleep(1000);
                        Lang_level[i].Click();

                    }

                }
                Thread.Sleep(1000);
                //Click on Add button
                Add.Click();
                Thread.Sleep(1000);
                Base.test.Log(LogStatus.Info, "Added language");
                //E-lan is expected language
                string E_Lan = GlobalDefinitions.ExcelLib.ReadData(j + 2, "Language");
                string ExpectedValue = E_Lan + " has been added to your languages";
                Console.WriteLine("expected" + ExpectedValue);
                string ActualValue_L1 = Tooltip1.Text;
                Console.WriteLine("Lan is" + ActualValue_L1);
                if (ExpectedValue == ActualValue_L1)
                {
                    Base.test.Log(LogStatus.Info, "Language added successfully");
                }
                else
                {
                    Base.test.Log(LogStatus.Info, "Error in adding langugae");
                }

            }

            Thread.Sleep(1000);
            //Updating a language
            IList<IWebElement> List_of_Items = List_of_lang.FindElements(By.XPath("//tr/td[1]"));
            int Lang_Count = List_of_Items.Count;
            Console.WriteLine("num of items count is" + Lang_Count);
            //Thread.Sleep(1000);

            for (int i1 = 0; i1 < Lang_Count; i1++)
            {
                if (List_of_Items[i1].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Update_item"))
                {
                    Console.WriteLine("Updating item is" + List_of_Items[i1].Text);
                    Thread.Sleep(1000);
                    string Lan = List_of_Items[i1].Text;
                    Console.WriteLine("lan is" + Lan);
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[1]/i";
                    IWebElement Edit = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + Lan + AfterXpath));
                    Edit.Click();
                    //Edit a particular language
                    string Editpath1 = "//input[@type='text' and @value='";
                    string Editpath2 = "']";
                    IWebElement Edit_Lan = GlobalDefinitions.driver.FindElement(By.XPath(Editpath1 + Lan + Editpath2));
                    Edit_Lan.Click();
                    //Clear the langugae
                    Edit_Lan.Clear();

                    Edit_Lan.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "New_item"));
                    level.Click();
                    IList<IWebElement> Lang_level2 = level.FindElements(By.TagName("option"));
                    int levelcount2 = Lang_level2.Count;
                    Console.WriteLine("level count is" + levelcount2);
                    Thread.Sleep(1000);

                    for (int i2 = 0; i2 < levelcount2; i2++)
                    {
                        if (Lang_level2[i2].Text == GlobalDefinitions.ExcelLib.ReadData(2, "New_Level"))
                        {
                            Console.WriteLine("level is" + Lang_level2[i2].Text);
                            Thread.Sleep(1000);
                            Lang_level2[i2].Click();
                            Base.test.Log(LogStatus.Info, "Edited language");
                        }
                    }

                    Update.Click();

                    //Extent Report
                    Base.test.Log(LogStatus.Info, "Updated lang");
                    string E_Lan1 = GlobalDefinitions.ExcelLib.ReadData(2, "New_item");
                    string ExpectedValue1 = E_Lan1 + " has been updated to your languages";
                    Console.WriteLine("expected" + ExpectedValue1);
                    Thread.Sleep(1000);
                    string ActualValue_L2 = Tooltip1.Text;
                    Console.WriteLine("Lan is" + ActualValue_L2);
                    if (ExpectedValue1 == ActualValue_L2)
                    {
                        Base.test.Log(LogStatus.Info, "Language updated successfully");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error in updating langugae");
                    }

                }

            }

            //Deleting a language
            IList<IWebElement> List_of_Lang = List_of_lang.FindElements(By.XPath("//tr/td[1]"));
            int Del_Count = List_of_Lang.Count;
            Console.WriteLine("num of items count is" + Del_Count);
            for (int i3 = 0; i3 < Del_Count; i3++)
            {
                if (List_of_Lang[i3].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Delete_item"))
                {
                    Console.WriteLine("Deleting item is" + List_of_Items[i3].Text);
                    string Lan = List_of_Lang[i3].Text;
                    Console.WriteLine("lan is" + Lan);
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[2]/i";
                    IWebElement Delete = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + Lan + AfterXpath));

                    Delete.Click();
                    Base.test.Log(LogStatus.Info, "Deleted language");
                    string E_Lan2 = GlobalDefinitions.ExcelLib.ReadData(2, "Delete_item");
                    string ExpectedValue2 = E_Lan2 + " has been deleted from your languages";
                    Console.WriteLine("expected" + ExpectedValue2);
                    Thread.Sleep(1000);
                    string ActualValue_L3 = Tooltip1.Text;
                    Console.WriteLine("Lan is" + ActualValue_L3);
                    if (ExpectedValue2 == ActualValue_L3)
                    {
                        Base.test.Log(LogStatus.Info, "Language deleted successfully");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error in deleting language");
                    }

                    break;

                }
            }

            //Cancel Edit operation
            Thread.Sleep(1000);
            IList<IWebElement> List_of_Items2 = List_of_lang.FindElements(By.XPath("//tr/td[1]"));
            int Lang_Count2 = List_of_Items2.Count;
            Console.WriteLine("num of items count is" + Lang_Count2);
            Thread.Sleep(1000);
            for (int i4 = 0; i4 < Lang_Count2; i4++)
            {
                if (List_of_Items2[i4].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Language"))
                {
                    Console.WriteLine("Update cancel item is" + List_of_Items2[i4].Text);
                    Thread.Sleep(1000);
                    string Lan = List_of_Items2[i4].Text;
                    Console.WriteLine("lan is" + Lan);
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[1]/i";
                    IWebElement Edit = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + Lan + AfterXpath));
                    Edit.Click();
                    Cancel.Click();
                    break;

                }

            }

            //Dupicate data
            AddNew.Click();
            Thread.Sleep(3000);
            lang.Click();
            lang.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

            //Select level
            level.Click();
            IList<IWebElement> Lang_level_D = level.FindElements(By.TagName("option"));
            int levelcount_D = Lang_level_D.Count;
            Console.WriteLine("level count is" + levelcount_D);
            Thread.Sleep(1000);

            for (int i5 = 0; i5 < levelcount_D; i5++)
            {
                if (Lang_level_D[i5].Text == GlobalDefinitions.ExcelLib.ReadData(4, "Language-Level"))
                {
                    Console.WriteLine("level is" + Lang_level_D[i5].Text);
                    Thread.Sleep(1000);
                    Lang_level_D[i5].Click();

                }

            }
            Thread.Sleep(1000);
            //Click on Add button
            Add.Click();
            Thread.Sleep(1000);
            string ExpectedValue_D = "Duplicated data";
            Console.WriteLine("expected" + ExpectedValue_D);
            Thread.Sleep(1000);
            string ActualValue_D = Tooltip1.Text;
            Console.WriteLine("Lan is" + ActualValue_D);
            if (ExpectedValue_D == ActualValue_D)
            {
                Base.test.Log(LogStatus.Info, "Language cannot be duplicated");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in duplication");
            }

        }


    }
} //Language
namespace MarsFramework.Pages
{
    class Skills
    {
        public Skills()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on skills  tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='second']")]
        private IWebElement Skills_Tab { get; set; }

        //Add new skill
        [FindsBy(How = How.XPath, Using = "//div[@class='ui teal button']")]
        private IWebElement Add_New { get; set; }

        //Add Skill text box
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @placeholder='Add Skill']")]
        private IWebElement Add_Skill { get; set; }

        //Add level of the skill
        [FindsBy(How = How.XPath, Using = "//select[@class='ui fluid dropdown']")]
        private IWebElement Skills_Level { get; set; }

        //Add button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Add']")]
        private IWebElement Add { get; set; }

        //Cross icon
        [FindsBy(How = How.XPath, Using = "//td[@class='right aligned']/span[2]")]
        private IWebElement Delete_icon { get; set; }

        //Edit icon
        [FindsBy(How = How.XPath, Using = "//td[@class='right aligned']/span[1]")]
        private IWebElement Edit_icon { get; set; }

        //Update button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Update']")]
        private IWebElement Update { get; set; }

        //Cancel button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Cancel']")]
        private IWebElement Cancel { get; set; }

        //Skills list
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']/div/div/div/table/tbody/tr[1]/td[1]")]
        private IWebElement Skills_List { get; set; }

        //tootltip message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement Tooltip1 { get; set; }



        internal void Skills_T()
        {
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");

            Actions actions = new Actions(GlobalDefinitions.driver);

            //Click on Profile
            Skills_Tab.Click();

            //Adding a Skill
            for (int j = 0; j < 4; j++)
            {
                Thread.Sleep(1000);
                Add_New.Click();
                Thread.Sleep(3000);
                Add_Skill.Click();
                Add_Skill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(j + 2, "Add_Skill"));

                //Select level
                Skills_Level.Click();
                IList<IWebElement> Skill_level1 = Skills_Level.FindElements(By.TagName("option"));
                int levelcount1 = Skill_level1.Count;
                Console.WriteLine("level count is" + levelcount1);
                Thread.Sleep(1000);

                for (int i = 0; i < levelcount1; i++)
                {
                    if (Skill_level1[i].Text == GlobalDefinitions.ExcelLib.ReadData(j + 2, "Skill_Level"))
                    {
                        Console.WriteLine("level is" + Skill_level1[i].Text);
                        Thread.Sleep(1000);
                        Skill_level1[i].Click();

                    }
                }

                Thread.Sleep(1000);
                //Click on Add button
                Add.Click();

                //Extent Report
                string E_Skill1 = GlobalDefinitions.ExcelLib.ReadData(j + 2, "Add_Skill");
                string ExpectedValue = E_Skill1 + " has been added to your skills";
                Console.WriteLine("expected" + ExpectedValue);
                Thread.Sleep(1000);
                string ActualValue_S2 = Tooltip1.Text;
                Console.WriteLine("Lan is" + ActualValue_S2);
                if (ExpectedValue == ActualValue_S2)
                {
                    Base.test.Log(LogStatus.Info, "Skills Added successfully");
                }
                else
                {
                    Base.test.Log(LogStatus.Info, "Error in updating langugae");
                }


            }

            //Updating a Skill
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");
            IList<IWebElement> List_of_Skills = Skills_List.FindElements(By.XPath("//tr/td[1]"));
            int Skills_Count = List_of_Skills.Count;
            Console.WriteLine("num of items count is" + Skills_Count);
            Thread.Sleep(1000);

            for (int i = 0; i < Skills_Count; i++)
            {
                if (List_of_Skills[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Update_Skill"))
                {
                    Console.WriteLine("Updating item is" + List_of_Skills[i].Text);
                    Thread.Sleep(1000);
                    string Lan = List_of_Skills[i].Text;
                    Console.WriteLine("lan is" + Lan);
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[1]/i";
                    IWebElement Edit = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + Lan + AfterXpath));
                    Edit.Click();
                    //Edit a particular language
                    string Editpath1 = "//input[@type='text' and @value='";
                    string Editpath2 = "']";
                    IWebElement Edit_Lan = GlobalDefinitions.driver.FindElement(By.XPath(Editpath1 + Lan + Editpath2));
                    Edit_Lan.Click();

                    //Clear the langugae
                    Edit_Lan.Clear();

                    Edit_Lan.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "New_Skill"));
                    Skills_Level.Click();
                    IList<IWebElement> S_level = Skills_Level.FindElements(By.TagName("option"));
                    int levelcount1 = S_level.Count;
                    Console.WriteLine("level count is" + levelcount1);
                    Thread.Sleep(1000);

                    for (int i1 = 0; i1 < levelcount1; i1++)
                    {
                        if (S_level[i1].Text == GlobalDefinitions.ExcelLib.ReadData(2, "New_SkillLevel"))
                        {
                            Console.WriteLine("level is" + S_level[i1].Text);
                            Thread.Sleep(1000);
                            S_level[i1].Click();

                        }
                    }

                    Update.Click();

                    //Extent Report
                    string E_Skill2 = GlobalDefinitions.ExcelLib.ReadData(2, "New_Skill");
                    string ExpectedValue2 = E_Skill2 + " has been updated to your skills";
                    Console.WriteLine("expected" + ExpectedValue2);
                    Thread.Sleep(1000);
                    string ActualValue_S2 = Tooltip1.Text;
                    Console.WriteLine("Lan is" + ActualValue_S2);
                    if (ExpectedValue2 == ActualValue_S2)
                    {
                        Base.test.Log(LogStatus.Info, "Skills updated successfully");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error in updating skills");
                    }

                }
            }

            //Deleting a Skill
            IList<IWebElement> List_of_Skills1 = Skills_List.FindElements(By.XPath("//tr/td[1]"));
            int Del_Count = List_of_Skills1.Count;
            Console.WriteLine("num of items count is" + Del_Count);
            for (int i = 0; i < Del_Count; i++)
            {
                Console.WriteLine("Items" + List_of_Skills1[i].Text);
                if (List_of_Skills1[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Delete_Skill"))
                {
                    Console.WriteLine("Deleting item is" + List_of_Skills1[i].Text);
                    string Skill = List_of_Skills1[i].Text;
                    Console.WriteLine("lan is" + Skill);
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[2]/i";
                    Thread.Sleep(1000);
                    IWebElement Delete = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + Skill + AfterXpath));
                    Thread.Sleep(1000);
                    Delete.Click();

                    //Extent Report
                    string E_Skill3 = GlobalDefinitions.ExcelLib.ReadData(2, "Delete_Skill");
                    string ExpectedValue3 = E_Skill3 + " has been deleted";
                    Console.WriteLine("expected" + ExpectedValue3);
                    Thread.Sleep(1000);
                    string ActualValue_S3 = Tooltip1.Text;
                    Console.WriteLine("Lan is" + ActualValue_S3);
                    if (ExpectedValue3 == ActualValue_S3)
                    {
                        Base.test.Log(LogStatus.Info, "Skills deleted successfully");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error in deleting skills");
                    }
                    break;
                }


            }

            //Cancel Edit operation
            IList<IWebElement> List_of_Skills2 = Skills_List.FindElements(By.XPath("//tr/td[1]"));
            int Skill_Count = List_of_Skills2.Count;
            Console.WriteLine("num of items count is" + Skills_Count);
            Thread.Sleep(1000);

            for (int i = 0; i < Skill_Count; i++)
            {
                if (List_of_Skills2[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Edit_Skill"))
                {
                    Console.WriteLine("Editing item is" + List_of_Skills2[i].Text);
                    Thread.Sleep(1000);
                    string Lan = List_of_Skills2[i].Text;
                    Console.WriteLine("lan is" + Lan);
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[1]/i";
                    IWebElement Edit = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + Lan + AfterXpath));
                    Thread.Sleep(1000);
                    Edit.Click();
                    Cancel.Click();
                    break;


                }
            }

            //Duplicating a skill
            Thread.Sleep(1000);
            Add_New.Click();
            Thread.Sleep(3000);
            Add_Skill.Click();
            Add_Skill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Add_Skill"));

            //Select level
            Skills_Level.Click();
            IList<IWebElement> Skill_level = Skills_Level.FindElements(By.TagName("option"));
            int levelcount = Skill_level.Count;
            Console.WriteLine("level count is" + levelcount);
            Thread.Sleep(1000);

            for (int i = 0; i < levelcount; i++)
            {
                if (Skill_level[i].Text == GlobalDefinitions.ExcelLib.ReadData(3, "Skill_Level"))
                {
                    Console.WriteLine("level is" + Skill_level[i].Text);
                    Thread.Sleep(1000);
                    Skill_level[i].Click();

                }
            }

            Thread.Sleep(1000);
            //Click on Add button
            Add.Click();

            //Extent Report
            string ExpectedValue1 = "Duplicated data";
            Console.WriteLine("expected" + ExpectedValue1);
            Thread.Sleep(1000);
            string ActualValue_S1 = Tooltip1.Text;
            Console.WriteLine("Lan is" + ActualValue_S1);
            if (ExpectedValue1 == ActualValue_S1)
            {
                Base.test.Log(LogStatus.Info, "Skills cannot be duplicated");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in duplication");
            }


        }

    }
} //Skills
namespace MarsFramework.Pages
{
    class Education
    {
        public Education()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Education tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='third']")]
        private IWebElement Education_tab { get; set; }

        //Add new button
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='third']/div/div/div/table/thead/tr/th[@class='right aligned']/div")]
        private IWebElement Add_New { get; set; }

        //College name textbox
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @name='instituteName']")]
        private IWebElement College_Text { get; set; }

        //Country name dropdown
        [FindsBy(How = How.XPath, Using = "//select[@class='ui dropdown' and @name='country']")]
        private IWebElement Country { get; set; }

        //Title dropdown
        [FindsBy(How = How.XPath, Using = "//select[@class='ui dropdown' and @name='title']")]
        private IWebElement Title_D { get; set; }


        //Title list
        [FindsBy(How = How.XPath, Using = "//select[@class='ui fluid dropdown' and @name='title']")]
        private IWebElement Title { get; set; }

        //Degree Textbox
        [FindsBy(How = How.XPath, Using = "//tr/td[4]")]
        private IWebElement Degree { get; set; }

        //Degree list
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @name='degree']")]
        private IWebElement Degree_T { get; set; }

        //Year dropdown
        [FindsBy(How = How.XPath, Using = "//select[@class='ui dropdown' and @name='yearOfGraduation']")]
        private IWebElement Year { get; set; }

        //Add button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Add']")]
        private IWebElement Add { get; set; }

        //Update icon
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Update']")]
        private IWebElement Update { get; set; }


        //tootltip message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement Tooltip1 { get; set; }

        internal void Education_T()
        {
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");

            Actions actions = new Actions(GlobalDefinitions.driver);

            //Click on Education tab
            Education_tab.Click();
            Thread.Sleep(1000);

            //Adding an Education
            Add_New.Click();

            //Add College name
            College_Text.Click();
            College_Text.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Add_Education"));
            Country.Click();
            Country.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Add_Education"));
            Title_D.Click();
            Title_D.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Add_Education"));
            Degree_T.Click();
            Degree_T.SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "Add_Education"));
            Year.Click();
            Year.SendKeys(GlobalDefinitions.ExcelLib.ReadData(6, "Add_Education"));
            Add.Click();

            //Extent Report
            string ExpectedValue1 = "Education has been added";
            Console.WriteLine("expected" + ExpectedValue1);
            Thread.Sleep(1000);
            string ActualValue_E1 = Tooltip1.Text;
            Console.WriteLine("Edu is" + ActualValue_E1);
            if (ExpectedValue1 == ActualValue_E1)
            {
                Base.test.Log(LogStatus.Info, "Education Added successfully");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in Adding Education");
            }

            //Duplicate data
            Add_New.Click();
            College_Text.Click();
            College_Text.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Add_Education"));
            Country.Click();
            Country.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Add_Education"));
            Title_D.Click();
            Title_D.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Add_Education"));
            Degree_T.Click();
            Degree_T.SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "Add_Education"));
            Year.Click();
            Year.SendKeys(GlobalDefinitions.ExcelLib.ReadData(7, "Add_Education"));
            Add.Click();

            //Extent Report
            string ExpectedValue4 = "Duplicated data";
            Console.WriteLine("expected" + ExpectedValue4);
            Thread.Sleep(1000);
            string ActualValue_E4 = Tooltip1.Text;
            Console.WriteLine("Edu is" + ActualValue_E4);
            if (ExpectedValue4 == ActualValue_E4)
            {
                Base.test.Log(LogStatus.Info, "Duplicated data not allowed");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in Adding Education");
            }



            Thread.Sleep(1000);
            //Delete an Education
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");
            IList<IWebElement> List_of_Degree = Degree.FindElements(By.XPath("//tr/td[4]"));
            int Degree_Count = List_of_Degree.Count;
            Console.WriteLine("num of items count is" + Degree_Count);

            for (int i = 0; i < Degree_Count; i++)
            {
                Console.WriteLine("Degree count" + Degree_Count);
                Thread.Sleep(1000);
                if (List_of_Degree[i].Text == GlobalDefinitions.ExcelLib.ReadData(5, "Add_Education"))
                {
                    Console.WriteLine("Deleting item is" + List_of_Degree[i].Text);
                    string Deg = List_of_Degree[i].Text;
                    Console.WriteLine("lan is" + Deg);
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[2]/i";
                    IWebElement Delete = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + Deg + AfterXpath));

                    Delete.Click();

                    //Extent Report
                    string ExpectedValue3 = "Education entry successfully removed";
                    // Education entry successfully removed
                    Console.WriteLine("expected" + ExpectedValue3);
                    Thread.Sleep(1000);
                    string ActualValue_E3 = Tooltip1.Text;
                    Console.WriteLine("Actual is" + ActualValue_E3);
                    Thread.Sleep(2000);
                    if (ExpectedValue3 == ActualValue_E3)
                    {
                        Base.test.Log(LogStatus.Info, "Education deleted successfully");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error in deleting education");
                    }
                    break;
                }

            }

            //Updating Education details 

            for (int i = 0; i < Degree_Count; i++)
            {
                if (List_of_Degree[i].Text == GlobalDefinitions.ExcelLib.ReadData(3, "Edit_Education"))
                {
                    Console.WriteLine("Updating item is" + List_of_Degree[i].Text);
                    Thread.Sleep(1000);
                    string T = List_of_Degree[i].Text;
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[1]/i";
                    IWebElement Edit = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + T + AfterXpath));
                    Edit.Click();

                    //Edit an education
                    string Editpath1 = "//input[@type='text' and @value='";
                    string Editpath2 = "']";
                    IWebElement Edit_Deg = GlobalDefinitions.driver.FindElement(By.XPath(Editpath1 + T + Editpath2));
                    Edit_Deg.Click();

                    //Clear the langugae
                    Edit_Deg.Clear();
                    Edit_Deg.SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "Edit_Education"));
                    Thread.Sleep(1000);
                    Title.Click();
                    IList<IWebElement> Title_level = Title.FindElements(By.TagName("option"));
                    int Titlecount = Title_level.Count;
                    Console.WriteLine("level count is" + Titlecount);
                    Thread.Sleep(1000);
                    for (int i1 = 0; i1 < Titlecount; i1++)
                    {
                        if (Title_level[i1].Text == GlobalDefinitions.ExcelLib.ReadData(4, "Edit_Education"))
                        {
                            Console.WriteLine("level is" + Title_level[i1].Text);
                            Thread.Sleep(1000);
                            Title_level[i1].Click();

                        }
                    }

                    Update.Click();
                    //Extent Report
                    string ExpectedValue2 = "Education as been updated";
                    Console.WriteLine("expected" + ExpectedValue2);
                    Thread.Sleep(1000);
                    string ActualValue_E2 = Tooltip1.Text;
                    Console.WriteLine("Lan is" + ActualValue_E2);
                    Thread.Sleep(2000);
                    if (ExpectedValue2 == ActualValue_E2)
                    {
                        Base.test.Log(LogStatus.Info, "Education updated successfully");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error in updating Education");
                    }

                    break;
                }

            }


        }
    }
} //Education
namespace MarsFramework.Pages
{
    class Certification_T
    {
        public Certification_T()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Certification tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='fourth']")]
        private IWebElement Certification { get; set; }

        //Add new certificate
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']/div/div/div/table/thead/tr/th[@class='right aligned']/div")]
        private IWebElement AddNew_Cert { get; set; }

        //certificate textbox
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @name='certificationName']")]
        private IWebElement Cert_Text { get; set; }


        //certificate from textbox
        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @name='certificationFrom']")]
        private IWebElement Cert_From { get; set; }


        //certificate year
        [FindsBy(How = How.XPath, Using = "//select[@class='ui fluid dropdown']")]
        private IWebElement Cert_Year { get; set; }

        //Add certificate button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Add']")]
        private IWebElement Add_C { get; set; }

        //Certification list
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']/div/div/div/table/tbody/tr/td[1]")]
        private IWebElement Cert_List { get; set; }

        //update certificate 
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Update']")]
        private IWebElement Update_C { get; set; }

        //tootltip message
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement Tooltip1 { get; set; }

        internal void Cert_T()
        {
            //Populate the Excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");

            Actions actions = new Actions(GlobalDefinitions.driver);

            //Add Certification
            Certification.Click();
            AddNew_Cert.Click();
            Cert_Text.Click();
            Cert_Text.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certification"));
            Cert_From.Click();
            Cert_From.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Certification"));
            Cert_Year.Click();
            Cert_Year.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Certification"));
            Add_C.Click();

            //Extent Report
            string E_Cert1 = GlobalDefinitions.ExcelLib.ReadData(2, "Certification");
            string ExpectedValue1 = E_Cert1 + " has been added to your certification";
            Console.WriteLine("expected" + ExpectedValue1);
            Thread.Sleep(1000);
            string ActualValue_C1 = Tooltip1.Text;
            Console.WriteLine("Lan is" + ActualValue_C1);
            if (ExpectedValue1 == ActualValue_C1)
            {
                Base.test.Log(LogStatus.Info, "Certification added successfully");
            }
            else
            {
                Base.test.Log(LogStatus.Info, "Error in adding certification");
            }


            //Delete Certification
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile_Page");
            IList<IWebElement> List_of_Certification = Cert_List.FindElements(By.XPath("//div[@data-tab='fourth']/div/div/div/table/tbody/tr/td[1]"));
            int Cert_Count = List_of_Certification.Count;
            Console.WriteLine("num of items count is" + Cert_Count);
            for (int i = 0; i < Cert_Count; i++)
            {
                Console.WriteLine("Certificate count" + Cert_Count);
                Thread.Sleep(1000);
                if (List_of_Certification[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Certification"))
                {
                    Console.WriteLine("Deleting item is" + List_of_Certification[i].Text);
                    string C = List_of_Certification[i].Text;
                    Console.WriteLine("lan is" + C);
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[2]/i";
                    IWebElement Delete = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + C + AfterXpath));

                    Delete.Click();

                    //Extent report
                    string E_Cert2 = GlobalDefinitions.ExcelLib.ReadData(2, "Certification");
                    string ExpectedValue2 = E_Cert2 + " has been deleted from your certification";
                    Console.WriteLine("expected" + ExpectedValue2);
                    Thread.Sleep(1000);
                    string ActualValue_C2 = Tooltip1.Text;
                    Console.WriteLine("Lan is" + ActualValue_C2);
                    if (ExpectedValue2 == ActualValue_C2)
                    {
                        Base.test.Log(LogStatus.Info, "Certification deleted successfully");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error in deleting certification");
                    }
                    break;
                }

            }

            //Update Certification
            for (int i = 0; i < Cert_Count; i++)
            {
                if (List_of_Certification[i].Text == GlobalDefinitions.ExcelLib.ReadData(5, "Certification"))
                {
                    Console.WriteLine("Updating item is" + List_of_Certification[i].Text);
                    Thread.Sleep(1000);
                    string T = List_of_Certification[i].Text;
                    string BeforeXpath = "//tbody/tr/td[contains(text(),'";
                    string AfterXpath = "')]//..//following-sibling::td[1]/span[1]/i";
                    IWebElement Edit = GlobalDefinitions.driver.FindElement(By.XPath(BeforeXpath + T + AfterXpath));
                    Edit.Click();
                    //Edit an education
                    string Editpath1 = "//input[@type='text' and @value='";
                    string Editpath2 = "']";
                    IWebElement Edit_Cert = GlobalDefinitions.driver.FindElement(By.XPath(Editpath1 + T + Editpath2));
                    Edit_Cert.Click();
                    //Clear the langugae
                    Edit_Cert.Clear();

                    Edit_Cert.SendKeys(GlobalDefinitions.ExcelLib.ReadData(6, "Certification"));

                    Update_C.Click();

                    //Extent report
                    string E_Cert3 = GlobalDefinitions.ExcelLib.ReadData(6, "Certification");
                    string ExpectedValue2 = E_Cert3 + " has been updated to your certification";
                    Console.WriteLine("expected" + ExpectedValue2);
                    Thread.Sleep(1000);
                    string ActualValue_C3 = Tooltip1.Text;
                    Console.WriteLine("Lan is" + ActualValue_C3);
                    if (ExpectedValue2 == ActualValue_C3)
                    {
                        Base.test.Log(LogStatus.Info, "Certification updated successfully");
                    }
                    else
                    {
                        Base.test.Log(LogStatus.Info, "Error in updating certification");
                    }
                    break;

                }
            }


        }
    }
} //Certification





