using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
using PagedList; ///  Sayfalama için gerekli olan Kütüphaneler
using PagedList.Mvc;  ///  Sayfalama için gerekli olan Kütüphaneler

namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class UyeController : Controller
    {
        // GET: Uye             
        VTKutuphaneEntities2 dr = new VTKutuphaneEntities2();
        /// Sayfalamak için gerekli olan komutlar ilk olarak yukarıdaki kütüphanelere 
        /// Yüklemek sonra Alttaki Index den  Index(int sayfa = 1)
        /// ve bunun altına   var uyee = dr.TBLUyeler.ToList().ToPagedList(sayfa, 5);
        /// return View(uyee);
        /// yazılır

        //[Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            //var uyee = dr.TBLUyeler.ToList();
            var uyee = dr.TBLUyeler.ToList().ToPagedList(sayfa, 5);
            return View(uyee);
        }

       // [Authorize]
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        //                        [HttpPost] Oldugunda ÜyeEkle yeni bir Personel Ekler Add(p)
       // [Authorize]
        [HttpPost]
        public ActionResult UyeEkle(TBLUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }

            dr.TBLUyeler.Add(p);
            dr.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }

        //[Authorize]
        public ActionResult UyeSil(int id)
        {
            var uysl = dr.TBLUyeler.Find(id);
            dr.TBLUyeler.Remove(uysl);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize]
        public ActionResult UyeGetir(int id)
        {
            var uygtr = dr.TBLUyeler.Find(id);
            return View("UyeGetir", uygtr);
        }

        // Üstteki Komutta verileri getirdi burada ise güncelleme işlemi
        // Yapılır once Tablo bulunur Find(p.ID) sonra ise Var degiri 
        // ile güncelleme yapılır 
        //[Authorize]
        public ActionResult UyeGuncelle(TBLUyeler p)
        {
            var uygncl = dr.TBLUyeler.Find(p.ID);
            uygncl.Ad = p.Ad;
            uygncl.Soyad = p.Soyad;
            uygncl.Mail = p.Mail;
            uygncl.KullaniciAd = p.KullaniciAd;
            uygncl.Sifre = p.Sifre;
            uygncl.Fotograf = p.Fotograf;
            uygncl.Telefon = p.Telefon;
            uygncl.OkulBilgi = p.OkulBilgi;
            dr.SaveChanges();
            return RedirectToAction("Index");

        }
       // [Authorize]
        public ActionResult UyeKitapGecmis(int id)
        {
            var kitapgecms = dr.TBLHareket.Where(x => x.Uye == id).ToList();
            var uyekitap = dr.TBLUyeler.Where(s => s.ID == id).Select(g => g.Ad + " " + g.Soyad).FirstOrDefault();
            ViewBag.uye1 = uyekitap;
            return View(kitapgecms);
        }

    }
}