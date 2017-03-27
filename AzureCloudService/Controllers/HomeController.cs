using AzureCloudService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureCloudService.Controllers
{
    public class HomeController : Controller
    {
        // GET : Home/Calculate
        [HttpGet]
        public ActionResult Calculate()
        {
            return View(new AzureCloudServiceCost() { NoInstances = 2 });
        }

        [HttpPost]
        public ActionResult Calculate(AzureCloudServiceCost cost)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Confirm", cost);
            }
            else
            {
                return View(cost);
            }
        }
        
        // Show Confirmation
        
        public ActionResult Confirm(AzureCloudServiceCost c)
        {
            return View(c);
        }
    }
}