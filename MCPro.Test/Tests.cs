using System;
using System.Web.Mvc;
using MCPro.Controllers;
using MCPro.DB.DbOperations;
using MCProj.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MCPro.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Verify_Song()
        {
            //Arrange
            SongsRepo sr = new SongsRepo();
            string exp_sname = "Udd Gaye";

            //Act
            SongsModel smd = sr.GetSong(1);
            string s_name = smd.S_name;

            //Assert
            Assert.AreEqual(exp_sname, s_name);
        }
        [TestMethod]
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
        [TestMethod]
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

        [TestMethod]
        public void TestRegisterMethod()
        {

            //Arrange 
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Register() as ViewResult;
            var ViewName = "Login";
            //Assert

            Assert.AreEqual(ViewName, result.ViewName);
        }
    }
}
