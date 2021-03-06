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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Nhập Email")]
        [StringLength(100, ErrorMessage = "Email tối thiểu 6 ký tự", MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; }
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])).{8,}$",
        ErrorMessage = "Mật khẩu tổi thiếu 8 ký tự bao gồm: chữ thường, chừ hoa, và chữ số")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DisplayName("Mật khẩu xác nhận")]
        [Required(ErrorMessage = "Nhập Mật khẩu xác nhận")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không trùng nhau")]
        public string ConfirmPassword { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    }
}
