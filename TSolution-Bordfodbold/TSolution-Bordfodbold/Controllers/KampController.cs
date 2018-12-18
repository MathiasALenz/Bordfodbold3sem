using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TSolution_Bordfodbold.Abstract;
using TSolution_Bordfodbold.Entities;
using TSolution_Bordfodbold.Models;
using System.Linq;

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
            Kamp kamp = new Kamp();

            kamp.Hold1_Maal = viewModel.Hold1_Maal;
            kamp.Hold2_Maal = viewModel.Hold2_Maal;
            kamp.Spiller1 = viewModel.SpillerNr1;
            kamp.Spiller2 = viewModel.SpillerNr2;
            kamp.Spiller3 = viewModel.SpillerNr3;
            kamp.Spiller4 = viewModel.SpillerNr4;
                kamp.DatoTid = DateTime.Now;
            


            return View(kamp);
        }
        [HttpPost]
        public ActionResult AfslutKamp(Kamp kamp)
        {
            Spiller spiller1 = repository.Spillere.FirstOrDefault(n => n.Navn == kamp.Spiller1);
            spiller1.Indkasserede_Maal += kamp.Hold2_Maal;
            spiller1.Scorede_Maal += kamp.Hold1_Maal;

            Spiller spiller2 = repository.Spillere.FirstOrDefault(n => n.Navn == kamp.Spiller2);
            spiller2.Indkasserede_Maal += kamp.Hold2_Maal;
            spiller2.Scorede_Maal += kamp.Hold1_Maal;

            Spiller spiller3 = repository.Spillere.FirstOrDefault(n => n.Navn == kamp.Spiller3);
            spiller3.Indkasserede_Maal += kamp.Hold1_Maal;
            spiller3.Scorede_Maal += kamp.Hold2_Maal;

            Spiller spiller4 = repository.Spillere.FirstOrDefault(n => n.Navn == kamp.Spiller4);
            spiller4.Indkasserede_Maal += kamp.Hold1_Maal;
            spiller4.Scorede_Maal += kamp.Hold2_Maal;

            if(kamp.Hold2_Maal > kamp.Hold1_Maal)
            {
                spiller1.Tabte++;
                spiller1.WS = 0;

                spiller2.Tabte++;
                spiller2.WS = 0;

                spiller3.Vundne++;
                spiller3.WS++;

                spiller4.Vundne++;
                spiller4.WS++;
            }

            else if (kamp.Hold1_Maal > kamp.Hold2_Maal)
            {
                spiller1.Vundne++;
                spiller1.WS++;

                spiller2.Vundne++;
                spiller2.WS++;

                spiller3.Tabte++;
                spiller3.WS = 0;

                spiller4.Tabte++;
                spiller4.WS = 0;
            }

            else
            {
                spiller1.Uafgjorte++;
                spiller1.WS = 0;

                spiller2.Uafgjorte++;
                spiller2.WS = 0;

                spiller3.Uafgjorte++;
                spiller3.WS = 0;

                spiller4.Uafgjorte++;
                spiller4.WS = 0;
            }

            repository.GemSpiller(spiller1);
            repository.GemSpiller(spiller2);
            repository.GemSpiller(spiller3);
            repository.GemSpiller(spiller4);
            repository.GemKamp(kamp);

            return RedirectToAction("Index", "Home");
        }
    }
}