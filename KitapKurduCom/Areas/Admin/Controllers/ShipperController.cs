using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class ShipperController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Shipper
        public ActionResult Index()
        {

            return View(db.Shippers.ToList());
        }

        // GET: Admin/Shipper/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Shipper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Shipper/Create
        [HttpPost]
        public ActionResult Create(Shipper collection)
        {
            try
            {
                db.Shippers.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        Shipper editShipper;
        // GET: Admin/Shipper/Edit/5
        public ActionResult Edit(int id)
        {
            editShipper = db.Shippers.Find(id);
            return View(editShipper);
        }

        // POST: Admin/Shipper/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Shipper collection)
        {
            try
            {
                editShipper = db.Shippers.Where(x => x.ID == id).FirstOrDefault();
                editShipper.Address = collection.Address;
                editShipper.CompanyName = collection.CompanyName;
                editShipper.Email = collection.Email;
                editShipper.Orders = collection.Orders;
                editShipper.Phone = collection.Phone;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Admin/Shipper/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Shipper/Delete/5
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
