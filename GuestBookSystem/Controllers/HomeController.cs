using GuestBookSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestBookSystem.Controllers
{
    public class HomeController : Controller
    {
        GBSDBContext db = new GBSDBContext();
        public ActionResult Index()
        {
            var gb = db.Guestbooks.OrderByDescending(g => g.CreatedOn).ToList();
            return View(gb);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User u)
        {
            if (ModelState.IsValid)
            {
                u.SRole = 0;
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("CreateSuccess");
            }
            return View();

        }
        public ActionResult CreateSuccess()
        {
            return View();
        }
    }
}