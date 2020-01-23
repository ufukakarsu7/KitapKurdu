
using KitapKurdu.UI.Models.Entity;
using KitapKurdu.UI.Models.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurdu.UI.Controllers
{
    public class IndexController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        public IndexController()
        {
        }
        // GET: Index
        public ActionResult Index()
        {
            //List<Book> books = db.Books.Take(20).ToList();
            List<Category> topFive = db.Categories.OrderByDescending(x => x.Books.Count).Take(5).ToList();
            ViewBag.FirstCategory = topFive[0].Books.Take(10).ToList();

            ViewBag.SecondCategory = topFive[1].Books.Take(10).ToList();

            ViewBag.ThirdCategory = topFive[2].Books.Take(10).ToList();

            ViewBag.FourthCategory = topFive[3].Books.Take(10).ToList();

            ViewBag.FifthCategory = topFive[4].Books.Take(10).ToList();

            ViewBag.SonEklenenler = db.Books.OrderByDescending(x => x.ID).Take(20).ToList();
            ViewBag.Brodya = db.Books.Where(x => x.Category.CategoryName == "Brodya").ToList();
            return View(db.Books.Take(20).ToList());
        }

        [ChildActionOnly]
        public ActionResult ShoppingCart()
        {
            ViewBag.ShoppingCart = db.ShoppingCarts.Where(x => x.Customer.ID == 1).ToList();

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}