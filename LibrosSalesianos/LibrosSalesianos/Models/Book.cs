using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrosSalesianos.Models
{
    public class Book
    {
        public string Image {
            get { return this.image; }
            set { this.image = value; }
        }
        public string ISBN { 
            get { return this.isbn; }
            set { this.isbn = value; }
        }
        public string Description { 
            get { return this.description; }
            set { this.description = value; }
        }
        public float Price { 
            get { return this.price; }
            set { this.price = value; }
        }

        private string isbn;
        private string description;
        private float price;
        private string image;

        public Book(string isbn, string description, float price, string image)
        {
            this.isbn = isbn;
            this.description = description;
            this.price = price;
            this.image = image;
        }
    }
}