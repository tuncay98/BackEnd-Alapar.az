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
        AlAparEntities db = new AlAparEntities();
        public ActionResult Index()
        {
            
            DataBaseForHome Data = new DataBaseForHome();
            Data.Elanler = db.Ads.Where(w=> w.StartDate< DateTime.Now).OrderByDescending(w=> w.StartDate).Take(AdCount).ToList();
            Data.Agentler = db.Agents.ToList();
            Data.VipElanlar = db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now).OrderByDescending(w => w.StartDate).Take(VipCount).ToList();
            Data.Sekiller = db.Images.ToList();
            Data.TamSiyahi = db.Ads.ToList();
            
            return View(Data);
        }

        public ActionResult LoadingMoreAds(int Length)
        {
           
            DataBaseForAdditionAds AdditionData = new DataBaseForAdditionAds();
            List<Ad> Listenmish = db.Ads.Where(w=> w.StartDate < DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
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




        
        public ActionResult Search(int MinMoney, int MaxMoney, int Length) {
            DataBaseForAdditionAds AdditionData = new DataBaseForAdditionAds();
            List<Ad> Listenmish = new List<Ad>();
            /*Searching System*/

            if ( MinMoney >0)
            {
                Listenmish = db.Ads.Where(w => w.Price > MinMoney && w.StartDate < DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
  

            }
            if(!(Listenmish.Count>0) && MaxMoney > 0)
            {
                Listenmish = db.Ads.Where(w => w.Price < MaxMoney && w.StartDate < DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
               
            }
            if (Listenmish.Count > 0 && MaxMoney >0)
            {
                Listenmish = db.Ads.Where(w => w.Price > MinMoney && w.Price < MaxMoney && w.StartDate < DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
            }
            





            AdditionData.Elanler = Listenmish;

            AdditionData.Sekiller = db.Images.ToList();

            return View(AdditionData);
        }
    }
}