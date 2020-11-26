using GuestBookSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestBookSystem.Controllers
{
    public class GuestBookController : Controller
    {
        GBSDBContext db = new GBSDBContext();

        // GET: GuestBook
        public ActionResult Index()
        {
            return View(db.Guestbooks.ToList());
        }
    }
}