using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;
using AlApar.az.Filtre;

namespace AlApar.az.Areas.AP.Controllers
{

    [Auth]
    public class AllAdsController : Controller
    {
        private alaparSql2Entities db = new alaparSql2Entities();

        // GET: AP/AllAds
        public ActionResult Index()
        {
            var ads = db.Ads.Include(a => a.Agent).Include(a => a.BuildingType).Include(a => a.Category).Include(a => a.City).Include(a => a.Profile).Include(a => a.Region).Include(a => a.RoomCount).Include(a => a.Village);
            return View(ads.ToList());
        }

        // GET: AP/AllAds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // GET: AP/AllAds/Create
        public ActionResult Create()
        {
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Username");
            ViewBag.BuildingTypeId = new SelectList(db.BuildingTypes, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "Email");
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name");
            ViewBag.RoomId = new SelectList(db.RoomCounts, "Id", "Name");
            ViewBag.VillageId = new SelectList(db.Villages, "Id", "Name");
            return View();
        }

        // POST: AP/AllAds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Price,OwnerName,OwnerType,StartDate,EndDate,PinCode,CityId,CategoryId,RegionId,VillageId,Text,Phone,XLocation,YLocation,AgentId,ProfileId,VIP,Kupca,RoomId,BuildingTypeId,Mertebe,BinaMertebesi,Sahe,TorpaqSahesi,Email,Adress")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Ads.Add(ad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Username", ad.AgentId);
            ViewBag.BuildingTypeId = new SelectList(db.BuildingTypes, "Id", "Name", ad.BuildingTypeId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", ad.CategoryId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", ad.CityId);
            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "Email", ad.ProfileId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", ad.RegionId);
            ViewBag.RoomId = new SelectList(db.RoomCounts, "Id", "Name", ad.RoomId);
            ViewBag.VillageId = new SelectList(db.Villages, "Id", "Name", ad.VillageId);
            return View(ad);
        }

        // GET: AP/AllAds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Username", ad.AgentId);
            ViewBag.BuildingTypeId = new SelectList(db.BuildingTypes, "Id", "Name", ad.BuildingTypeId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", ad.CategoryId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", ad.CityId);
            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "Email", ad.ProfileId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", ad.RegionId);
            ViewBag.RoomId = new SelectList(db.RoomCounts, "Id", "Name", ad.RoomId);
            ViewBag.VillageId = new SelectList(db.Villages, "Id", "Name", ad.VillageId);
            return View(ad);
        }

        // POST: AP/AllAds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Price,OwnerName,OwnerType,StartDate,EndDate,PinCode,CityId,CategoryId,RegionId,VillageId,Text,Phone,XLocation,YLocation,AgentId,ProfileId,VIP,Kupca,RoomId,BuildingTypeId,Mertebe,BinaMertebesi,Sahe,TorpaqSahesi,Email,Adress")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Username", ad.AgentId);
            ViewBag.BuildingTypeId = new SelectList(db.BuildingTypes, "Id", "Name", ad.BuildingTypeId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", ad.CategoryId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", ad.CityId);
            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "Email", ad.ProfileId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", ad.RegionId);
            ViewBag.RoomId = new SelectList(db.RoomCounts, "Id", "Name", ad.RoomId);
            ViewBag.VillageId = new SelectList(db.Villages, "Id", "Name", ad.VillageId);
            return View(ad);
        }

        // GET: AP/AllAds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // POST: AP/AllAds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ad ad = db.Ads.Find(id);
            List<Image> sekiller = db.Images.Where(w => w.ElanId == id).ToList();
            foreach (var item in sekiller)
            {
                db.Images.Remove(item);
            }
            db.Ads.Remove(ad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
