using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class OduncController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities ();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerle = db.TBLHAREKET.Where(x=>x.ISLEMDURUM==false).ToList();
            return View(degerle);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD+ " "+x.SOYAD,
                                               Value=x.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr1=deger1;

            List<SelectListItem> deger2=(from y in db.TBLKITAP.Where(x=>x.DURUM==true).ToList()
                                         select new SelectListItem
                                         {
                                             Text=y.AD,
                                             Value=y.ID.ToString()
                                         }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from z in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.PERSONEL,
                                               Value = z.ID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            return View();
        }
       
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            var d1 = db.TBLUYELER.Where(x => x.ID == p.TBLUYELER.ID).FirstOrDefault();
            var d2 = db.TBLKITAP.Where(x => x.ID == p.TBLKITAP.ID).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(x => x.ID == p.TBLPERSONEL.ID).FirstOrDefault();
            p.TBLUYELER = d1;
            p.TBLKITAP = d2;
            p.TBLPERSONEL = d3;
            db.TBLHAREKET.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Odunciade(TBLHAREKET p)
        {
            var odunc=db.TBLHAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(odunc.IADETARIH.ToString());
            DateTime d2 =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade", odunc);
        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hareket = db.TBLHAREKET.Find(p.ID);
            hareket.UYEGETIRTARIH=p.UYEGETIRTARIH;
            hareket.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}