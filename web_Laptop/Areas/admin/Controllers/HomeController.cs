using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;

namespace web_Laptop.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: admin/Home
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
      
        [AllowAnonymous]
        public ActionResult Index()
        {
            if(Session["idUser"]!= null && Session["IsAdmin"] != null)
            {
                var lstProdutc = objWebKinhDoanhPhuKienEntities.Products.ToList();
                return View(lstProdutc);
            }
            else
            {
                return Redirect("~/Home/Login");

            }

        }
   
    }
}