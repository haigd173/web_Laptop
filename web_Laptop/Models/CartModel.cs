using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_Laptop.Context;


namespace web_Laptop.Models
{
    public class CartModel
    {
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();

   
        public Product Product { get; set; }
        
        public int Quantity { get; set; }
        ////public int Id { get; set; }
        ////public double dDonGia { get; set; }
        ////public string Name { get; set; }
        ////public string Avatar { get; set; }
        ////public double Total
        ////{
        ////    get { return Quantity * dDonGia; } 
        ////}
        //////Hàm tạo cho giỏ hàng
        ////public CartModel (int id)
        ////{
        ////    Id = id;
        ////    Product sp = objWebKinhDoanhPhuKienEntities.Products.Single(n => n.Id == id);
        ////    Name = sp.Name;
        ////    Avatar = sp.Avatar;
        ////    dDonGia = double.Parse(sp.Price.ToString());
        ////    Quantity = 1;
        ////}
    }
}