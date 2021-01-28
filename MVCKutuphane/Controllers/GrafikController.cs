using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;

namespace MVCKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KitapSonucu()
        {
            return Json(liste());
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayinevi = "Güneş",
                sayi = 21

            });

            cs.Add(new Class1()
            {
                yayinevi = "Yıldız",
                sayi = 19

            });
            cs.Add(new Class1()
            {
                yayinevi = "İstanbul",
                sayi = 15

            });
            return cs;
        }
    }
}