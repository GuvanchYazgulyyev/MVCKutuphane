using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class KategoriController : Controller
    {
        // GET: Kategori              İlk başta Kategorileri Listeler ToList()

        VTKutuphaneEntities2 dr = new VTKutuphaneEntities2();
        //[Authorize]
        public ActionResult Index()
        {
            var ktgetir = dr.TBLKategori.Where(x=>x.Durum==true).ToList();
            dr.SaveChanges();
            return View(ktgetir);
        }
       // [Authorize]
        [HttpGet]
        public ActionResult KatagoriEkle()
        {
            return View();
        }
        //                        [HttpPost] Oldugunda Kategorilere yeni bir Kategori Ekler Add(p)
       //[Authorize]
        [HttpPost]
        public ActionResult KatagoriEkle(TBLKategori p)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("KatagoriEkle");
            //}

            dr.TBLKategori.Add(p);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        // Silmek için önce Kategorileri bulur Find()
        //Sonra Remove() ile Siler
       // [Authorize]
        public ActionResult KategoriSil(int id)
        {
            //var ktgsil = dr.TBLKategori.Find(id);
            //dr.TBLKategori.Remove(ktgsil);
            //dr.SaveChanges();
            //return RedirectToAction("Index");

            var ktgsil = dr.TBLKategori.Find(id);
            ktgsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        // Kategorileri Güncellemeden önce Kategorileri Getirir
        //Fint ile , Sadece Arayüzünde verileri göterir
        //[Authorize]
        public ActionResult KategoriGetir(int id)
        {
            var ktgrgetr = dr.TBLKategori.Find(id);
            return View("KategoriGetir", ktgrgetr);
        }

        // Üstteki Komutta verileri getirdi burada ise güncelleme işlemi
        // Yapılır once Tablo bulunur Find(p.ID) sonra ise Var degiri 
        // ile güncelleme yapılır 
        //[Authorize]
        public ActionResult Guncelle(TBLKategori p)
        {
            var guncel = dr.TBLKategori.Find(p.ID);
            guncel.AD = p.AD;
            dr.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}