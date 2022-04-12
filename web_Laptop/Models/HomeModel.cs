using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_Laptop.Context;

namespace web_Laptop.Models
{
    public class HomeModel
    {
        public List<Product> ListProduct { get; set; }

        public List<Category> ListCategory { get; set; }
    }
}