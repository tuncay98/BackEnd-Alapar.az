using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;

namespace AlApar.az.Controllers
{
    public class AdPageController : Controller
    {
        AlAparEntities db = new AlAparEntities();
        // GET: AdPage
        public ActionResult Index(int id)
        {
            DataBaseForHome data = new DataBaseForHome();
            data.TamSiyahi = db.Ads.Where(w => w.Id == id).ToList();
            data.Sekiller = db.Images.Where(w=> w.ElanId == id).ToList();
            data.Elanler = db.Ads.OrderByDescending(o => o.StartDate).Take(9).ToList();

            return View(data);
        }

        public ActionResult Sikayet(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult SendNum(string Phone, int Elanid)
        {
            complain YeniSikayet = new complain();
            YeniSikayet.Phone = Phone;
            YeniSikayet.ElanId = Elanid;
            db.complains.Add(YeniSikayet);
            db.SaveChanges();

            return RedirectToAction("Index", "AdPage", new { id = Elanid });
        }


    }
}