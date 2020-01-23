using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category collection)
        {
            try
            {
                db.Categories.Add(collection);
                db.SaveChanges();
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        Category editCategory;

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            editCategory = db.Categories.Where(x => x.ID == id).FirstOrDefault();
            return View(editCategory);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {
                editCategory = db.Categories.Where(x => x.ID == id).FirstOrDefault();
                editCategory.CategoryName = collection.CategoryName;
                editCategory.Description = collection.Description;
                db.SaveChanges();

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category/Delete/5
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
