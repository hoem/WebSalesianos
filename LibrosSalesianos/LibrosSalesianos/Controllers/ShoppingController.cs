using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrosSalesianos.Models;

namespace LibrosSalesianos.Controllers
{
    public class ShoppingController : Controller
    {
        //
        // GET: /Shopping/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShoppingCartExample()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult AddShoesToCart()
        {
            ShoppingCart.Instance.AddItem(1);
            return RedirectToAction("ShoppingCartExample");
        }

        public ActionResult AddShirtToCart()
        {
            ShoppingCart.Instance.AddItem(2);
            return RedirectToAction("ShoppingCartExample");
        }

        public ActionResult AddPantsToCart()
        {
            ShoppingCart.Instance.AddItem(3);
            return RedirectToAction("ShoppingCartExample");
        }
    }
}
