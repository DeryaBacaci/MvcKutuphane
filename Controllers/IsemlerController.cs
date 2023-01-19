using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{

    public class IsemlerController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Isemler
        public ActionResult Index()
        {
            var degerle = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerle);
        }

    }
}