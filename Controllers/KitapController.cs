using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class KitapController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kitap
        public ActionResult Index(string p)
        {
            //var kitaplar = db.TBLKITAP.ToList();

            var kitaplar = from k in db.TBLKITAP select k;
            if(!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));
            }
            
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {

            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from a in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = a.AD + " " + a.SOYAD,
                                               Value = a.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
            //FirstOrDefault();    =ilk yada seçilmiş değeri getir.

            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yazr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            p.TBLYAZAR = yazr;
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var ktp = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBLKITAP.Find(id);

            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from a in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = a.AD + " " + a.SOYAD,
                                               Value = a.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;


            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(TBLKITAP p)
        {
            var ktp = db.TBLKITAP.Find(p.ID);
            ktp.AD = p.AD;
            ktp.BASIMYIL=p.BASIMYIL;
            ktp.SAYFA=p.SAYFA;  
            ktp.YAYINEVI=p.YAYINEVI;
            ktp.DURUM = true;
            var kategori = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(y=>y.ID==p.TBLYAZAR.ID).FirstOrDefault();
            ktp.KATEGORI = kategori.ID;
            ktp.YAZAR=yazar.ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}