using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucci_Web.Models;
namespace Lucci_Web.Controllers
{
    public class GioHangController : Controller
    {
        DemoEntities db = new DemoEntities();
        // GET: GioHang
        public ActionResult DSGioHang()
        {
            var model = new List<GioHang>();
            if (Session["GioHang"] != null)
            {
                model = Session["GioHang"] as List<GioHang>;
            }
            return View(model);
        }
        public ActionResult Create(int productId)
        {
            var GioHang = new List<GioHang>();
            if (Session["GioHang"] != null)
            {
                GioHang = Session["GioHang"] as List<GioHang>;
            }
            var model = new GioHang();
            model.SanPham = db.SanPhams.Find(productId);
            GioHang.Add(model);
            Session["GioHang"] = GioHang;
            return RedirectToAction("DSGioHang");
        }
    }
}