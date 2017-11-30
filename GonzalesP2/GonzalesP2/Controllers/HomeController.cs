using GonzalesP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GonzalesP2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()

        {
            InvestmentCalc inv = new InvestmentCalc();
            return View(inv);
        }


        //POST: Summary
        [HttpPost]
        public ActionResult Summary(InvestmentCalc inv)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Info = "";
                return View(inv);
            }
            else
            {
                ViewBag.Info = "Input is not valid";
                
            }
            return View("Val");

        }
    }
}