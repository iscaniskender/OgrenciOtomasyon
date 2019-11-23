using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMVC.Models.EntityFrameWork;
using ÖğrenciNotMVC.Models;
namespace ÖğrenciNotMVC.Controllers
{
    public class SınavController : Controller
    {
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        // GET: Sınav
        public ActionResult Index()
        {
            var sınav = db.Tbl_Not.ToList();
            return View(sınav);
        }
        [HttpGet]
        public ActionResult SınavEkle()
        {
            List<SelectListItem> dgr1 = (from i in db.Tbl_Dersler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.DersAd,
                                             Value = i.DersId.ToString()

                                         }).ToList();

            ViewBag.deger1 = dgr1;


            List<SelectListItem> dgr2 = (from i in db.Tbl_Ogrenciler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.OgrenciId.ToString(),
                                             Value = i.OgrenciId.ToString()

                                         }).ToList();


            ViewBag.deger2 = dgr2;
            return View();
        }
        [HttpPost]
        public ActionResult SınavEkle(Tbl_Not p4)
        {
            var donen = db.Tbl_Dersler.Where(m => m.DersId == p4.Tbl_Dersler.DersId).FirstOrDefault();
            p4.Tbl_Dersler = donen;
            db.Tbl_Not.Add(p4);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult sil (int id)
        {
            var gelen = db.Tbl_Not.Find(id);
            db.Tbl_Not.Remove(gelen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult sınavgetir(int id)
        {
            var getir = db.Tbl_Not.Find(id);
            return View("sınavgetir", getir);
        }
        [HttpPost]
        public ActionResult sınavgetir (Class1 class1, Tbl_Not p , int sınav1=0,int sınav2=0,int sınav3=0,int proje=0 )
        {
            if(class1.islem=="hesapla")
            {
                int ortalama = (sınav1 + sınav2 + sınav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if(class1.islem=="guncelle")
            {
                var snv = db.Tbl_Not.Find(p.NotId);
                snv.DersId = p.DersId;
                snv.OgrId = p.OgrId;
                snv.Sınav1 = p.Sınav1;
                snv.Sınav2 = p.Sınav2;
                snv.Sınav3 = p.Sınav3;
                snv.Proje = p.Proje;
                snv.Ortalama = p.Ortalama;
                snv.Durum = p.Durum;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}