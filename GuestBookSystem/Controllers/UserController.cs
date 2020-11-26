using GuestBookSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestBookSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        GBSDBContext db = new GBSDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Guestbook gb)
        {
            if (ModelState.IsValid)
            {
                //gb.CreatedOn = System.DateTime.Now;    //获取系统当前日期和时间
                gb.UserId = (int)Session["UserId"];
                gb.IsPass = false;
                db.Guestbooks.Add(gb);
                db.SaveChanges();
                return RedirectToAction("All");
            }
            return View();

        }
        public ActionResult All()
        {
            var gb = db.Guestbooks.OrderByDescending(g => g.CreatedOn).ToList();
            return View(gb);
        }
        public ActionResult  My()
        {
            int UserId = (int)Session["UserId"];
            //找到已审核的，id为登陆id的对象
            var gb = from u in db.Guestbooks
            where u.IsPass == true && u.UserId == UserId
             orderby u.CreatedOn descending
             select u;
            return View(gb.ToList());
        }
        public ActionResult Delete(int id)
        {
            var gb = db.Guestbooks.Find(id);
            return View(gb);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var gb = db.Guestbooks.Find(id);
            db.Guestbooks.Remove(gb);
            db.SaveChanges();
            return RedirectToAction("My");
        }
    }
}