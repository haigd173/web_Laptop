using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;


namespace web_Laptop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
        public ActionResult Index()
        {
            var lstBrand = objWebKinhDoanhPhuKienEntities.Brands.ToList();
            return View(lstBrand);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objWebKinhDoanhPhuKienEntities.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }
    }
}