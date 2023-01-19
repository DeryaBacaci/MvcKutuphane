using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities(); 
        // GET: AdminLogin
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN p)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x=>x.Kullanici==p.Kullanici && x.Sifre==p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMIN p)
        {
            db.TBLADMIN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
       
    }
}