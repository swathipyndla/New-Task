using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {

             [Test]

            public void ChangePassword()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("ChangePassword");

                // Create an class and object to call the method
                ChangePassword Change = new ChangePassword();
                Change.Password();

            }

            [Test]

            public void ProfilePage()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Language tab");

                // Create an class and object to call the method
                ProfilePage A = new ProfilePage();
                A.Profile_P();

            }

            [Test]

            public void Language()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Language tab");

                // Create an class and object to call the method
                Language A_lang = new Language();
                A_lang.Language_T();
                    
             }

            [Test]

            public void Skills()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Skills tab");

                // Create an class and object to call the method
                Skills A_Skills = new Skills();
                A_Skills.Skills_T();

            }

            [Test]

            public void Education()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Education tab");

                // Create an class and object to call the method
                Education A_Education = new Education();
                A_Education.Education_T();

            }

            [Test]

            public void Certification()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Certification tab");

                // Create an class and object to call the method
                Certification_T A_Certification = new Certification_T();
                A_Certification.Cert_T();

            }



            [Test]
            public void WorkSample()
            {
                test = extent.StartTest("Add sample files");
                Worksample WS = new Worksample();
                WS.GotoShareskill();
            }

            [Test]
             public void Calender()

            {
                test = extent.StartTest("Adding avaliable dates");
                ShareSkill Ad = new ShareSkill();
                Ad.Addingdate();


            }
             [Test]
             
             public void ManageList()
            {
                test = extent.StartTest("Manage Listings");
                ManageListings ML_T = new ManageListings();
                ML_T.ML();
            }

            
        }
    }
}