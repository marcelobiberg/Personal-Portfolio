using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyOwnBirth.Models;
using Microsoft.AspNetCore.Authorization;
using MyOwnBirth.Services;
using static MyOwnBirth.Models.Util;

namespace MyOwnBirth.Controllers
{
    public class HomeController : Controller
    {
        private IEmailSender _emailSender;


        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }



        public IActionResult Site()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendEmail(RootEmailObject emailObject)
        {

            if (ModelState.IsValid)
            {
                _emailSender.SendEmailAsync(emailObject.Email, "Formulario de Contato", emailObject.Message, emailObject.Name, emailObject.Phone).Wait();
            }


            return RedirectToActionPermanent("Site");
        }

    }
}
