using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;

namespace ClasesAlicanTeam.EN
{
    public class ENBook
    {
        protected CADBook cadBook;
        protected String idBook;
        protected ENSubject subject; 
        protected ENCourse course; 
        protected String cif;
        protected ENYear years;
        protected String name;
        protected int quantity;
        protected String description;
        protected String image;

        public ENBook()
        {
            cadBook = new CADBook();
            subject = new ENSubject();
            course = new ENCourse();
            
        }

        public ENBook(String idBook, ENSubject subject, ENCourse course, 
            String cif, ENYear years, String name, int quantity, String description)
        {
            this.cadBook = new CADBook();
            this.idBook = idBook;
            this.subject = subject;
            this.course = course;
            this.cif = cif;
            if(years != null)
                this.years = years;
            years = new ENYear(System.DateTime.Today.Year);
            this.name = name;
            this.quantity = quantity;
            this.description = description;
        }

        public bool insert()
        {
            try
            {
                return cadBook.insert(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update()
        {
            try
            {
                return cadBook.update(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete()
        {
            try
            {
                return cadBook.delete(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ENBook read(String id)
        {
            return cadBook.read(id);
        }

        public List<ENBook> readAll()
        {
            return cadBook.readAll();          
        }

        public CADBook CADBook
        {
            get { return cadBook; }
            set { cadBook = value; }
        }

        public String IDBook
        {
            get { return idBook; }
            set { idBook = value; }
        }

        public ENSubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public ENCourse Course
        {
            get { return course; }
            set { course = value; }
        }

        public String CIF
        {
            get { return cif; }
            set { cif = value; }
        }

        public ENYear Years
        {
            get { return years; }
            set { years = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
