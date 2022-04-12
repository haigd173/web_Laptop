using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;

namespace web_Laptop.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
        // GET: admin/Product
        public ActionResult Index()
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var listProduct = objWebKinhDoanhPhuKienEntities.Products.ToList();
                return View(listProduct);
            }
            else
            {
                return Redirect("~/Home/Login");

            }
        }

        public ActionResult Detail(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }
        [HttpPost]
        public ActionResult Create(Product ojbproduct)
        {
            if (ModelState.IsValid)
            {     
                try
                {
                    if (ojbproduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(ojbproduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(ojbproduct.ImageUpload.FileName);
                        fileName = fileName + extension;
                        ojbproduct.Avatar = fileName;
                        ojbproduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    ojbproduct.CreateOnUtc = DateTime.Now;
                    objWebKinhDoanhPhuKienEntities.Products.Add(ojbproduct);
                    objWebKinhDoanhPhuKienEntities.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch 
                {
                    return View();
                }
            }
            return View(ojbproduct);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ojbProduct = objWebKinhDoanhPhuKienEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(ojbProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ojbProduct = objWebKinhDoanhPhuKienEntities.Products.Where(n => n.Id == id).FirstOrDefault();

            return View(ojbProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objproduct)
        {
            var ojbProduct = objWebKinhDoanhPhuKienEntities.Products.Where(n => n.Id == objproduct.Id).FirstOrDefault();
            objWebKinhDoanhPhuKienEntities.Products.Remove(ojbProduct);
            objWebKinhDoanhPhuKienEntities.SaveChanges();
            return View(ojbProduct);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ojbProduct = objWebKinhDoanhPhuKienEntities.Products.Where(n => n.Id == id).FirstOrDefault();

            return View(ojbProduct);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product ojbproduct)
        {
            if (ojbproduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(ojbproduct.ImageUpload.FileName);
                string extension = Path.GetExtension(ojbproduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                ojbproduct.Avatar = fileName;
                ojbproduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                objWebKinhDoanhPhuKienEntities.SaveChanges();

            }
            objWebKinhDoanhPhuKienEntities.Entry(ojbproduct).State = (System.Data.Entity.EntityState)EntityState.Modified;
            objWebKinhDoanhPhuKienEntities.SaveChanges();
            return View(ojbproduct);
        }
    }
}