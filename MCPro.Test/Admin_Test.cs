using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MCPro.Controllers;
using System.Web.Mvc;
using MCProj.Models;
using System.ComponentModel.DataAnnotations;
using MCPro.DB.DbOperations;
using MCPro.DB;
using System.Linq;

namespace MCPro.Test
{
    [TestClass]
    public class Admin_Test
    {
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
        [TestMethod]
        public void Verify_Edit_UserInfo()
        {
           

            var model = new UsersModel()
            {
                Email = "test@user.com"
            };
            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
             Assert.AreEqual("The Email field is required.", results[0].ErrorMessage);
        }
        [TestMethod]
        public void Get_User_Id()
        {


            var model = new UsersModel()
            {
                Email = "test@user.com"
            };
            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Email field is required.", results[0].ErrorMessage);
        }
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
        public void Verify_EditUserInfo()
        {
            //Arrange
            UsersRepo ur = new UsersRepo();
            UsersModel model = new UsersModel();

            

            //Act
            var umd = ur.EditUser(model);
            int userid = 1;

            //Assert
            Assert.AreEqual(userid, model);
        }


    }

}

