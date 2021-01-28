using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCKutuphane.Models.Entity;


namespace MVCKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        VTKutuphaneEntities2 dr = new VTKutuphaneEntities2();
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(TBLAdmin p)
        {
            var admngirs = dr.TBLAdmin.FirstOrDefault(f => f.KullaniciAd == p.KullaniciAd
              && f.Sifre == p.Sifre);
            if (admngirs != null)
            {
                FormsAuthentication.SetAuthCookie(admngirs.KullaniciAd, false);
                Session["KullaniciAd"] = admngirs.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}