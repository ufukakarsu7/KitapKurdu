using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Controllers
{
    public class OrdersController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Complete()
        {
            if (Session["kullanici"]!=null)
            {
                int kullaniciID = (int)Session["kullanici"];
                ShoppingCart shoppingCart = db.ShoppingCarts.Where(x => x.Customer.ID == kullaniciID).FirstOrDefault();

                Order order = new Order();
                order.Shipper = db.Shippers.Find(3);
                //order.OrderDate = DateTime.Now;
                order.IsConfirmed = false;
                order.OrderDate = DateTime.Now;
                order.DateOfDelivery = null;
                order.DateOfShipping = null;
                order.OrderTime =DateTime.Now.TimeOfDay ;
                order.Customer = db.Customers.Find(kullaniciID);

                db.Orders.Add(order);
                db.SaveChanges();
                OrderDetail orderDetail;

                foreach (var item in shoppingCart.ShoppingCartBook.ToList())
                {
                    orderDetail = new OrderDetail();
                    orderDetail.BookID = item.BookID;
                    orderDetail.Discount = 0;
                    orderDetail.OrderID = order.ID;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.UnitPrice = item.Book.UnitPrice;
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                    db.ShoppingCartBooks.Remove(item);
                    db.SaveChanges();

                }
                

                return RedirectToAction("Index", "Index");
            }
            
            return View();
        }
    }
}