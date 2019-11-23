using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMVC.Models.EntityFrameWork;
namespace ÖğrenciNotMVC.Controllers
{
    public class ogrenciController : Controller
    {
        // GET: ogrenci
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        public ActionResult Index()
        {
            var ogr = db.Tbl_Ogrenciler.ToList();
            return View(ogr);
        }
        [HttpGet]
        public ActionResult Ogrenciekle()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kulup.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupId.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();

        }
        [HttpPost]
        public ActionResult Ogrenciekle(Tbl_Ogrenciler p)
        {
            var klp = db.Tbl_Kulup.Where(m => m.KulupId == p.Tbl_Kulup.KulupId).FirstOrDefault();
            p.Tbl_Kulup = klp;
            db.Tbl_Ogrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult sil (int id)
        {
            var gelen = db.Tbl_Ogrenciler.Find(id);
            db.Tbl_Ogrenciler.Remove(gelen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ogrencigetir(int id)

        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kulup.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupId.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            var getir = db.Tbl_Ogrenciler.Find(id);
            return View("ogrencigetir",getir);
        }
        public ActionResult guncelle(Tbl_Ogrenciler p)
        {
            var klp = db.Tbl_Kulup.Where(m => m.KulupId == p.Tbl_Kulup.KulupId).FirstOrDefault();
            
            var eski = db.Tbl_Ogrenciler.Find(p.OgrenciId);
            eski.OgrenciAd = p.OgrenciAd;
            eski.OgrenciSoyad = p.OgrenciSoyad;
            eski.OgrenciKulup = klp.KulupId;
            eski.OgrenciCinsiyet = p.OgrenciCinsiyet;
            eski.OgrenciFotograf = p.OgrenciFotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}