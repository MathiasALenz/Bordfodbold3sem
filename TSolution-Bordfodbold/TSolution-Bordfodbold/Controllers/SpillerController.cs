using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSolution_Bordfodbold.Concrete;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Controllers
{
    public class SpillerController : Controller
    {
        EFDbContext context = new EFDbContext();

        public ActionResult Spillere()
        {
            List<Spiller> spillerList = new List<Spiller>();

            foreach(Spiller spiller in context.Spillere)
                spillerList.Add(spiller);

            return View(spillerList);
        }
    }
}