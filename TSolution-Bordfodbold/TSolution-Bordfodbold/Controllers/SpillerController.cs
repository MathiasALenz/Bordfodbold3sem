using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSolution_Bordfodbold.Abstract;
using TSolution_Bordfodbold.Concrete;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Controllers {
  public class SpillerController : Controller {
    IRepository repository;
    IAuthProvider provider;
    public SpillerController(IRepository repository, IAuthProvider provider) {
      this.repository = repository;
      this.provider = provider;
    }

    public ViewResult Spillere() {
      List<Spiller> spillerList = new List<Spiller>();

      foreach (Spiller spiller in repository.Spillere)
        spillerList.Add(spiller);

      return View(spillerList);
    }

    [Authorize]
    public ActionResult Opret() {
      return View("Rediger", new Spiller());
    }

    [Authorize]
    public ViewResult Rediger(int spiller_ID) {
      Spiller spiller = repository.Spillere.FirstOrDefault(s => s.Spiller_ID == spiller_ID);
      return View(spiller);
    }

    [HttpPost, Authorize]
    public ActionResult Rediger(Spiller spiller) {
      if (ModelState.IsValid) {
        repository.GemSpiller(spiller);
        return RedirectToAction("spillere");
      }
      else
        return View(spiller);
    }


    [Authorize]
    public ActionResult Slet(int Spiller_ID) {
      repository.SletSpiller(Spiller_ID);

      return RedirectToAction("Spillere");
    }

    public ViewResult Login() {
      return View();
    }

    [HttpPost]
    public ActionResult Login(Spiller spiller, string returnUrl) {
      if (ModelState.IsValid) {
        if (provider.Authenticate(spiller.Brugernavn, spiller.Kodeord)) 
          return Redirect(returnUrl ?? Url.Action("Spillere", "Spiller"));
        else {
          ModelState.AddModelError("", "Forkert brugernavn eller kodeord");
          return View();
        }
      }
      else 
        return View();
    }
  }
}