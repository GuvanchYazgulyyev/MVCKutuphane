using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class istatistikController : Controller
    {
        VTKutuphaneEntities2 dr = new VTKutuphaneEntities2();
        // GET: istatistik
        //[Authorize]
        public ActionResult Index()
        {
            var deger1 = dr.TBLUyeler.Count();
            var deger2 = dr.TBLKitap.Count();
            var deger3 = dr.TBLKitap.Where(x => x.Durum == false).Count();
            var deger4 = dr.TBLCeza.Sum(x => x.Para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
       // [Authorize]
        public ActionResult Hava()
        {
            return View();
        }
        //[Authorize]
        public ActionResult HavaKart()
        {
            return View();
        }
       // [Authorize]
        public ActionResult Galeri()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult resimyukle(HttpPostedFileBase dosya)
        //{
        //    if (dosya.ContentLength > 0)
        //    {
        //        string dosyayolu=
        //    }
        //    return View();
        //}

      //  [Authorize]
        public ActionResult LinquKart()
        {
            var deger1 = dr.TBLKitap.Count();
            var deger2 = dr.TBLUyeler.Count();
            var deger3 = dr.TBLCeza.Sum(x => x.Para);
            var deger4 = dr.TBLKitap.Where(c => c.Durum == false).Count();
            var deger5 = dr.TBLKategori.Count();
            var deger6 = dr.EnAktifUye().FirstOrDefault();
            var deger7 = dr.EnCokOkunanKitap().FirstOrDefault();
            var deger8 = dr.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = dr.TBLKitap.GroupBy(v => v.YayinEvi).OrderByDescending(d => d.Count()).Select
                (t => new { t.Key }).FirstOrDefault();
            var deger10 = dr.EnBasariliPersonel().FirstOrDefault();
            var deger11 = dr.TBLiletisim.Count();
            var deger12 = dr.BugunEmanetVerilenK().FirstOrDefault();
            ViewBag.dg1 = deger1;
            ViewBag.dg2 = deger2;
            ViewBag.dg3 = deger3;
            ViewBag.dg4 = deger4;
            ViewBag.dg5 = deger5;
            ViewBag.dg6 = deger6;
            ViewBag.dg7 = deger7;
            ViewBag.dg8 = deger8;
            ViewBag.dg9 = deger9;
            ViewBag.dg10 = deger10;
            ViewBag.dg11 = deger11;
            ViewBag.dg12 = deger12;
            return View();
        }
    }
}