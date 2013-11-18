using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HYSM.Models;

namespace HYSM.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(MessageModel model)
        {
            if (string.IsNullOrEmpty(model.From))
            {
                ModelState.AddModelError("From", "The From field is required.");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "The Email field is required.");
            }

            if (string.IsNullOrEmpty(model.Message))
            {
                ModelState.AddModelError("Message", "The Message field is required.");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("ThankYou");
            }

            ModelState.AddModelError("", "One or more errors were found");
            return View(model);
        }

        public PartialViewResult ThankYou()
        {
            return PartialView();
        }

    }
}
