﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrosSalesianos.Models;
using ClasesAlicanTeam.EN;

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
            return View(ShoppingCart.Instance);
        }

        public ActionResult AddToCart(int id)
        {
            var book = new ENNewBook(id);
            //var book = new Book(isbn, des, price, img);
            ShoppingCart.Instance.AddItem(book);
            return Content("true");
        }

        public ActionResult RemoveFromCart(ENNewBook newbook)
        {
            var book = new ENNewBook();
            var nbook = book.Read(newbook.Id);
            ShoppingCart.Instance.RemoveItem(nbook);
            return RedirectToAction("Cart");
        }

        public ActionResult SetQuantityItem(string isbn, int quantity)
        {
            ShoppingCart.Instance.SetItemQuantity(isbn, quantity);
            return RedirectToAction("Cart");
        }

        public JsonResult ShoppingCartJson()
        {
            ShoppingCart sp = (ShoppingCart)Session["ASPNETShoppingCart"];
            if (sp == null)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
                    
            return Json(sp.Items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuyingBooks()
        {
            var book = new ENNewBook();
            var books = book.ReadAll();
            /*
            var book = new Book("012345", "Mi bonico libro daprender", 99.01f, "/Scripts/widgets/jqwidgets/images/books/Carrie.jpg");
            var book1 = new Book("012346", "Sueños rallantes", 34.29f, "/Scripts/widgets/jqwidgets/images/inception.jpg");
            var book2 = new Book("012347", "El oso peleon", 1.10f, "/Scripts/widgets/jqwidgets/images/kungfupanda.png");
            var book3 = new Book("012348", "Hostias como panes", 22.99f, "/Scripts/widgets/jqwidgets/images/knockout.png");
            var books = new List<Book>();
            books.Add(book);
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);*/
            return View("BuyingBooks", books);
        }

        public class PruebaBeverage
        {
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string calories { get; set; }
            public string totalfat { get; set; }
            public string protein { get; set; }
        }

        public JsonResult beverages()
        {
            PruebaBeverage pb = new PruebaBeverage();
            pb.id = "1";
            pb.name = "Hot CHocolate";
            pb.type = "cerdo";
            pb.calories = "370";
            pb.totalfat = "16g";
            pb.protein = "14g";
            var list = new List<PruebaBeverage>();
            list.Add(pb);
            var pb1 = new PruebaBeverage();
            pb1.id = "2";
            pb1.name = "ASdasd";
            pb1.type = "olvidadizo";
            pb1.calories = "370";
            pb1.totalfat = "16g";
            pb1.protein = "14g";
            list.Add(pb1);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
