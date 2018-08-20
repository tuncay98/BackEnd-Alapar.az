using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;
using System.Net.Mail;
using System.Net;

namespace AlApar.az.Controllers
{
    public class ElaveEtController : Controller
    {
        alaparSql2Entities db = new alaparSql2Entities();

        // GET: ElaveEt
        public ActionResult Index()
        {
            DataBaseForAddingAds baza = new DataBaseForAddingAds();
            baza.Seherler = db.Cities.ToList();
            baza.Rayonlar = db.Regions.ToList();
            baza.Qesebeler = db.Villages.ToList();
            baza.OtaqSaylari = db.RoomCounts.ToList();
            baza.Kategoriyalar = db.Categories.ToList();
            baza.Bina_Novu = db.BuildingTypes.ToList();
            return View(baza);
        }

        
        public ActionResult Add(string Basliq, string Kupca, string Name, string SellerType, string Phone, string Email, string City, string Categoryİd, string OfisOtaqSayi,
            string RoomMenzil, string MenzilOtaqSayi, string MenzilBinaMertebeSayi, string HeyetOtaqSayi, string TorpaqSahesi,
            string MekanTipi,string Sahe, string Melumat, int PriceOfAd, string Unvan, string Rayon, string Qesebe, string Xloc,
            string Yloc, HttpPostedFileBase[] PhotoUpload)
        {

            if (Xloc != string.Empty && Yloc!= string.Empty && Name != string.Empty && SellerType != string.Empty && Phone != string.Empty && Email != string.Empty && City!= string.Empty && Categoryİd != string.Empty &&
                Sahe != string.Empty && Melumat != string.Empty && PriceOfAd > 0 && Unvan!= string.Empty && Basliq!= string.Empty)
            {
               
                if (PhotoUpload.Length < 3)
                {
                    Session["Sekilin3denAzOlmasi"] = true;
                    return RedirectToAction("Index", "ElaveEt");
                }
                foreach (var item in PhotoUpload)
                {
                    if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                    {
                        Session["SekilDuzFormatdaDeyil"] = true;
                        return RedirectToAction("Index", "ElaveEt");
                    }
                }

                Ad YeniElan = new Ad();
            YeniElan.OwnerName = Name;
            YeniElan.OwnerType = (SellerType == "false")?false:true;
            YeniElan.Phone = Phone;
            YeniElan.Email = Email;
            YeniElan.CityId = Convert.ToInt32(City);
            YeniElan.CategoryId = Convert.ToInt32(Categoryİd);
            if((RoomMenzil != "0") &&  MenzilOtaqSayi != string.Empty &&  MenzilBinaMertebeSayi != string.Empty)
            {
                YeniElan.RoomId = Convert.ToInt32(RoomMenzil);
                YeniElan.Mertebe = MenzilOtaqSayi;
                YeniElan.BinaMertebesi = MenzilBinaMertebeSayi;
            }

            if ((HeyetOtaqSayi != "0") &&  TorpaqSahesi != string.Empty)
            { 
                YeniElan.RoomId = Convert.ToInt32(HeyetOtaqSayi);
                YeniElan.TorpaqSahesi = TorpaqSahesi;
            }
            if ( OfisOtaqSayi != "0" && MekanTipi != string.Empty)
            {
                YeniElan.RoomId = Convert.ToInt32(OfisOtaqSayi);
                YeniElan.BuildingTypeId = Convert.ToInt32(MekanTipi);
            }
            if ( Rayon != "0" && Qesebe != string.Empty)
            {
                YeniElan.RegionId = Convert.ToInt32(Rayon);
                YeniElan.VillageId = Convert.ToInt32(Qesebe);
            }
            YeniElan.Sahe = Sahe;
            YeniElan.Text = Melumat;
            YeniElan.Price = PriceOfAd;
            YeniElan.Adress = Unvan;
            
            YeniElan.XLocation = Xloc;
            YeniElan.YLocation = Yloc;
            YeniElan.PinCode = DateTime.Now.ToString("yyyyMMddHHmmss") + Name.Substring(0, 2);
            YeniElan.Kupca = (Kupca == "false" ? false : true);
            YeniElan.VIP = false;
            YeniElan.Title = Basliq;
                if (Session["DaxilOlanID"] != null)
                {
                    YeniElan.ProfileId = Convert.ToInt32(Session["DaxilOlanID"]);
                }
                if (Session["AgentId"] != null)
                {
                    YeniElan.AgentId = Convert.ToInt32(Session["AgentId"]);
                }
            db.Ads.Add(YeniElan);
            db.SaveChanges();


              
                    foreach (var item in PhotoUpload)
                    {
                        string Filename = DateTime.Now.ToString("yyyyMMddHHmmss") + item.FileName;
                        var myfile = System.IO.Path.Combine(Server.MapPath("~/Assest/images/UploadAdsImages"), Filename);
                        item.SaveAs(myfile);
                        Image SekillerToplusu = new Image
                        {
                            ElanId = YeniElan.Id,
                            Name = Filename
                        };

                        db.Images.Add(SekillerToplusu);
                        db.SaveChanges();
                    }


                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "tuncayhuseynov@gmail.com";
                string password = "5591980supertun";
                string emailTo = Email.ToString();


                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = "Elanınızın Pin Kodu";
                    mail.Body = "Sizin Elanınınzın Pin Kodu: " + DateTime.Now.ToString("yyyyMMddHHmmss") + Name.Substring(0, 2);
                    mail.IsBodyHtml = false;
                    // Can set to false, if you are sending pure text.

                   

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }



                return RedirectToAction("Index", "AdPage", new { id = YeniElan.Id });
            }
            else
            {
                Session["TamDoldurun"] = true;
                return RedirectToAction("Index", "ElaveEt");
            }
            
            
            



            
        }

    }
}