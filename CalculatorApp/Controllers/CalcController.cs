using CalculatorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculatorApp.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(Calculator calc)
        {
            if(ModelState.IsValid)
            {
                calc.Result = calc.Answer();
                return RedirectToAction("Confirm", calc);
            }
            else
            {
                return View(calc);
            }
        }

        public ActionResult Confirm(Calculator calc)
        {
            return View(calc);
        }


    }
}