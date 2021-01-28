using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class MesajController : Controller
    {
        VTKutuphaneEntities2 dr = new VTKutuphaneEntities2();
        // GET: Mesaj
        //[Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var msj = dr.TBLMesaj.Where(x => x.Alici == uyemail.ToString()).ToList();
          
            return View(msj);
        }

        //[Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(TBLMesaj m)
        {
            var uyemail = (string)Session["Mail"].ToString();
            m.Gonderen = uyemail.ToString();
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            dr.TBLMesaj.Add(m);
            dr.SaveChanges();
            return RedirectToAction("GidenMesaj","Mesaj");
        }

       // [Authorize]
        public ActionResult GidenMesaj()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var msj = dr.TBLMesaj.Where(x => x.Gonderen == uyemail.ToString()).ToList();
            return View(msj);
        }


        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();

            var gelensayisi = dr.TBLMesaj.Where(x => x.Alici == uyemail).Count();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = dr.TBLMesaj.Where(y => y.Gonderen == uyemail).Count();
            ViewBag.d2 = gidensayisi;

            return PartialView();
        }
    }
}