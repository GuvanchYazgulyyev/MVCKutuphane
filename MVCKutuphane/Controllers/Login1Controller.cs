using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
using System.Web.Security;

namespace MVCKutuphane.Controllers
{
    [AllowAnonymous]
    //[AllowAnonymous]    Bu kod sadece bu sayfaya izin verildigini gösterir.
    public class Login1Controller : Controller
    {
        // GET: Login1
        VTKutuphaneEntities2 dr
            = new VTKutuphaneEntities2();
        public ActionResult GirisYap()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GirisYap(TBLUyeler p)
        {
            var grsyp = dr.TBLUyeler.FirstOrDefault(f => f.Mail == p.Mail && f.Sifre == p.Sifre);
            if (grsyp != null)
            {

                FormsAuthentication.SetAuthCookie(grsyp.Mail, false);
                Session["Mail"] = grsyp.Mail.ToString();
                //TempData["ID"] = grsyp.ID.ToString();
                //TempData["Ad"] = grsyp.Ad.ToString();
                //TempData["Soyad"] = grsyp.Soyad.ToString();
                //TempData["KullaniciAd"] = grsyp.KullaniciAd.ToString();
                //TempData["Sifre"] = grsyp.Sifre.ToString();
                //TempData["okul"] = grsyp.OkulBilgi.ToString();

                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}