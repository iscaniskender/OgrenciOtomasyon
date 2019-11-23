using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMVC.Models.EntityFrameWork;

namespace ÖğrenciNotMVC.Controllers
{
    public class DerslerController : Controller
    {
        // GET: Default
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        public ActionResult Index()
        {
            var dersler = db.Tbl_Dersler.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult dersekle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult dersekle(Tbl_Dersler p)
        {
            db.Tbl_Dersler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult sil (int id)
        {
            var gelen = db.Tbl_Dersler.Find(id);
            db.Tbl_Dersler.Remove(gelen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult dersgetir(int id)
        {
            var getir = db.Tbl_Dersler.Find(id);
            return View("dersgetir", getir);
        }
        public ActionResult guncelle (Tbl_Dersler p)
        {
            var bul = db.Tbl_Dersler.Find(p.DersId);
            bul.DersAd = p.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}