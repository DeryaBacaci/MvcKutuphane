﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLYAZAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            if(!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBLYAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yazar=db.TBLYAZAR.Find(id);

            return View("YazarGetir",yazar);
        }
        public ActionResult YazarGuncelle(TBLYAZAR y)
        {
            var yazr = db.TBLYAZAR.Find(y.ID);
            yazr.AD=y.AD;
            yazr.SOYAD=y.SOYAD;
            yazr.DETAY=y.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YazarınKitapları (int id)
        {
            var yazarkitapları = db.TBLKITAP.Where(x => x.YAZAR == id).ToList();
            var yazarAdSoyadı = db.TBLYAZAR.Where(y=>y.ID==id).Select(z=>z.AD+" "+z.SOYAD).FirstOrDefault();
            ViewBag.yazarAdSoyad = yazarAdSoyadı;
            return View(yazarkitapları);
        }
    }
}