using _2cYazilimStok.Components;
using BLL;
using BLL.Identity;
using DAL.Context;
using Entity.Entity;
using Entity.Entity.ViewModel;
using Entity.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2cYazilimStok.Controllers
{
    [SessionAuthorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> data = Helper.GetProducts();
            return View(data);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            ViewBag.Trademark = Helper.GetTrademark();
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductViewModel product)
        {
            ViewBag.Trademark = Helper.GetTrademark();
            if (ModelState.IsValid)
            {
               bool sonuc = Helper.InsertProducts(product);
                if (sonuc == true)
                {
                    ViewBag.Success = "Ürün Başarıyla Eklendi";
                    ModelState.Clear();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = Helper.Delete(id);
           
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            Helper.DeleteOn(product.Id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Update(ProductViewModel productViewModel)
        {
            ViewBag.Trademark = Helper.GetTrademark();
            var data = Helper.Update(productViewModel);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(ProductViewModel productViewModel,FormCollection formCollection)
        {
            ViewBag.Trademark = Helper.GetTrademark();
            if (ModelState.IsValid) 
            {
                bool sonuc = Helper.UpdateOn(productViewModel);
                if (sonuc == true)
                {
                    ViewBag.Success = "Ürün Başarıyla Güncellendi";
                    ModelState.Clear();
                }
            }
            else 
            {
                return View();
            }
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Details(Product product)
        {
            ViewBag.Trademark = Helper.GetTrademark();
            var data = Helper.Details(product);
            return View(data);
        }
    }
}