using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class KitapController : Controller
    {
        VTKutuphaneEntities2 dr = new VTKutuphaneEntities2();
        // GET: Kitap
        //[Authorize]
        public ActionResult Index(string p)
        {
            var ktp1 = from k in dr.TBLKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                ktp1 = ktp1.Where(m => m.Ad.Contains(p));
            }
            //var ktp1 = dr.TBLKitap.ToList();
            return View(ktp1.ToList());
        }
        //[Authorize]
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in dr.TBLKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in dr.TBLYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        // Kitap Eklemek için öncelikle farklı tablolardan veri çektigi için öncelikle o 
        // tabloları getirdik Örnk: TblKategori ve TblYazar bu iki tabloları getirdik
       // [Authorize]
        [HttpPost]
        public ActionResult KitapEkle(TBLKitap p)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("KitapEkle");
            //}

            var ktgr = dr.TBLKategori.Where(k => k.ID == p.TBLKategori.ID).FirstOrDefault();
            var yazr = dr.TBLYazar.Where(b => b.ID == p.TBLYazar.ID).FirstOrDefault();
            p.TBLKategori = ktgr;
            p.TBLYazar = yazr;
            dr.TBLKitap.Add(p);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize]
        public ActionResult KitapSil(int id)
        {
            var ktpsil = dr.TBLKitap.Find(id);
            dr.TBLKitap.Remove(ktpsil);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize]
        public ActionResult KitapGetir(int id)
        {
            var ktpgtr = dr.TBLKitap.Find(id);
            List<SelectListItem> deger1 = (from i in dr.TBLKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in dr.TBLYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("KitapGetir", ktpgtr);
        }
        //[Authorize]
        public ActionResult KitapGuncelle(TBLKitap p)
        {
            var ktpguncl = dr.TBLKitap.Find(p.ID);
            ktpguncl.Ad = p.Ad;
            ktpguncl.BasimYil = p.BasimYil;
            ktpguncl.Sayfa = p.Sayfa;
            ktpguncl.YayinEvi = p.YayinEvi;
            ktpguncl.Durum = true;
            var ktg = dr.TBLKategori.Where(k => k.ID == p.TBLKategori.ID).FirstOrDefault();
            var yzr = dr.TBLYazar.Where(y => y.ID == p.TBLYazar.ID).FirstOrDefault();
            ktpguncl.Kategori = ktg.ID;
            ktpguncl.Yazar = yzr.ID;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}