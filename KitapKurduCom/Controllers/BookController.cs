using KitapKurdu.UI.Models.DatabaseContext;
using KitapKurdu.UI.Models.Entity;
using KitapKurdu.UI.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurdu.UI.Controllers
{
    public class BookController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        SessionClass sessionClass = new SessionClass();
        int kullaniciID;
        public BookController()
        {

            //kullaniciID = Convert.ToInt32(Session["kullanici"]);
        }
        // GET: Book
        public ActionResult Index(string searchString, string sortOption,int? catId, int page = 1)
        {
            int pageSize = 9;
            ViewBag.Categories = db.Categories.Where(c => c.Books.Count > 0).ToList();
            var books = db.Books.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                books = db.Books.Where(b => b.BookName.ToLower().Contains(searchString));
            }
            switch (sortOption)
            {
                case "name_acs":
                    books = books.OrderBy(b => b.BookName);
                    break;
                case "name_desc":
                    books = books.OrderByDescending(b => b.BookName);
                    break;
                case "price_acs":
                    books = books.OrderBy(b => b.UnitPrice);
                    break;
                case "price_desc":
                    books = books.OrderByDescending(b => b.UnitPrice);
                    break;
                default:
                    books = books.OrderBy(b => b.ID);
                    break;

            }
            if (catId!=null)
            {
                books = books.Where(x => x.CategoryID == catId);
            }
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("BookList", books.ToPagedList(page, pageSize))
                : View(books.ToPagedList(page, pageSize));


        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.UrunFotolar = db.Books.Where(x => x.ID == id).FirstOrDefault().BookImages.ToList();
            return View(db.Books.Find(id));
        }

        [HttpGet]
        public ActionResult GetBooks()
        {
            kullaniciID = Convert.ToInt32(Session["kullanici"]);

            // var deneme = db.Books.Select(x => new  { x.ID, x.BookName,(x.BookImages.FirstOrDefault()).ImageUrl,x.UnitPrice}).Take(10).ToList();
            //var deneme = db.Books.Where(x => ((x.ShoppingCartBook.ToList()).ShoppingCart).Customer.ID == kullaniciID).Select(x => new { x.ID, x.BookName, (x.BookImages.FirstOrDefault()).ImageUrl, x.UnitPrice, (x.ShoppingCartBook.FirstOrDefault()).Quantity }).ToList();
           var deneme=db.ShoppingCartBooks.Where(x=>x.ShoppingCart.Customer.ID==kullaniciID).Select(x => new { x.Book.ID, x.Book.BookName, (x.Book.BookImages.FirstOrDefault()).ImageUrl, x.Book.UnitPrice, x.Quantity }).ToList();


            //var shoppingCart = db.ShoppingCarts.Where(x => x.Customer.ID == 1).Select(x => new { (x.Books.FirstOrDefault()).BookName, (x.Books.FirstOrDefault()).ID, ((x.Books.FirstOrDefault()).BookImages.FirstOrDefault()).ImageUrl, (x.Books.FirstOrDefault()).UnitPrice }).ToList();

            return Json(deneme, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddCart(int id, int? quantity)
        {
            if (Session["kullanici"] == null)
            {
                sessionClass.sessionValue = true;
                return Json(sessionClass, JsonRequestBehavior.AllowGet);
            }
            kullaniciID = Convert.ToInt32(Session["kullanici"]);
            sessionClass.sessionValue = false;
            ShoppingCartBook shoppingCartBook;
            Book book = db.Books.Find(id);
            ShoppingCart shoppingCart = (db.Customers.Where(x => x.ID == kullaniciID).FirstOrDefault()).ShoppingCart;
            // List<ShoppingCartBook> shoppingCartBooks = db.ShoppingCartBooks.Where(x => x.ShoppingCart.Customer.ID == 1).ToList();

            //shoppingCartBooks.Any(x => x.BookID == book.ID)
            if (db.ShoppingCartBooks.Any(x => x.ShoppingCart.ID == shoppingCart.ID && x.BookID == book.ID))
            {
                shoppingCartBook = db.ShoppingCartBooks.Where(x => x.ShoppingCart.ID == shoppingCart.ID && x.BookID == book.ID).FirstOrDefault();
                shoppingCartBook.ShoppingCart = shoppingCart;
                if (quantity == null)
                {

                    shoppingCartBook.Quantity += 1;

                }
                else
                {
                    shoppingCartBook.Quantity = (int)quantity;
                }

            }
            //if (shoppingCartBook.BookID==book.ID)
            //{
            //    shoppingCartBook.ShoppingCart = shoppingCart;
            //    shoppingCartBook.Quantity += quantity;
            //}
            else
            {
                shoppingCartBook = new ShoppingCartBook();
                shoppingCartBook.Book = book;
                shoppingCartBook.ShoppingCart = shoppingCart;
                if (quantity == null)
                {
                    shoppingCartBook.Quantity = 1;
                }
                else
                {
                    shoppingCartBook.Quantity = (int)quantity;

                }
                db.ShoppingCartBooks.Add(shoppingCartBook);
            }
            db.SaveChanges();
            //ICollection<Book> books = (shoppingCart.ShoppingCartBook.FirstOrDefault()).;

            //shoppingCart.Customer=db.Customers.Find(1);
            //shoppingCart.Books= books;
            //shoppingCart.IsConfirmed = false;

            return Json("başarılı");
        }
        [HttpPost]
        public ActionResult DeleteCartItem(int id)
        {
            if (Session["kullanici"] == null)
            {
                sessionClass.sessionValue = true;
                return Json(sessionClass, JsonRequestBehavior.AllowGet);
            }
            kullaniciID = Convert.ToInt32(Session["kullanici"]);
            sessionClass.sessionValue = false;
            //Book book = db.Books.Find(id);
            //ShoppingCart shoppingCart = (db.Customers.Where(x => x.ID == 1).FirstOrDefault()).ShoppingCart;
            //ICollection<Book> books = shoppingCart.Books;
            Book book = db.Books.Find(id);
            //books.Remove(book);
            //shoppingCart.Books = books;
            // ShoppingCart shoppingCart = (db.Customers.Where(x => x.ID == 1).FirstOrDefault()).ShoppingCart;

            ShoppingCartBook shoppingCartBook = db.ShoppingCartBooks.Where(x => x.ShoppingCart.Customer.ID == kullaniciID && x.BookID == book.ID).FirstOrDefault();
            if (db.ShoppingCartBooks.Any(x => x.BookID == book.ID))
            {
                db.ShoppingCartBooks.Remove(shoppingCartBook);
            }
            else
            {
                return Json("başarısız");
            }
            db.SaveChanges();
            return Json("başarılı");
        }

        // POST: Book/Delete/5
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
