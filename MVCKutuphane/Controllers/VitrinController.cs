using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;
using MVCKutuphane.Models.Entity.Siniflarim;

namespace MVCKutuphane.Controllers
{
    [AllowAnonymous]

    public class VitrinController : Controller
    {
        // GET: Vitrin
        VTKutuphaneEntities2 dr = new VTKutuphaneEntities2();

       // [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cls = new Class1();
            cls.deger1 = dr.TBLKitap.ToList();
            cls.deger2 = dr.TBLHakkimizda.ToList();
            //var ktplist = dr.TBLKitap.ToList();
            //return View(ktplist);
            return View(cls);
        }
       // [Authorize]
        [HttpPost]
        public ActionResult Index(TBLiletisim c)
        {
            dr.TBLiletisim.Add(c);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}