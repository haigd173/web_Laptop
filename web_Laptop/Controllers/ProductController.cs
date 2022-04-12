using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;

namespace web_Laptop.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProDuct
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
        public ActionResult Index(string SearchString)
        {
            var objProduct = objWebKinhDoanhPhuKienEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            return View(objProduct);
        }
        public ActionResult Detail(int Id)
        {
            var objProduct = objWebKinhDoanhPhuKienEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}