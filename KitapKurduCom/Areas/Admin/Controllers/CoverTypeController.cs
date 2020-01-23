using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/CoverType
        public ActionResult Index()
        {
            return View(db.CoverTypes.ToList());
        }

        // GET: Admin/CoverType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CoverType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CoverType/Create
        [HttpPost]
        public ActionResult Create(CoverType collection)
        {
            try
            {
                db.CoverTypes.Add(collection);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            
catch
            {
                return View();
            }
        }
        CoverType editCoverType;
        // GET: Admin/CoverType/Edit/5
        public ActionResult Edit(int id)
        {
            editCoverType = db.CoverTypes.Where(x => x.ID == id).FirstOrDefault();
            return View(editCoverType);
        }

        // POST: Admin/CoverType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CoverType collection)
        {
            try
            {
                editCoverType = db.CoverTypes.Where(x => x.ID == id).FirstOrDefault();
                editCoverType.CoverTypeName = collection.CoverTypeName;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CoverType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CoverType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CoverType collection)
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
