using AzureStorageCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureStorageCalc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(AzureStorage storage)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", storage);
            }
            else
            {
                return View(storage);
            }
        }

        public ActionResult Confirm(AzureStorage storage)
        {
            return View(storage);
        }
    }
}