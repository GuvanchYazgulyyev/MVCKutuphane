using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{


    public class PanelController : Controller
    {

        VTKutuphaneEntities2 dr = new VTKutuphaneEntities2();

        // [Authorize]
        public ActionResult Index()
        {
            var uymail = (string)Session["Mail"];
            // var deger = dr.TBLUyeler.FirstOrDefault(z => z.Mail == uymail);
            var deger = dr.TBLDuyuru.ToList();

            var d1 = dr.TBLUyeler.Where(x => x.Mail == uymail).Select(y => y.Ad).FirstOrDefault();
            ViewBag.d1 = d1;

            var d2 = dr.TBLUyeler.Where(x => x.Mail == uymail).Select(y => y.Soyad).FirstOrDefault();
            ViewBag.d2 = d2;

            var d3 = dr.TBLUyeler.Where(x => x.Mail == uymail).Select(y => y.Fotograf).FirstOrDefault();
            ViewBag.d3 = d3;


            var d4 = dr.TBLUyeler.Where(x => x.Mail == uymail).Select(y => y.KullaniciAd).FirstOrDefault();
            ViewBag.d4 = d4;

            var d5 = dr.TBLUyeler.Where(x => x.Mail == uymail).Select(y => y.OkulBilgi).FirstOrDefault();
            ViewBag.d5 = d5;

            var d6 = dr.TBLUyeler.Where(x => x.Mail == uymail).Select(y => y.Telefon).FirstOrDefault();
            ViewBag.d6 = d6;

            var d7 = dr.TBLUyeler.Where(x => x.Mail == uymail).Select(y => y.Mail).FirstOrDefault();
            ViewBag.d7 = d7;

            var uyeid = dr.TBLUyeler.Where(x => x.Mail == uymail).Select(y => y.ID).FirstOrDefault();
            var d8 = dr.TBLHareket.Where(x => x.Uye == uyeid).Count();
            ViewBag.d8 = d8;

            var d9 = dr.TBLMesaj.Where(x => x.Alici == uymail).Count();
            ViewBag.d9 = d9;

            var d10 = dr.TBLDuyuru.Count();
            ViewBag.d10 = d10;

            return View(deger);
        }

        [HttpPost]
        public ActionResult Index2(TBLUyeler p)
        {
            var kullaniciii = (string)Session["Mail"];
            var uyee = dr.TBLUyeler.FirstOrDefault(x => x.Mail == kullaniciii);
            uyee.Sifre = p.Sifre;
            uyee.Ad = p.Ad;
            uyee.Fotograf = p.Fotograf;
            uyee.OkulBilgi = p.OkulBilgi;
            uyee.KullaniciAd = p.KullaniciAd;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        // Alttaki Sorgu Şahsın aldıgı Kitapları gösterir. 
        // [Authorize]
        public ActionResult Kitaplarim()
        {
            var kullaniciii = (string)Session["Mail"];
            var id = dr.TBLUyeler.Where(b => b.Mail == kullaniciii.ToString()).Select(x => x.ID).FirstOrDefault();
            var deger = dr.TBLHareket.Where(x => x.Uye == id).ToList();
            return View(deger);
        }
        // [Authorize]
        public ActionResult Duyuru()
        {
            var duyr = dr.TBLDuyuru.ToList();
            return View(duyr);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login1");
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        public PartialViewResult Partial2()
        {
            var kullaniciii = (string)Session["Mail"];
            var id = dr.TBLUyeler.Where(x => x.Mail == kullaniciii).Select(y => y.ID).FirstOrDefault();
            var uyegetr = dr.TBLUyeler.Find(id);
            return PartialView("Partial2", uyegetr);
        }
    }
}