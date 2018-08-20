using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;

namespace AlApar.az.Areas.AP.Controllers
{
    public class LogController : Controller
    {
        alaparSql2Entities db = new alaparSql2Entities();
        // GET: AP/Log
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult In(string email, string pass)
        {
            List<Admin> admins = db.Admins.ToList();
            foreach (var item in admins)
            {
                if(item.Username == email && item.Password == pass)
                {
                    Session["LogedIn"] = true;
                    return RedirectToAction("Index", "Ads");
                }
            }


            Session["WrongInfo"] = true;
            return RedirectToAction("Index", "Log");
        }
        public ActionResult Out()
        {
            Session["LogedIn"] = null;
            return RedirectToAction("Index");
        }
    }
}