using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;


namespace MVCKutuphane.Controllers
{
    [AllowAnonymous]
    public class KayitOl1Controller : Controller
    {
     

        VTKutuphaneEntities2 dr
            = new VTKutuphaneEntities2();
        // GET: KayitOl1
        //[Authorize]
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        //[Authorize]
        [HttpPost]
        public ActionResult Kayit(TBLUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            dr.TBLUyeler.Add(p);
            dr.SaveChanges();
            return View();
        }
    }
}