using BLL;
using Entity.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2cYazilimStok.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                bool sonuc = Helper.Login(login);

                if (sonuc == true)
                {
                    Session["User"] = "admin";
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    Session["User"] = "unauthorize";
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Remove("User");
            return RedirectToAction("Login", "Account");
        }
    }
}