using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication4.BusinessLogic;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class InviteController : Controller
    {

        private FileBusinessLogic _fileBusinessLogic;

        public InviteController()
        {
            //tworzymy nową instację warstwy biznesowej w konstruktorze
            _fileBusinessLogic = new FileBusinessLogic();

        }
        //Get
        public ActionResult Index()
        {
            return View("InviteGuest");
        }

        //post
        [HttpPost]
        public ActionResult InviteGuest(InviteModel model)
        {

            if (ModelState.IsValid)
            {
                SendEmail(model);
                return View("Thanks", model);
            }
            return View("InviteGuest", model);
        }


        private void SendEmail(InviteModel mailModel)
        {
            //konfiguracja i autoryzacja ze skrzynką mailowa
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials =
                new NetworkCredential("gym550182@gmail.com", "!QAZ2wsx#EDC")

            };
            //tworzenie nowej wiadomosci email
            var mailMessage = new MailMessage
            {
                Sender = new MailAddress("gym550182@gmail.com"),
                From = new MailAddress("gym550182@gmail.com"),
                To = { mailModel.Email},
                Subject = "temat maila"
,                Body = "tresc maila",
                IsBodyHtml = true

            };

            //wyslanie email
            smtpClient.Send(mailMessage);
        }

        //Get
        public ActionResult UploadFile()
        {
            return View();
        }

        //Post
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase photo)
        {
            //sprawdzammy czy wczytany plik nie jest pusty
            if (photo != null)
            {
                if (_fileBusinessLogic.CheckFileNameCorrectLength(Path.GetFileName(photo.FileName)))
                {
                    ViewBag.Dane = "Nazwa to " + Path.GetFileName(photo.FileName) +
                                   "rozmiar to : " + photo.ContentLength + " rozszerzenie : " +
                                   Path.GetExtension(photo.FileName);
                }

                else
                {
                    ViewBag.Dane = "Nazwa pliku nie może przekraczać 20 znaków";
                }



            }
            return View();
        }

    }
}