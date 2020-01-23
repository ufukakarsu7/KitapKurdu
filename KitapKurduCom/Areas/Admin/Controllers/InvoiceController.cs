using KitapKurdu.UI.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class InvoiceController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Invoice
        public ActionResult Index()
        {
            return View(db.Invoices.ToList());
        }

        // GET: Admin/Invoice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Invoice/Create
        public ActionResult Create()
        {
            List<SelectListItem> customerList = (from c in db.Customers.ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Value = c.ID.ToString(),
                                                     Text = c.FirstName + " " + c.LastName
                                                 }).ToList();
            ViewBag.customerList = customerList;
            return View();
        }

        // POST: Admin/Invoice/Create
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

        // GET: Admin/Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Invoice/Edit/5
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

        // GET: Admin/Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Invoice/Delete/5
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
