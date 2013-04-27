using ClasesAlicanTeam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.EN
{
    public class ENCustomerOrder
    {
        private int cOrder;
        private ENCustomer customer;
        private DateTime dataOrder;
        private List<ENLineCustomerOrder> linescustomerorder;
        private float total;
        CADCustomerOrder cad;

        #region
        /// <summary>
        /// Devuelve y establece el COrder del Pedido.
        /// </summary>
        public int COrder
        {
            get { return COrder; }
            set { COrder = value; }
        }

        /// <summary>
        /// Devuelve y establece el ENCustormer del Pedido.
        /// </summary>
        public ENCustomer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        /// <summary>
        /// Devuelve y establece la fecha del Pedido.
        /// </summary>
        public DateTime DataOrder
        {
            get { return dataOrder; }
            set { dataOrder = value; }
        }

        /// <summary>
        /// Establece las lineas del Pedido.
        /// </summary>
        public List<ENLineCustomerOrder> Linecustomerorder
        {
            get { return linescustomerorder; }
        }

        /// <summary>
        /// Devuelve el total del precio del pedido.
        /// </summary>
        public float Total
        {
            get { return total; }
        }
        #endregion

        /// <summary>
        /// Constructor por defecto que inicializa el objeto con sus campos vacíos. 
        /// </summary>
        public ENCustomerOrder()
        {
            total = 0;
            cad = new CADCustomerOrder();
        }

        /// <summary>
        /// Constructor sobrecargado que inicializa el objeto con los datos que se la pasan por parámetro y deja las lineas de pedido vacías.
        /// </summary>
        /// <param name="cOrder">Identificador del pedido.</param>
        /// <param name="customer">ENCustomer que realiza el pedido.</param>
        /// <param name="DataOrder">Fecha en la que se realiza el pedido.</param>
        public ENCustomerOrder(int cOrder, ENCustomer customer, DateTime DataOrder)
        {
            this.cOrder = cOrder;
            this.customer = customer;
            this.dataOrder = DataOrder;
            this.total = 0;
            linescustomerorder = new List<ENLineCustomerOrder>();
            cad = new CADCustomerOrder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        public void addLineCustomerOrder(ENLineCustomerOrder line)
        {
            this.linescustomerorder.Add(line);
            // -> hacer la suma del total + el precio del librototal+= line.
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
