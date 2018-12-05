using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSolution_Bordfodbold.Concrete;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Controllers
{
    public class HomeController : Controller
    {
        EFRepository repository = new EFRepository();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Spiller cunt)
        {
            Spiller spiller = new Spiller
            {
                Navn = "Hans Arne",
                Scorede_Maal = 1,
                Indkasserede_Maal = 10,
                Vundne = 7,
                Tabte = 2,
                Uafgjorte = 900,
                WS = 8,
                Administrator = 1
            };

            repository.GemSpiller(spiller);
            return View();
        }
    }
}