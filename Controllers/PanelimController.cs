using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Panelim
        [HttpGet]
      
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var d1 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(x => x.AD).FirstOrDefault();
            var d2 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(x => x.SOYAD).FirstOrDefault();
            var d3 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(x => x.FOTOGRAFI).FirstOrDefault();
            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            return View(degerler);


        }
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.TELEFON = p.TELEFON;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanici.ToString()).Select(x => x.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);

        }
       
        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        
        
    }
}