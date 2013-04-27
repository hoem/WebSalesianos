using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;
namespace ClasesAlicanTeam.EN
{
    public class ENUsedBook
    {
        CADUsedBook usedBook;
        int idUBook;
        ENBook book;
        String name;
        int quantity;

        public ENUsedBook()
        {
            book = new ENBook();
        }

        public ENUsedBook(int id, ENBook book, String name, int quantity)
        {
            this.idUBook = id;
            this.book = book;
            this.name = name;
            this.quantity = quantity;
        }

        public bool insert()
        {
            try
            {
                return usedBook.insert(this);
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
                return usedBook.update(this);
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
                return usedBook.delete(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CADUsedBook UsedBook
        {
            get { return usedBook; }
            set { usedBook = value; }
        }

        public int IdUBook
        {
            get { return idUBook; }
            set { idUBook = value; }
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

        public ENBook Book
        {
            get { return book; }
            set { book = value; }
        }

    }
}
