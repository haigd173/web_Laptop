using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_Laptop.Context;

namespace web_Laptop.Areas.admin.Controllers
{
    public class PhanquyenController : Controller
    {
        WebKinhDoanhPhuKienEntities objWebKinhDoanhPhuKienEntities = new WebKinhDoanhPhuKienEntities();
        // GET: admin/Phanquyen
        public ActionResult Index()
        {
            if (Session["idUser"] != null && Session["IsAdmin"] != null)
            {
                var listUser = objWebKinhDoanhPhuKienEntities.Users.ToList();
                return View(listUser);
            }
            else
            {
                return Redirect("~/Home/Login");

            }
        }
        public ActionResult Delete(User XoaUser)
        {
            var deleteUser = objWebKinhDoanhPhuKienEntities.Users.Where(n => n.Id == XoaUser.Id).FirstOrDefault();
            objWebKinhDoanhPhuKienEntities.Users.Remove(deleteUser);
            objWebKinhDoanhPhuKienEntities.SaveChanges();
            return View(deleteUser);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var capquyen = objWebKinhDoanhPhuKienEntities.Users.Where(n => n.Id == id).FirstOrDefault();

            return View(capquyen);
        }
        [HttpPost]
        public ActionResult Edit(int id, User capquyen)
        {         
            
            objWebKinhDoanhPhuKienEntities.SaveChanges();
            return View(capquyen);
        }

    }
}