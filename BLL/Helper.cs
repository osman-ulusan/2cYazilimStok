using BLL.Identity;
using BLL.Repository;
using DAL.Context;
using Entity.Entity;
using Entity.Entity.ViewModel;
using Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public  class Helper
    {
        /// <summary>
        /// Bütün ürünlerin listesini getiren method && Stored Prodecure
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetProducts()
        {
            Context2c Veri = new Context2c();
            var data = Veri.Database.SqlQuery<Product>("SpSelect").ToList();
            return data;
        }

        /// <summary>
        /// Markaları getiren method
        /// </summary>
        /// <returns></returns>
        public static List<Trademark> GetTrademark()
        {

            UnitOfWork trademark = new UnitOfWork();

            var data = trademark.TrademarkRepository.Select().ToList();

            return data;

        }

        public static bool Login(LoginViewModel loginvm) 
        {

            var usermanager = IdentityTools.NewUserManager();

            ApplicationUser kullanici = usermanager.FindByName(loginvm.UserName);
            if (kullanici == null)
            {
                return false;
            }
            else if (!usermanager.CheckPassword(kullanici, loginvm.Password))
            {
                return false;
            }
            return true;
        }
       

        public static Product Delete(int id)
        {
            UnitOfWork deleteProduct = new UnitOfWork();
            Product product = deleteProduct.ProductRepository.FindById(id);
            return product;
        }

        public static void DeleteOn(int id)
        {
            UnitOfWork deleteProduct = new UnitOfWork();
            deleteProduct.ProductRepository.Delete(id);
            deleteProduct.Save();
        }


        public static Product Details(Product product)
        {
            UnitOfWork detailsProduct = new UnitOfWork();
            var produck = detailsProduct.ProductRepository.FindById(product.Id);
            return produck;
        }


        public static ProductViewModel Update(ProductViewModel productvm)
        {
            UnitOfWork updateProduct = new UnitOfWork();
            var product = updateProduct.ProductRepository.FindById(productvm.Id);

            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.Name = product.Name;
            productViewModel.Description = product.Description;
            productViewModel.CreateDate = product.CreateDate;
            productViewModel.Amount = product.Amount;
            productViewModel.Trademark = product.Trademark;
            productViewModel.PictureUpload = null;


            return productViewModel;
        }
        public static bool UpdateOn(ProductViewModel productvm)
        {
            UnitOfWork updateProduct = new UnitOfWork();

            string imagePath = "";
            string file = "";

            if (productvm.PictureUpload[0] != null && productvm.PictureUpload.Count() > 0)
            {
                string filename = productvm.PictureUpload[0].FileName;
                imagePath = HttpContext.Current.Server.MapPath("../../Images/") + Path.GetFileName(filename);
                file = "Images/" + Path.GetFileName(filename);
                productvm.PictureUpload[0].SaveAs(imagePath);
            }
            else
            {
                file = "Images/no-image.png";
            }

            Product product1 = new Product();

            product1.Id = productvm.Id;
            product1.Name = productvm.Name;
            product1.Description = productvm.Description;
            product1.CreateDate = productvm.CreateDate;
            product1.Amount = productvm.Amount;
            product1.Trademark = productvm.Trademark;
            product1.ImagePath = file;

            updateProduct.ProductRepository.Update(product1);
            updateProduct.Save();
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool InsertProducts(ProductViewModel productvm)
        {
            string imagePath = "";
            string file = "";

            if (productvm.PictureUpload[0] != null && productvm.PictureUpload.Count() > 0)
            {
                string filename = productvm.PictureUpload[0].FileName;
                imagePath = HttpContext.Current.Server.MapPath("../Images/") + Path.GetFileName(filename);
                file = "Images/" + Path.GetFileName(filename);
                productvm.PictureUpload[0].SaveAs(imagePath);
            }
            else 
            {
                file = "Images/no-image.png";
            }

            Product product = new Product();
            product.Name = productvm.Name;
            product.Description = productvm.Description;
            product.CreateDate = productvm.CreateDate;
            product.Amount = productvm.Amount;
            product.Trademark = productvm.Trademark;
            product.ImagePath = file;


            UnitOfWork worker = new UnitOfWork();
            bool sonuc = worker.ProductRepository.Insert(product);
            worker.Save();
            return sonuc;
        }
    }
}
