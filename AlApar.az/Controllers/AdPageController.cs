using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;

namespace AlApar.az.Controllers
{
    public class AdPageController : Controller
    {
        alaparSql2Entities db = new alaparSql2Entities();
        // GET: AdPage
        public ActionResult Index(int id)
        {
            DataBaseForHome data = new DataBaseForHome();
            data.TamSiyahi = db.Ads.Where(w => w.Id == id).ToList();
            data.Sekiller = db.Images.ToList();
            if (db.Ads.Where(w => w.VIP == true && w.StartDate < DateTime.Now && w.EndDate> DateTime.Now).OrderByDescending(w => w.StartDate).Count() >= 9)
            {
                data.Elanler = db.Ads.Where(w => w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).Take(9).ToList();
            }
            else
            {
                data.Elanler = db.Ads.Where(w => w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).OrderByDescending(w => w.StartDate).ToList();
            }

            return View(data);
        }

        public ActionResult Sikayet(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult Sil(string Pin, int Id)
        {
            Ad Elan = db.Ads.Find(Id);
            if(Elan.PinCode == Pin)
            {
                db.Ads.Remove(Elan);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            Session["PinSehv"] = true;
            return RedirectToAction("Index", "AdPage", new { id = Id });
        }

        public ActionResult SendNum(string Phone, int Elanid)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "tuncayhuseynov@gmail.com";
            string password = "5591980supertun";
            string emailTo = "tuncayhuseynov@gmail.com";


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = "Elanınızın Pin Kodu";
                mail.Body = "Sikayet Var, Sikayet Edenin Nomresi: " + Phone + " Siayet Edilen Elan: " + Elanid;
                mail.IsBodyHtml = false;
                // Can set to false, if you are sending pure text.



                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }


            return RedirectToAction("Index", "AdPage", new { id = Elanid });
        }


    }
}