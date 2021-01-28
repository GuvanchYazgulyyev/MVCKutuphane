using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class YazarController : Controller
    {
        // GET: Yazar
        VTKutuphaneEntities2 dr
            = new VTKutuphaneEntities2();
       // [Authorize]
        public ActionResult Index()
        {
            var yzrr1 = dr.TBLYazar.ToList();
            dr.SaveChanges();
            return View(yzrr1);
        }
       // [Authorize]
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

       // [Authorize]
        [HttpPost]
        public ActionResult YazarEkle( TBLYazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }

            dr.TBLYazar.Add(p);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize]
        public ActionResult YazarSil(int id)
        {
            var yazr2 = dr.TBLYazar.Find(id);
            dr.TBLYazar.Remove(yazr2);
            dr.SaveChanges();
            return RedirectToAction("Index");

        }
       // [Authorize]
        public ActionResult YazarGetir(int id)
        {
            var yazr3 = dr.TBLYazar.Find(id);
            return View("YazarGetir", yazr3);
        }
       // [Authorize]
        public ActionResult Guncelle(TBLYazar p)
        {
            var yazar4 = dr.TBLYazar.Find(p.ID);
            yazar4.Ad = p.Ad;
            yazar4.Soyad = p.Soyad;
            yazar4.Detay = p.Detay;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize]
        public ActionResult YazarKitaplar(int id)
        {
            var yazarkitap = dr.TBLKitap.Where(x => x.Yazar == id).ToList();
            var yazarad = dr.TBLYazar.Where(b => b.ID == id).Select(d => d.Ad + " " + d.Soyad).FirstOrDefault();
            ViewBag.y1 = yazarad;
            return View(yazarkitap);
        }

    }
}