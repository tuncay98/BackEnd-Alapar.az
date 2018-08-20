using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;
namespace AlApar.az.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public int AdCount = 20;
        public int VipCount = 40;
        alaparSql2Entities db = new alaparSql2Entities();
        public ActionResult Index()
        {
            
            DataBaseForHome Data = new DataBaseForHome();

            if(db.Ads.Where(w => w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).Count() >= 20)
            {
                Data.Elanler = db.Ads.Where(w => w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).Take(AdCount).ToList();

            }
            else
            {
                Data.Elanler = db.Ads.Where(w => w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();

            }
            Data.Agentler = db.Agents.ToList();
            if (db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).Count() >= 40) {
                Data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).Take(VipCount).ToList();

            }
            else
            {
                Data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();

            }
            Data.Sekiller = db.Images.ToList();
            Data.TamSiyahi = db.Ads.ToList();
            
            return View(Data);
        }

        public ActionResult LoadingMoreAds(int Length)
        {
           
            DataBaseForAdditionAds AdditionData = new DataBaseForAdditionAds();
            List<Ad> Listenmish = db.Ads.Where(w=> w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
            List<Ad> YeniListelenmish = new List<Ad>();
            if (Listenmish.Count > Length+20)
            {
                for (int i = Length; i < Length+20; i++)
                {
                    YeniListelenmish.Add(Listenmish[i]);
                }

            }
            else if(Listenmish.Count < Length+20)
            {

                for (int i = AdCount; i < Listenmish.Count; i++)
                {
                    YeniListelenmish.Add(Listenmish[i]);
                }

            }
          


            AdditionData.Elanler = YeniListelenmish;

            AdditionData.Sekiller = db.Images.ToList();

            return View(AdditionData);
        }


        public ActionResult LoadingMoreAdsVIP(int Length)
        {

            DataBaseForAdditionAds AdditionData = new DataBaseForAdditionAds();
            List<Ad> Listenmish = db.Ads.Where(w => w.StartDate < DateTime.Now & w.VIP== true && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
            List<Ad> YeniListelenmish = new List<Ad>();
            if (Listenmish.Count > Length + 20)
            {
                for (int i = Length; i < Length + 20; i++)
                {
                    YeniListelenmish.Add(Listenmish[i]);
                }

            }
            else if (Listenmish.Count < Length + 20)
            {

                for (int i = AdCount; i < Listenmish.Count; i++)
                {
                    YeniListelenmish.Add(Listenmish[i]);
                }

            }



            AdditionData.Elanler = YeniListelenmish;

            AdditionData.Sekiller = db.Images.ToList();

            return View(AdditionData);
        }




        public ActionResult Search(int MinMoney, int MaxMoney, int Length) {
            DataBaseForAdditionAds AdditionData = new DataBaseForAdditionAds();
            List<Ad> Listenmish = new List<Ad>();
            

            if ( MinMoney >0)
            {
                Listenmish = db.Ads.Where(w => w.Price > MinMoney && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
  

            }
            if(!(Listenmish.Count>0) && MaxMoney > 0)
            {
                Listenmish = db.Ads.Where(w => w.Price < MaxMoney && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
               
            }
            if (Listenmish.Count > 0 && MaxMoney >0)
            {
                Listenmish = db.Ads.Where(w => w.Price > MinMoney && w.Price < MaxMoney && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
            }
            





            AdditionData.Elanler = Listenmish;

            AdditionData.Sekiller = db.Images.ToList();

            return View(AdditionData);
        }

        public ActionResult Vip()
        {
            alaparSql2Entities db = new alaparSql2Entities();

            DataBaseForHome data = new DataBaseForHome();
            if( db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).Count() >= 20)
            {
                data.Elanler = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).Take(20).ToList();
            }
            else
            {
                data.Elanler = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).ToList();
            }
            
            data.Sekiller = db.Images.ToList();
            data.TamSiyahi= db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).ToList();

            return View(data);
        }


        public ActionResult SearchVIP(int MinMoney, int MaxMoney, int Length)
        {
            DataBaseForAdditionAds AdditionData = new DataBaseForAdditionAds();
            List<Ad> Listenmish = new List<Ad>();


            if (MinMoney > 0)
            {
                Listenmish = db.Ads.Where(w => w.Price > MinMoney && w.StartDate < DateTime.Now && w.VIP == true && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();


            }
            if (!(Listenmish.Count > 0) && MaxMoney > 0)
            {
                Listenmish = db.Ads.Where(w => w.Price < MaxMoney && w.StartDate < DateTime.Now & w.VIP == true && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();

            }
            if (Listenmish.Count > 0 && MaxMoney > 0)
            {
                Listenmish = db.Ads.Where(w => w.Price > MinMoney && w.Price < MaxMoney && w.StartDate < DateTime.Now & w.VIP == true && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
            }






            AdditionData.Elanler = Listenmish;

            AdditionData.Sekiller = db.Images.ToList();

            return View(AdditionData);
        }
    }
}

