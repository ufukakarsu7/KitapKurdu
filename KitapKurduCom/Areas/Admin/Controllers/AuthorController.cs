using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Admin/Author
        public ActionResult Index(int page=1,int pageSize=10)
        {
            //var authorList = db.Authors.ToList();
            var authorList = db.Authors.ToList().ToPagedList(page, pageSize);
            return View(authorList);
        }


        // GET: Admin/Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Author/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Author/Edit/5
        public ActionResult Edit(int id)
        {
            var editAuthor = db.Authors.Where(x => x.ID == id).SingleOrDefault();
            return View(editAuthor);
        }

        // POST: Admin/Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Author author)
        {
            var updateAuthor = db.Authors.Where(x => x.ID == id).SingleOrDefault();

            try
            {
                updateAuthor.Title = author.Title;
                updateAuthor.FirstName = author.FirstName;
                updateAuthor.LastName = author.LastName;

                db.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Author/Delete/5
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
