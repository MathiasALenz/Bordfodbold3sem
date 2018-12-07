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
    public class HomeController : Controller
    {
       // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    }
}