using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucci_Web.Models;
namespace Lucci_Web.Controllers
{
    public class SanPhamController : Controller
    {
        DemoEntities db = new DemoEntities();
        // GET: SanPham
        public ActionResult List()
        {
            var model = db.SanPhams.ToList();
            return View(model);
        }
        public ActionResult Index()
        {
            var model = db.SanPhams.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.KichCo = new SelectList(db.KichCoes, "id", "TenKichCo");
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham model)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(model);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
                return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.KichCo = new SelectList(db.KichCoes, "id", "TenKichCo");
            var model = db.SanPhams.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SanPham model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
                return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = db.SanPhams.Find(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham model = db.SanPhams.Find(id);
            db.SanPhams.Remove(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}