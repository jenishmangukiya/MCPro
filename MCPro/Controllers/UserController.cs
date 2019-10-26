using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCProj.Models;
using MCPro.DB.DbOperations;
using System.Web.Security;
using MCPro.DB;
using Newtonsoft.Json;

namespace MCPro.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
        // GET: User
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

        //Browse Songs
        public ActionResult BrowseSongs()
        {
            return View();
        }

        //SongList
        public JsonResult GetSongs()
        {
            using (var context = new MusicDBEntities())
            {
                var data = context.Songs.ToList();

                var json = JsonConvert.SerializeObject(data);

                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        //particular song
        public ActionResult Song(int id)
        {
            SongsRepo sr = new SongsRepo();
            return View(sr.GetSong(id));
        }


        //Profile
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}