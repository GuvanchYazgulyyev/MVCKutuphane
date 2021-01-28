using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class PersonelController : Controller
    {
        // GET: Personel
        VTKutuphaneEntities2 dr
            = new VTKutuphaneEntities2();
       // [Authorize]
        public ActionResult Index()
        {
            var persnl = dr.TBLPersonel.ToList();
            dr.SaveChanges();
            return View(persnl);

        }
        //[Authorize]
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        //                        [HttpPost] Oldugunda PersonelEkle yeni bir Personel Ekler Add(p)
        //[Authorize]
        [HttpPost]
        public ActionResult PersonelEkle(TBLPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }

            dr.TBLPersonel.Add(p);
            dr.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelSil(int id)
        {
            var prsnl = dr.TBLPersonel.Find(id);
            dr.TBLPersonel.Remove(prsnl);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prsgetr = dr.TBLPersonel.Find(id);
            return View("PersonelGetir", prsgetr);
        }

        // Üstteki Komutta verileri getirdi burada ise güncelleme işlemi
        // Yapılır once Tablo bulunur Find(p.ID) sonra ise Var degiri 
        // ile güncelleme yapılır 
        public ActionResult PersonelGuncelle(TBLPersonel p)
        {
            var prsgcel = dr.TBLPersonel.Find(p.ID);
            prsgcel.Personel = p.Personel;
            dr.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}