using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucci_Web.Models;
namespace Lucci_Web.Controllers
{
    public class KichCoController : Controller
    {
        DemoEntities db = new DemoEntities();
        // GET: KichCo
        public ActionResult List()
        {
            var model = db.KichCoes.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KichCo model)
        {
            if (ModelState.IsValid)
            {
                db.KichCoes.Add(model);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
                return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.KichCoes.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(KichCo model)
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
    }
}