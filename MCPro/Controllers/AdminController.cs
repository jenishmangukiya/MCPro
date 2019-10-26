using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCProj.Models;
using MCPro.DB.DbOperations;
using System.Web.Security;

namespace MCPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        SongsRepo srep = null;
        public AdminController()
        {
            srep = new SongsRepo();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //Add New Song
        public ActionResult AddSong()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSong(SongsModel model)
        {
            if(ModelState.IsValid)
            {
                int id = srep.AddSong(model);
                if(id>0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Song Added.";
                }
            }
            return View();
        }

    }
}