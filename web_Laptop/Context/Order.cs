//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_Laptop.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateOnUtc { get; set; }
        public string Name { get; set; }
        public string DiaChi { get; set; }
    }
}
