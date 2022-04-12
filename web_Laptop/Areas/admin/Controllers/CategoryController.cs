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

    public class CategoryController : Controller
    {
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
        // GET: admin/Category
        public ActionResult Index()
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var listCategory = objWebKinhDoanhPhuKienEntities.Categories.ToList();
            return View(listCategory);
        }
             else
            {
                return Redirect("~/Home/Login");
            }
        }
        public ActionResult Detail(int id)
        {
            var ojbCategory = objWebKinhDoanhPhuKienEntities.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(ojbCategory);
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
        public ActionResult Create(Category objCategory)
        {
            try
            {
                if (objCategory.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                    string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objCategory.Avartar = fileName;
                    objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objWebKinhDoanhPhuKienEntities.Categories.Add(objCategory);
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
            var deletecategory = objWebKinhDoanhPhuKienEntities.Categories.Where(n => n.Id == id).FirstOrDefault();

            return View(deletecategory);
        }
        [HttpPost]
        public ActionResult Delete(Category objCategory)
        {
            var objCategorys = objWebKinhDoanhPhuKienEntities.Categories.Where(n => n.Id == objCategory.Id).FirstOrDefault();
            objWebKinhDoanhPhuKienEntities.Categories.Remove(objCategorys);
            objWebKinhDoanhPhuKienEntities.SaveChanges();
            return View(objCategorys);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCategorys = objWebKinhDoanhPhuKienEntities.Categories.Where(n => n.Id == id).FirstOrDefault();

            return View(objCategorys);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category objCategorys)
        {
            if (objCategorys.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objCategorys.ImageUpload.FileName);
                string extension = Path.GetExtension(objCategorys.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objCategorys.Avartar = fileName;
                objCategorys.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebKinhDoanhPhuKienEntities.Entry(objCategorys).State = (System.Data.Entity.EntityState)EntityState.Modified;
            objWebKinhDoanhPhuKienEntities.SaveChanges();
            return View(objCategorys);
        }
    }
}