using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using KitapKurdu.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurdu.UI.Controllers
{
    public class AccountController : Controller
    {

        DatabaseContext db = new DatabaseContext();
        // GET: Account
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
                    Session["kullanici"] = user.ID;
                    //giriş yapılacak
                    return RedirectToAction("Index", "Index");
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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                
                if (db.SaveChanges() == 1)
                {
                    ShoppingCart shoppingCart = new ShoppingCart();
                    shoppingCart.ID = customer.ID;
                    shoppingCart.IsConfirmed = false;
                    db.ShoppingCarts.Add(shoppingCart);
                    db.SaveChanges();
                    return RedirectToAction("Index","Account");
                }
               
            }
            return View();
        }
    }
}