using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMVC.Models.EntityFrameWork;
namespace ÖğrenciNotMVC.Controllers
{
    public class kulupController : Controller
    {
        // GET: kulup
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        public ActionResult Index()
        {
            var kulupler = db.Tbl_Kulup.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult kulupekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kulupekle(Tbl_Kulup p )
        {
            db.Tbl_Kulup.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil (int id)
        {
            var kulup = db.Tbl_Kulup.Find(id);
            db.Tbl_Kulup.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult kulupgetir(int id)
        {
            var getir = db.Tbl_Kulup.Find(id);
            return View("kulupgetir",getir);
        }
        public ActionResult guncelle(Tbl_Kulup p )
        {
            var eski = db.Tbl_Kulup.Find(p.KulupId);
            eski.KulupAd = p.KulupAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}