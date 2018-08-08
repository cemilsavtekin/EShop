using EShop.Business.Manage;
using EShop.Entities.Concrete;
using EShop.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Web.UI.Controllers
{
    
    //[Authorize(Roles ="Admin,User")]
    [AllowAnonymous]
    public class ProductController : Controller
    {
       static List<Resim> UploadedImages = new List<Resim>();

        public JsonResult ImageLoad(FileImageModel model)
        {
            var file = model.ImageFile;

            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                file.SaveAs(Server.MapPath("/Images/Uploaded/" + file.FileName));

                UploadedImages.Add(new Resim
                {
                    ImagePath = file.FileName,
                    ImageType=1/*Ürün resmi*/
                });

            }
            return Json(file.FileName,JsonRequestBehavior.AllowGet);
        }


        // GET: Product
        public ActionResult Index()
        {

            var products = DBManager<Product>.GetAll();
            ViewBag.Images = DBManager<Resim>.GetAll();


            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            //SiparisVİewModel model = (from pr in DBManager<Product>.GetAll()
            //                          join sip in DBManager<Order>.GetAll() on pr.ProductID equals sip.OrderID
            //                          select new SiparisVİewModel
            //                          {
            //                              MyProperty = pr.ProductID
            //                          }).FirstOrDefault();


            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = DBManager<Category>.GetAll(x => x.UstKategoriID == null);

            return View();
        }


        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (UploadedImages.Count > 0 || UploadedImages != null)
                    {
                        product.Images = UploadedImages;
                    }
                    DBManager<Product>.Add(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }




        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
