using ClasesAlicanTeam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.EN
{
    public class ENLineCustomerOrder
    {
        private int idLines_Customers;
        private ENCustomerOrder customerOrder;
        private ENNew newBook;
        private int quantity;
        private float total;
        private CADLineCustomerOrder cad;

        public int IdLines_Customers
        {
            get { return idLines_Customers; }
            set { idLines_Customers = value; }
        }

        public ENCustomerOrder CustomerOrder
        {
            get { return customerOrder; }
            set { customerOrder = value; }
        }

        public ENNew NewBook
        {
            get { return newBook; }
            set { newBook = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public float Total
        {
            get { // catidad * precio del libro
                    return total; }
        }

        public ENLineCustomerOrder()
        {
            cad = new CADLineCustomerOrder();
        }

        public ENLineCustomerOrder(int idLines_Customers, ENCustomerOrder customerOrder, ENNew newBook, int quantity)
        {
            this.idLines_Customers = idLines_Customers;
            this.customerOrder = customerOrder;
            this.newBook = newBook;
            this.quantity = quantity;
            cad = new CADLineCustomerOrder();
        }

        public Boolean insert()
        {
            try
            {
                return cad.insert(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean update()
        {
            return false;
        }

        public Boolean delete()
        {

            try
            {
                return cad.delete(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
