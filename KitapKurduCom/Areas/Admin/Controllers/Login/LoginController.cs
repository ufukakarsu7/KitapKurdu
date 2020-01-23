using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using KitapKurdu.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                Customer user = db.Customers.Where(x => x.Email == userLoginViewModel.Email && x.Password == userLoginViewModel.Password).FirstOrDefault();

                if (user != null)
                {
                    Session["kullanici"] = user.Email;
                    //giriş yapılacak
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    //bu durumda model valid ama bilgiler uyuşmuyor
                    //ViewBag.LoginMesaj = "E-posta ve şifre uyuşmuyor";
                    userLoginViewModel.LoginErrorMessage = "E-posta ve şifre uyuşmuyor";
                    return View(userLoginViewModel);
                }
            }
            else
            {
                return View();
            }
        }
    }
}