using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;
using web_Laptop.Models;
using System.Text;


namespace web_Laptop.Controllers
{
    public class HomeController : Controller
    {
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
        public ActionResult Index()
        {
            HomeModel ojbHomeModel = new HomeModel();
            ojbHomeModel.ListCategory = objWebKinhDoanhPhuKienEntities.Categories.ToList();
            ojbHomeModel.ListProduct = objWebKinhDoanhPhuKienEntities.Products.ToList();
            return View(ojbHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //GET: đăng kí
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                string fail = "";
                var check = objWebKinhDoanhPhuKienEntities.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    fail = "email đã được sử dụng";
                    _user.Password = GetMD5(_user.Password);
                    objWebKinhDoanhPhuKienEntities.Configuration.ValidateOnSaveEnabled = false;
                    objWebKinhDoanhPhuKienEntities.Users.Add(_user);
                    objWebKinhDoanhPhuKienEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }
        // mã hóa
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = objWebKinhDoanhPhuKienEntities.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FistName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().Id;
                    Session["IsAdmin"] = data.FirstOrDefault().IsAdmin;
                    return RedirectToAction("Index");
                }

                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }  
}