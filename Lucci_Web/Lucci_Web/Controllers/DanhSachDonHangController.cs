using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucci_Web.Models;
namespace Lucci_Web.Controllers
{
    public class DanhSachDonHangController : Controller
    {
        DemoEntities db = new DemoEntities();
        // GET: DanhSachDonHang

        public ActionResult DSDonHang()
        {
            var model = db.DonHangs.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DonHang model)
        {
            if (ModelState.IsValid)
            {
                model.NgayGio = DateTime.Now;
                db.DonHangs.Add(model);
                db.SaveChanges();

                var GioHang = Session["GioHang"] as List<GioHang>;
                foreach (var monHang in GioHang)
                {
                    var gioHang = new GioHang();
                    gioHang.idDonHang = model.id;
                    gioHang.DonGia = monHang.SanPham.DonGia;
                    gioHang.SoLuong = 1;
                    gioHang.idSanPham = monHang.SanPham.id;
                    db.GioHangs.Add(gioHang);
                }
                db.SaveChanges();
                return RedirectToAction("Index", "SanPham");
            }
            else
                return View(model);
        }
    }
}