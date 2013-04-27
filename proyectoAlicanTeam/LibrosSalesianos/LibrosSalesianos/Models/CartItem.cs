﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrosSalesianos.Models
{
    public class CartItem
    {
         #region Properties

        // A place to store the quantity in the cart
        // This property has an implicit getter and setter.
        public int Quantity { get; set; }

        public string BookIsbn
        {
            get { return Book.ISBN; }
        }

        public Book Book { get; private set; }

        public string Description
        {
            get { return Book.Description; }
        }

        public string Image { get { return Book.Image; } }

        public float UnitPrice
        {
            get { return Book.Price; }
        }

        public float TotalPrice
        {
            get { return UnitPrice * Quantity; }
        }

        #endregion

        public CartItem(Book book)
        {
            this.Book = book;
            this.Quantity = 1;
        }

        /**
         * Equals() - Needed to implement the IEquatable interface
         *    Tests whether or not this item is equal to the parameter
         *    This method is called by the Contains() method in the List class
         *    We used this Contains() method in the ShoppingCart AddItem() method
         */
        public bool Equals(CartItem item)
        {
            return item.BookIsbn == this.BookIsbn;
        }
    }
}