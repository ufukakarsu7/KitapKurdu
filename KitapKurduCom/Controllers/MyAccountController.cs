using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using KitapKurdu.UI.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurdu.UI.Controllers
{
    public class MyAccountController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: MyAccount
        public ActionResult Index()
        {
            return View();
        }
        Customer userInfo;
        // ÜYE BİLGİLERİ
        public ActionResult UserInfo(int id)
        {
            userInfo = db.Customers.Find(id);
            Customer userId = userInfo;
            if (Session["kullanici"] != null)
            {
                if (userId != null)
                {
                    if ((int)Session["kullanici"] == userId.ID)
                    {
                        return View(userId);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "MyAccount");
                }

            }
            else
            {
                return RedirectToAction("Index", "Account");

            }



        }
        [HttpPost]
        public ActionResult UserInfo(int id, Customer customer)
        {
            try
            {
                if (Session["kullanici"] == null)
                {
                    return RedirectToAction("Index", "Account");
                }
                userInfo = db.Customers.Where(x => x.ID == id).FirstOrDefault();
                userInfo.FirstName = customer.FirstName;
                userInfo.LastName = customer.LastName;
                userInfo.Email = customer.Email;
                userInfo.ConfirmPassword = userInfo.Password;
                userInfo.Phone = customer.Phone;
                userInfo.BirthDate = customer.BirthDate;
                db.SaveChanges();

                // TODO: Add update logic here

                return RedirectToAction("Index", "MyAccount");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(int id, Customer customer)
        {
            try
            {
                if (Session["kullanici"] == null)
                {
                    return RedirectToAction("Index", "Account");
                }
                userInfo = db.Customers.Where(x => x.ID == id).FirstOrDefault();
                userInfo.Password = customer.Password;
                userInfo.ConfirmPassword = customer.ConfirmPassword;
                db.SaveChanges();

                // TODO: Add update logic here

                return RedirectToAction("Index", "MyAccount");
            }
            catch
            {
                return View();
            }
        }
        // SEPETİM
        public ActionResult ShoppingCart()
        {
            return View();
        }

        // ADRESLERİM
        [HttpGet]
        public ActionResult Addresses(int id)
        {
            if (Session["kullanici"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            List<Address> userAddresses = db.Addresses.Where(x => x.Customer.ID == id).ToList();
            return View(userAddresses);
        }
        [HttpPost]
        public ActionResult Addresses(int id, Customer customer)
        {
            try
            {
                if (Session["kullanici"] == null)
                {
                    return RedirectToAction("Index", "Account");
                }
                var userAddresses = db.Customers.Where(x => x.ID == id).ToList();
                userInfo.Addresses = customer.Addresses;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        Address _address;
        public ActionResult Edit(int id)
        {
            _address = db.Addresses.Find(id);
            return View(_address);
        }

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            _address = db.Addresses.Where(x => x.ID == address.ID).FirstOrDefault();
            _address.Title = address.Title;
            _address.Description = address.Description;
            _address.District = address.District;
            _address.City = address.City;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CreateAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAddress(Address address)
        {

            return RedirectToAction("Index","");
        }

        public ActionResult Delete(int id)
        {
            int _id = (int)Session["kullanici"];
            db.Addresses.Remove(db.Addresses.Find(id));
            db.SaveChanges();
            return RedirectToAction("Addresses", "MyAccount", new { id = _id });
        }
        // SİPARİŞLER
        public ActionResult Orders(int page = 1)
        {
            if (Session["kullanici"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int pageSize = 10;
            var siparisler = db.Orders.Where(x => x.CustomerID == 1).ToList().ToPagedList(page, pageSize);
            return View(siparisler);
        }

        // İNDİRİM ÇEKLERİ
        public ActionResult Coupons()
        {
            return View();
        }

        // TUKETİCİ HAKLARI
        public ActionResult ConsumerRights()
        {
            return View();
        }

        // SATIŞ SÖZLEŞMESİ
        public ActionResult SalesAgreement()
        {
            return View();
        }
        // GÜVENLİK İLKELERİ
        public ActionResult Security()
        {
            return View();
        }

        // OTURUMU KAPAT
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Index");
        }
    }
}
