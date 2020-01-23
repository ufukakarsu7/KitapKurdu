using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class PublisherController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Publisher
        public ActionResult Index()
        {
            return View(db.Publishers.ToList());
        }

        // GET: Admin/Publisher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Publisher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Publisher/Create
        [HttpPost]
        public ActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            else
            {
                return View();
            }
        }

        // GET: Admin/Publisher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Admin/Publisher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        // GET: Admin/Publisher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Publisher/Delete/5
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
