using KitapKurdu.UI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurduCom.Controllers
{
    public class ShoppingCartController : Controller
    {
        SessionClass sessionClass = new SessionClass();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            if (Session["kullanici"] == null)
            {
                sessionClass.sessionValue = true;
                return RedirectToAction("Index", "Account");
            }
            return View();
        }
    }
}