using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;
using web_Laptop.Models;

namespace web_Laptop.Controllers
{
    public class CartController : Controller
    {
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();

        // GET: Cart
        public ActionResult Index()
        {
            return View((List<CartModel>)Session["cart"]);
        }
        public ActionResult AddToCart(int id, int quantity)
        {
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { Product = objWebKinhDoanhPhuKienEntities.Products.Find(id), Quantity = quantity });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].Quantity += quantity;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new CartModel { Product = objWebKinhDoanhPhuKienEntities.Products.Find(id), Quantity = quantity });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        private int isExist(int id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }

        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(int Id)
        {
            List<CartModel> li = (List<CartModel>)Session["cart"];
            li.RemoveAll(x => x.Product.Id == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        //private int allQuantity()
        //{
        //    int iTongSoLuong = 0;
        //    List<CartModel> lstGioHang = Session["Cart"] as List<CartModel>;
        //    if (lstGioHang != null)
        //    {
        //        iTongSoLuong = lstGioHang.Sum(n => n.Quantity);
        //    }
        //    return iTongSoLuong;
        //}
        ////Tính tổng thành tiền
        //private double TongTien()
        //{
        //    double dTongTien = 0;
        //    List<CartModel> lstGioHang = Session["GioHang"] as List<CartModel>;
        //    if (lstGioHang != null)
        //    {
        //        dTongTien = lstGioHang.Sum(n => n.Total);
        //    }
        //    return dTongTien;
        //} 
        ////tạo partial giỏ hàng

    }
}