using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace KitapKurduCom.Areas.Admin.Controllers
{
    public class BooksController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Book
        public ActionResult Index(int page = 1)
        {
            var books = db.Books.ToList().ToPagedList(page, 25);

            return View(books);
        }


        // GET: Admin/Book/Details/5
        public ActionResult Details(int? id)
        {
            var bookImages = db.BookImages.Where(x => x.BookID == id).ToList();
            ViewBag.bookImages = bookImages;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Admin/Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Title");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName");
            ViewBag.CoverTypeID = new SelectList(db.CoverTypes, "ID", "CoverTypeName");
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "LanguageName");
            ViewBag.PublisherID = new SelectList(db.Publishers, "ID", "PublisherName");
            ViewBag.TranslatorID = new SelectList(db.Translators, "ID", "Title");
            return View();
        }

        // POST: Admin/Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookName,Description,UnitPrice,UnitsInStock,ProductionState,PageNumber,PublishDate,CoverTypeID,CategoryID,PublisherID,AuthorID,TranslatorID,LanguageID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("CreateImage", new { id = (db.Books.OrderByDescending(x => x.ID).Take(1).FirstOrDefault()).ID });
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Title", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", book.CategoryID);
            ViewBag.CoverTypeID = new SelectList(db.CoverTypes, "ID", "CoverTypeName", book.CoverTypeID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "LanguageName", book.LanguageID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "ID", "PublisherName", book.PublisherID);
            ViewBag.TranslatorID = new SelectList(db.Translators, "ID", "Title", book.TranslatorID);
            return View(book);
        }

        [HttpGet]
        public ActionResult CreateImage(int id)
        {
            string bookName = db.Books.Where(x => x.ID == id).FirstOrDefault().BookName;
            ViewBag.bookName = bookName;
            int bookId = db.Books.Where(x => x.ID == id).FirstOrDefault().ID;
            ViewBag.bookId = bookId;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateImage(BookImage bookImage, IEnumerable<HttpPostedFileBase> files)
        {
            BookImage newBookImage = bookImage;

            foreach (var file in files)
            {
                if (files != null)
                {
                    Guid code = Guid.NewGuid();
                    string fileName = code + Path.GetExtension(file.FileName);
                    fileName = fileName.Replace(" ", "-");

                    string fileRoute = Path.Combine(Server.MapPath("~/Uploads/BookImage"), fileName);
                    file.SaveAs(fileRoute);
                    newBookImage.ImageUrl = fileName;
                }
                db.BookImages.Add(newBookImage);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }

        // GET: Admin/Book/Edit/5
        public ActionResult Edit(int? id)
        {
            var bookImages = db.BookImages.Where(x => x.BookID == id).ToList();
            ViewBag.bookImages = bookImages;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            //ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Title", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", book.CategoryID);
            ViewBag.CoverTypeID = new SelectList(db.CoverTypes, "ID", "CoverTypeName", book.CoverTypeID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "LanguageName", book.LanguageID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "ID", "PublisherName", book.PublisherID);
            //ViewBag.TranslatorID = new SelectList(db.Translators, "ID", "FirstName", "LastName",book.TranslatorID);

            List<SelectListItem> TranslatorID = (from t in db.Translators.ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Value = t.ID.ToString(),
                                                     Text = t.FirstName + " " + t.LastName
                                                 }).ToList();

            List<SelectListItem> AuthorID = (from t in db.Authors.ToList()
                                             select new SelectListItem()
                                             {
                                                 Value = t.ID.ToString(),
                                                 Text = t.FirstName + " " + t.LastName
                                             }).ToList();
            ViewBag.AuthorID = AuthorID;
            ViewBag.TranslatorID = TranslatorID;
            return View(book);
        }

        // POST: Admin/Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "ID,BookName,Description,UnitPrice,UnitsInStock,ProductionState,PageNumber,PublishDate,CoverTypeID,CategoryID,PublisherID,AuthorID,TranslatorID,LanguageID")] Book book, HttpPostedFileBase updateFiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateImage", new { id = id });
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "Title", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", book.CategoryID);
            ViewBag.CoverTypeID = new SelectList(db.CoverTypes, "ID", "CoverTypeName", book.CoverTypeID);
            ViewBag.LanguageID = new SelectList(db.Languages, "ID", "LanguageName", book.LanguageID);
            ViewBag.PublisherID = new SelectList(db.Publishers, "ID", "PublisherName", book.PublisherID);
            ViewBag.TranslatorID = new SelectList(db.Translators, "ID", "Title", book.TranslatorID);
            return View(book);
        }

        public ActionResult UpdateImage(int id)
        {
            var idGet = db.Books.Where(x => x.ID == id).FirstOrDefault();
            string bookName = db.Books.Where(x => x.ID == id).FirstOrDefault().BookName;
            ViewBag.bookName = bookName;
            int bookId = db.Books.Where(x => x.ID == id).FirstOrDefault().ID;
            ViewBag.bookId = bookId;
            return View();
        }

        // GET: Admin/Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
