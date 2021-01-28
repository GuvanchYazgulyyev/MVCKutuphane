using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class DuyurularController : Controller
    {
        VTKutuphaneEntities2 dr
            = new VTKutuphaneEntities2();
        // GET: Duyurular
        public ActionResult Index()
        {
            var duyur = dr.TBLDuyuru.ToList();
            return View(duyur);
        }
       // [Authorize]
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
       // [Authorize]
        [HttpPost]
        public ActionResult DuyuruEkle(TBLDuyuru p)
        {
            dr.TBLDuyuru.Add(p);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
       // [Authorize]
        public ActionResult DuyuruSil(int id)
        {
            var duyurusl = dr.TBLDuyuru.Find(id);
            dr.TBLDuyuru.Remove(duyurusl);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
       // [Authorize]
        public ActionResult DuyuruDetay(TBLDuyuru p)
        {
            var duyrudtay = dr.TBLDuyuru.Find(p.ID);
            return View("DuyuruDetay", duyrudtay);
        }
       // [Authorize]
        public ActionResult DuyuruGuncelle(TBLDuyuru t)
        {
            var dd1 = dr.TBLDuyuru.Find(t.ID);
            dd1.DuyuruBaslik = dd1.DuyuruBaslik;
            dd1.Icerik = dd1.Icerik;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}