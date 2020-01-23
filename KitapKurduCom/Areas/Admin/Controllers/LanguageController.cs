using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class LanguageController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Language
        public ActionResult Index()
        {

            return View(db.Languages.ToList());
        }

        // GET: Admin/Language/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Language/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Language/Create
        [HttpPost]
        public ActionResult Create(Language collection)
        {
            try
            {
                db.Languages.Add(collection);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        Language editLanguage;
        // GET: Admin/Language/Edit/5
        public ActionResult Edit(int id)
        {
            editLanguage = db.Languages.Where(x => x.ID == id).FirstOrDefault();
            return View(editLanguage);
        }

        // POST: Admin/Language/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Language collection)
        {
            try
            {
                editLanguage = db.Languages.Where(x => x.ID == id).FirstOrDefault();
                editLanguage.LanguageName = collection.LanguageName;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Language/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Language/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Language collection)
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
