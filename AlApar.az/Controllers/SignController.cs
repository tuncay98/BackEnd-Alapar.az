using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;
using System.Web.Helpers;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace AlApar.az.Controllers
{
    public class SignController : Controller
    {
        // GET: Sign
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string Username, string Password)
        {
            alaparSql2Entities db = new alaparSql2Entities();

            foreach (var a in db.Profiles)
            {
                

                if(a.Username == Username && Crypto.VerifyHashedPassword(a.Password, Password))
                {
                    Session["DaxilOlundu"] = a.Username;
                    Session["DaxilOlanID"] = a.Id;
                    return RedirectToAction("Index", "Home");
                }
            }

            foreach (var b in db.Agents)
            {
                if(b.Username == Username && b.Password == Password)
                {
                    Session["AgentIcerde"] = b.Username;
                    Session["AgentId"] = b.Id;
                    return RedirectToAction("Index", "Home");
                }
            }

            Session["MelumatSehvi"] = true;

            return RedirectToAction("Index", "Sign");
        }

        public ActionResult LogOut()
        {
            Session["DaxilOlundu"] = null;
            Session["DaxilOlanID"] = null;
            Session["AgentIcerde"] = null;
            Session["AgentId"] = null;
            return RedirectToAction("index", "Home");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string Username, string Email, string Password)
        {
            alaparSql2Entities db = new alaparSql2Entities();

            foreach (var item in db.Profiles)
            {
                if(item.Username== Username)
                {
                    Session["UsernameTutulub"] = true;
                    return RedirectToAction("SignUp");
                }
                if(item.Email== Email)
                {
                    Session["EmailTutulub"] = true;
                    return RedirectToAction("SignUp");
                }

            }
            Profile YeniProfile = new Profile();

            YeniProfile.Username = Username;
            YeniProfile.Email = Email;

            string Pass = Crypto.HashPassword(Password);

            YeniProfile.Password = Pass;
            db.Profiles.Add(YeniProfile);
            db.SaveChanges();




            return RedirectToAction("Index");
        }


        public ActionResult Forgot()
        {
            return View();
        }

        public ActionResult SendEmail(string Email)
        {
            alaparSql2Entities db = new alaparSql2Entities();
            foreach (var item in db.Profiles)
            {
                if (item.Email == Email)
                {
                    SmtpClient smtpClient = new SmtpClient("mail.alapar.az", 25);

                    smtpClient.Credentials = new System.Net.NetworkCredential("info@alapar.az", "5591980Super");
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    MailMessage mail = new MailMessage();

                    //Setting From , To and CC
                    mail.From = new MailAddress("info@alapar", "Alapar.az");
                    mail.To.Add(new MailAddress(Email));
                    mail.Subject = "Şifrə Yenilənməsi";
                    mail.Body = "Şifrənizi Yeniləmək Üçün: www.alapar.az/Sign/ChangePage/"+item.Id + "     istifadəçi Adınız: " + item.Username;
                    

                    smtpClient.Send(mail);

                    Session["EmailSent"] = true;
                    return RedirectToAction("Forgot");
                }
            }

            Session["WrongEmail"] = true;
            return RedirectToAction("Forgot");
        }

        public ActionResult ChangePage(int id)
        {
            alaparSql2Entities db = new alaparSql2Entities();
            Profile Sexs = db.Profiles.Find(id);
            ViewBag.Sexs = Sexs.Id;
                
            return View();
        }

        public ActionResult CompChange(int id, string Pass)
        {
            alaparSql2Entities db = new alaparSql2Entities();
             

            string pa= Crypto.HashPassword(Pass);
            db.Profiles.Find(id).Password = pa;
            db.SaveChanges();

            return RedirectToAction("Index", "Sign");
        }
    }
}