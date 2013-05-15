using ClasesAlicanTeam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesAlicanTeam.EN
{
    public class ENLineCustomerOrder : AEN
    {
        private int idLines_Customers;
        private int idCustomerOrder;
        private ENNewBook newBook;
        private int quantity;
        private float total;
        private CADLineCustomerOrder cad;

        public int IdLines_Customers
        {
            get { return idLines_Customers; }
            set { idLines_Customers = value; }
        }

        public int IdcustomerOrder
        {
            get { return idCustomerOrder; }
            set { idCustomerOrder = value; }
        }

        public ENNewBook NewBook
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
            get { return quantity*newBook.Price; }
        }

        public ENLineCustomerOrder()
        {
            id = 0;
            idLines_Customers = 1;
            idCustomerOrder = 0;
            newBook = new ENNewBook();
            total = 0;
            cad = new CADLineCustomerOrder();
        }

        public ENLineCustomerOrder(int idLines_Customers, int customerOrder, ENNewBook newBook, int quantity)
        {
            this.idLines_Customers = idLines_Customers;
            this.idCustomerOrder = customerOrder;
            this.newBook = newBook;
            this.quantity = quantity;
            this.total = quantity * newBook.Price;
            cad = new CADLineCustomerOrder();
        }


        protected override DataRow ToDataRow
        {
            get
            {
                DataRow ret = cad.GetVoidRow;
                ret["id"] = this.id;
                ret["idLines_Customers"] = idLines_Customers;
	            ret["COrder"] = idCustomerOrder;
	            ret["idNews"] = newBook.Id;
                ret["Quantity"] = quantity;
                
                
                return ret;
            }
        }

        protected override void FromRow(DataRow Row)
        {
            this.id = (int) Row["id"];
            idLines_Customers = (int) Row["idLines_Customers"];
            idCustomerOrder = (int)    Row["COrder"];
            newBook = newBook.Read( (int)Row["idNews"]);
            quantity = (int)  Row["Quantity"];
        }

        public override int Save()
        {
            try
            {

                if (id == 0)
                {
                    return id = cad.Insert(ToDataRow);
                }
                else
                {
                    cad.Update(ToDataRow);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete()
        {
            try
            {
                cad.Delete(ToDataRow);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<ENLineCustomerOrder> ReadAll()
        {
            List<ENLineCustomerOrder> ret = new List<ENLineCustomerOrder>();
            DataTable table = cad.SelectAll();

            try
            {
                foreach (DataRow row in table.Rows)
                {
                    ENLineCustomerOrder line = new ENLineCustomerOrder();
                    line.FromRow(row);
                    ret.Add(line);
                }

                return ret;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ENLineCustomerOrder Read(int id)
        {
            ENLineCustomerOrder ret = new ENLineCustomerOrder();
            List<object> param = new List<object>();
            param.Add((object)id);
            try
            {
                ret.FromRow(cad.Select(param));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return ret;
        }

        public List<ENLineCustomerOrder> Filter(String where)
        {
            List<ENLineCustomerOrder> ret = new List<ENLineCustomerOrder>();
            DataTable table = cad.SelectWhere(where);

            try
            {
                foreach (DataRow row in table.Rows)
                {
                    ENLineCustomerOrder line = new ENLineCustomerOrder();
                    line.FromRow(row);
                    ret.Add(line);
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
