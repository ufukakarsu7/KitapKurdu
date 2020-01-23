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
    public class TranslatorController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Translator
        public ActionResult Index()
        {
            return View(db.Translators.ToList());
        }

        // GET: Admin/Translator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Translator/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: Admin/Translator/Create
        [HttpPost]
        public ActionResult Create(Translator translator)
        {
            if (ModelState.IsValid)
            {
                db.Translators.Add(translator);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            else
            {
                return View();
            }
        }

        // GET: Admin/Translator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translator translator = db.Translators.Find(id);
            if (translator == null)
            {
                return HttpNotFound();
            }
            return View(translator);
        }

        // POST: Admin/Translator/Edit/5111
        [HttpPost]
        public ActionResult Edit(int id, Translator translator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(translator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(translator);
        }

        // GET: Admin/Translator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Translator/Delete/5
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
