using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;

namespace AlApar.az.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public alaparSql2Entities db = new alaparSql2Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuSearch(int id)
        {
        
            DataBaseForHome data = new DataBaseForHome();
            data.Agentler = db.Agents.ToList();
            data.Elanler = db.Ads.Where(w => w.RegionId == id && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
            data.Sekiller = db.Images.ToList();
            data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.RegionId == id && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
            if (data.VipElanlar.Count < 1)
            {
                data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();

            }
            return View(data);
        }

        public ActionResult Category(int id, int room)
        {
            DataBaseForHome data = new DataBaseForHome();

            data.Agentler = db.Agents.ToList();
            if (room == 0)
            {
                data.Elanler = db.Ads.Where(w => w.CategoryId == id && w.StartDate < DateTime.Now).ToList();
                data.Sekiller = db.Images.ToList();
                data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.CategoryId == id && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
                if (data.VipElanlar.Count < 1)
                {
                    data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
                }
            }
            else {

                if (room < 5)
                {
                    data.Elanler = db.Ads.Where(w => w.CategoryId == id & w.RoomId == room && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).ToList();
                    data.Sekiller = db.Images.ToList();
                    data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.CategoryId == id && w.RoomId == room && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
                    if (data.VipElanlar.Count < 1)
                    {
                        data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
                    }
                }
                else if(room==5)
                {
                    data.Elanler = db.Ads.Where(w => w.CategoryId == id & w.RoomId >= room && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).ToList();
                    data.Sekiller = db.Images.ToList();
                    data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.CategoryId == id && w.RoomId >= room && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
                    if (data.VipElanlar.Count < 1)
                    {
                        data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
                    }
                }
            }
            return View(data);

        }
    }
}