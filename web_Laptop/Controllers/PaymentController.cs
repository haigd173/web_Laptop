using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;
using web_Laptop.Models;

namespace web_Laptop.Controllers
{
    public class PaymentController : Controller
    {
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if(Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var listCart = (List<CartModel>)Session["cart"];
                Order objOrder = new Order();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("yyyyMMddhhmmss");
                objOrder.Id = int.Parse(Session["idUser"].ToString());
                objOrder.CreateOnUtc = DateTime.Now;
                objOrder.Status = 1;


                objWebKinhDoanhPhuKienEntities.Orders.Add(objOrder);
                objWebKinhDoanhPhuKienEntities.SaveChanges();

                int OrderId = objOrder.Id;

                List<OrderDetail> listOrderDetail = new List<OrderDetail>();

                foreach(var item in listCart)
                {
                    OrderDetail objOrderDetail = new OrderDetail();
                    objOrderDetail.Quantity = item.Quantity;
                    objOrderDetail.OrderId = OrderId;
                    objOrderDetail.ProductId = item.Product.Id;
                    listOrderDetail.Add(objOrderDetail);
                }
                objWebKinhDoanhPhuKienEntities.OrderDetails.AddRange(listOrderDetail);
                objWebKinhDoanhPhuKienEntities.SaveChanges();
            }
            return View();
        }
    }
}