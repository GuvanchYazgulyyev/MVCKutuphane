using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models.Entity;

namespace MVCKutuphane.Controllers
{
    //[Authorize]
    public class islemlerController : Controller
    {
        // GET: islemler
        VTKutuphaneEntities2 dr
            = new VTKutuphaneEntities2();
     //   [Authorize]
        public ActionResult Index()
        {
            var islm = dr.TBLHareket.Where(z => z.islemDurum == true).ToList();
            return View(islm);
        }
    }
}