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
    public class BrandController : Controller
    {
        // GET: admin/Brand
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
        // GET: admin/Category

        public ActionResult Index()
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var listBrand = objWebKinhDoanhPhuKienEntities.Brands.ToList();
                return View(listBrand);
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {

            var ojbbrands = objWebKinhDoanhPhuKienEntities.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(ojbbrands);
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
        public ActionResult Create(Brand objBrand)
        {
            try
            {
                if (objBrand.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                    string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objBrand.Avatar = fileName;
                    objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objWebKinhDoanhPhuKienEntities.Brands.Add(objBrand);
                objWebKinhDoanhPhuKienEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteBrand = objWebKinhDoanhPhuKienEntities.Brands.Where(n => n.Id == id).FirstOrDefault();

            return View(deleteBrand);
        }
        [HttpPost]
        public ActionResult Delete(Brand objCategory)
        {
            var objCategorys = objWebKinhDoanhPhuKienEntities.Categories.Where(n => n.Id == objCategory.Id).FirstOrDefault();
            objWebKinhDoanhPhuKienEntities.Categories.Remove(objCategorys);
            objWebKinhDoanhPhuKienEntities.SaveChanges();
            return View(objCategorys);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = objWebKinhDoanhPhuKienEntities.Brands.Where(n => n.Id == id).FirstOrDefault();

            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(int id, Brand objBrand)
        {
            if (objBrand.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objBrand.Avatar = fileName;
                objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebKinhDoanhPhuKienEntities.Entry(objBrand).State = (System.Data.Entity.EntityState)EntityState.Modified;
            objWebKinhDoanhPhuKienEntities.SaveChanges();
            return View(objBrand);
        }
    }
}