using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class KategoriController : Controller
    {
        
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kategori
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLKATEGORI.Where(x=>x.DURUM==true).ToList().ToPagedList(sayfa,8);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            
                return View();
            
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            p.DURUM = true;
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult KategoriSil(int id)
        {

            var kategori = db.TBLKATEGORI.Find(id);
            //db.TBLKATEGORI.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            
            var ktg=db.TBLKATEGORI.Find(id);
            return View("KategoriGetir",ktg);
            
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}