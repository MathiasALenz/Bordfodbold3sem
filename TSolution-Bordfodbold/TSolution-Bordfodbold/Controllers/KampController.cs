using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSolution_Bordfodbold.Abstract;
using TSolution_Bordfodbold.Concrete;
using TSolution_Bordfodbold.Entities;
using TSolution_Bordfodbold.Models;

namespace TSolution_Bordfodbold.Controllers
{
    public class KampController : Controller
    {
        IRepository repository;

        public KampController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Kamp
        public ActionResult Kamp()
        {
            KampViewModel viewModel = new KampViewModel();
            viewModel.Spillere = repository.Spillere;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Resultat(KampViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}