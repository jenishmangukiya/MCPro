using System;
using MCPro;
using System.Web.Mvc;
using MCPro.Controllers;
using MCPro.DB.DbOperations;
using MCProj.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using MCPro.Models;

namespace MCProTests
{
    [TestFixture]
    public class MCTest
    {
        [Test]
        public void Verify_ISong_Details_Match_Song_Name()
        {
            //Arrange
            SongsRepo sr = new SongsRepo();
            string exp_sname = "TestSong";

            //Act
            SongsModel smd = sr.GetSong(5);
            string s_name = smd.S_name;

            //Assert
            Assert.AreEqual(exp_sname, s_name);
        }
        [Test]
        public void Verify_PlayList()
        {
            //Arrange
            PlaylistsRepo pr = new PlaylistsRepo();
            string exp_pname = "EZY";

            //Act
            PlaylistsModel pmd = pr.GetPlayList(3);
            string pname = pmd.P_name;

            //Assert
            Assert.AreEqual(exp_pname, pname);
        }
        [Test]
        public void Verify_PlayListName_Is_Not_Empty()
        {
            //Arrange
            PlaylistsRepo pr = new PlaylistsRepo();
            string exp_pname = "";

            //Act
            PlaylistsModel pmd = pr.GetPlayList(13);
            string pname = pmd.P_name;

            //Assert
            Assert.AreNotEqual(exp_pname, pname);
        }
        [Test]
        public void Verify_UserInfo()
        {
            //Arrange
            UsersRepo ur = new UsersRepo();
            string exp_uname = "Jenish";

            //Act
            UsersModel um = ur.GetInfo("mjenish8@gmail.com");
            string uname = um.Fname;

            //Assert
            Assert.AreEqual(exp_uname, uname);
        }

        [Test]
        public void Verify_User_Registeration()
        {
            //Arrange 
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Register() as ViewResult;
            var ViewName = "Login";
            //Assert

            Assert.AreEqual(ViewName, result.ViewName);
        }
        public class TestModelHelper
        {
            public static IList<ValidationResult> Validate(object model)
            {
                var results = new List<ValidationResult>();
                var validationContext = new ValidationContext(model, null, null);
                Validator.TryValidateObject(model, validationContext, results, true);
                if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
                return results;
            }
        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        //  [DataSource(@"metadata=res://*/MyModel.csdl|res://*/MyModel.ssdl|res://*/MyModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=PURAV\PSQL_DATABASE;Initial Catalog=MusicDB;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;", "MusicDB")]
        [Test]
        public void Verify_User_Info()
        {
            var model = new UsersModel()
            {
                Email = "test@user.com"
            };
            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("The Password field is required.", results[0].ErrorMessage);
        }

        [Test]
        public void Verify_User()
        {
            //Arrange
            UsersRepo ur = new UsersRepo();
            string exp_sname = "test@user.com";

            //Act
            UsersModel umd = ur.GetInfo("test@user.com");
            string E_mail = umd.Email;

            //Assert
            Assert.AreEqual(exp_sname, E_mail);
        }
        [Test]
        public void Verify_GetUserInfo()
        {
            //Arrange
            UsersRepo ur = new UsersRepo();
            string exp_sname = "Heer";

            //Act
            UsersModel umd = ur.GetUserInfo(2);
            string fname = umd.Fname;

            //Assert
            Assert.AreEqual(exp_sname, fname);
        }
        [Test]
        public void Verify_EditUserInfo()
        {
            //Arrange
            UsersRepo ur = new UsersRepo();
            var model = new UsersModel()
            {
                Email = "test@user.com"
            };
            var results = TestModelHelper.Validate(model);
            
            
            //Act
            var umd = ur.EditUser(model);
            int userid = 3;

            //Assert
            Assert.AreEqual(userid, model.Email);
        }
        [Test]
        public void Verify_Delete_User()
        {
            //Arrange
            UserController controllerUnderTest = new UserController();
            UsersRepo ur = new UsersRepo();
            var model = new UsersModel();
            //Act


            var result = controllerUnderTest.DeletePL(5) as ViewResult;

           // Assert
            Assert.AreEqual("MyPlaylists", result.ViewName);
        }
        [Test]
        public void Verify_Edit_song()
        {
            //Arrange
            AdminController controllerUnderTest = new AdminController();
            SongsRepo ur = new SongsRepo();
            var model = new SongsModel();
            //Act


            var result = controllerUnderTest.EditSong(2,model) as ViewResult;

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Verify_Delete_song()
        {
            //Arrange
            AdminController controllerUnderTest = new AdminController();
            SongsRepo ur = new SongsRepo();
            var model = new SongsModel();
            //Act


            var result = controllerUnderTest.DeleteSong(3) as ViewResult;

            // Assert
            Assert.AreEqual("ManageSongs", result);
        }
        [Test]
        public void Validate_Model_Playlist_ExpectNoValidationErrors()
        {
            var model = new PlaylistsModel()
            {
             P_name = "EZY"
            };

            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }
        [Test]
        public void Validate_Model_Register_First_Name_Exceeds_30_Characters_ExpectedError()
        {
            var model = new RegisterModel()
            {
                Fname= "Purav",
                Lname = new string('*', 31)
            };

            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(3, results.Count);
        }


    }
}
