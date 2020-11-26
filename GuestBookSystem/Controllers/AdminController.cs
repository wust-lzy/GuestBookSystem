using GuestBookSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GuestBookSystem.Controllers
{
    [Authorize(Roles = "管理员")]
    public class AdminController : Controller
    {
        GBSDBContext db = new GBSDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Guestbooks.ToList());
        }
        public ActionResult CheckIndex()
        {
            var gb = from u in db.Guestbooks where u.IsPass == false
                     orderby u.CreatedOn descending
                     select u;
            return View( gb.ToList());
        }
        public ActionResult CheckMessage(int id)
        {
            var gb = db.Guestbooks.Find(id);
            return View(gb);
        }
        [HttpPost, ActionName("CheckMessage")]
        public ActionResult CheckMessageConfirmed(int id)
        {
            var gb = db.Guestbooks.Find(id);
            gb.IsPass = true;
            db.SaveChanges();
            return RedirectToAction("CheckIndex", new { target = "fc" });
        }


        public ActionResult Delete(int id)
        {
            var gb = db.Guestbooks.Find(id);
            return View(gb);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var gb = db.Guestbooks.Find(id);
            db.Guestbooks.Remove(gb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}