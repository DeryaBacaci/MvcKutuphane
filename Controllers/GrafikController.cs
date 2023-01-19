using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KitapSonuclariniGorsellestir()
        {
            return Json(liste());
        }
        public List<Class2> liste()
        {
            List<Class2> cs = new List<Class2>();
            cs.Add(new Class2()
            {
                yayinevi="Güneş",
                sayi=6
            });

           
            cs.Add(new Class2()
            {

                yayinevi = "Yıldız",
                sayi = 4
            });

            cs.Add(new Class2()
            {

                yayinevi = "Çiçek",
                sayi = 2
            });
            return cs;
        }
    }
}