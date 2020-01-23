using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Order
        public ActionResult Index()
        {
            var orderList = db.Orders.Where(x => x.IsConfirmed == false).ToList();
            return View(orderList);
        }

        public ActionResult Index2()
        {
            var orderList = db.Orders.Where(x => x.IsConfirmed == true).ToList();
            return View(orderList);
        }
        // GET: Admin/Order/Details/5
        public ActionResult Details(int id)
        {
            var order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            return View(order);
        }
        [HttpPost]
        public ActionResult Details(int id, Order order)
        {
            var orderId = db.Orders.Where(x => x.ID == id).FirstOrDefault();

            orderId.IsConfirmed = order.IsConfirmed;
            db.SaveChanges();

            return RedirectToAction("index");
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int id)
        {
            var order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            return View(order);
        }

        // POST: Admin/Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int id)
        {
            ICollection<OrderDetail> orderDetail = db.Orders.Where(x => x.ID == id).FirstOrDefault().OrderDetails;
            db.OrderDetails.RemoveRange(orderDetail);
            db.Orders.Remove(db.Orders.Where(x => x.ID == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("index");
        }

        // POST: Admin/Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
