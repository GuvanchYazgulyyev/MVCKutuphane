using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class OduncController : Controller
    {
        // GET: Odunc
        VTKutuphaneEntities2 dr
            = new VTKutuphaneEntities2();
        //[Authorize]
        public ActionResult Index()
        {
            var ktpver = dr.TBLHareket.Where(x => x.islemDurum == false).ToList();
            return View(ktpver);
        }
       // [Authorize]
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in dr.TBLUyeler.ToList()
                                           select
                                new SelectListItem
                                {
                                    Text = x.Ad + "" + x.Soyad,
                                    Value = x.ID.ToString()
                                }).ToList();
            ViewBag.d1 = deger1;

            List<SelectListItem> deger2 = (from y in dr.TBLKitap.Where(h=>h.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.Ad,
                                               Value = y.ID.ToString()
                                           }).ToList();
            ViewBag.d2 = deger2;

            List<SelectListItem> deger3 = (from f in dr.TBLPersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = f.Personel,
                                               Value = f.ID.ToString()
                                           }).ToList();
            ViewBag.d3 = deger3;


            return View();
        }

       // [Authorize]
        [HttpPost]
        public ActionResult OduncVer(TBLHareket p)
        {
            var d1 = dr.TBLUyeler.Where(s => s.ID == p.TBLUyeler.ID).FirstOrDefault();
            var d2 = dr.TBLKitap.Where(t => t.ID == p.TBLKitap.ID).FirstOrDefault();
            var d3 = dr.TBLPersonel.Where(k => k.ID == p.TBLPersonel.ID).FirstOrDefault();
            p.TBLUyeler = d1;
            p.TBLKitap = d2;
            p.TBLPersonel = d3;
            dr.TBLHareket.Add(p);
            dr.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }

       // [Authorize]
        public ActionResult Odunciade(TBLHareket p)
        {
            // Bu alttaki kodlar kişinin ne zaman kitabı iade ettigini gösterir.
            //

            var odnciade = dr.TBLHareket.Find(p.ID);
            DateTime d1 = DateTime.Parse(odnciade.IadeTarih.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            ; return View("Odunciade", odnciade);
        }
       // [Authorize]
        public ActionResult OduncGuncelle(TBLHareket p)
        {
            var hrktgnc = dr.TBLHareket.Find(p.ID);
            hrktgnc.UyeGetirTarih = p.UyeGetirTarih;
            hrktgnc.islemDurum = true;
            dr.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}