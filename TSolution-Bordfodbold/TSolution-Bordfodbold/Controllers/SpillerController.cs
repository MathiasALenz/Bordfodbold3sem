using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSolution_Bordfodbold.Abstract;
using TSolution_Bordfodbold.Concrete;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Controllers
{
    public class SpillerController : Controller
    {
        IRepository repository;

        public SpillerController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Spillere()
        {
            List<Spiller> spillerList = new List<Spiller>();

            foreach(Spiller spiller in repository.Spillere)
                spillerList.Add(spiller);

            return View(spillerList);
        }

        public ActionResult Opret()
        {
            return View("Rediger", new Spiller());
        }

        public ActionResult Slet(int spillerID)
        {
            repository.SletSpiller(spillerID);

            return RedirectToAction("Spillere");
        }
    }
}