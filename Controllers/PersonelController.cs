using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class PersonelController : Controller
    {
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {

            return View();

        }
        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL p)
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult PersonelSil(int id)
        {
            var Personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(Personel);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelGetir(int id)
        {

            var prs = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", prs);

        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = db.TBLPERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}