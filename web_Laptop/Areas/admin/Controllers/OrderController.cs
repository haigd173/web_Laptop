using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;

namespace web_Laptop.Areas.admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: admin/Order
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();

        public ActionResult Index()
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var listOrder = objWebKinhDoanhPhuKienEntities.OrderDetails.ToList();
                return View(listOrder);
            }
            else
            {
                return Redirect("~/Home/Login");

            }
        }
    }
}