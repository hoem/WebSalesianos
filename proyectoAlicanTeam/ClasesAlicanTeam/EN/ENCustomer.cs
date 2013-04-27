using ClasesAlicanTeam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.EN
{
    public class ENCustomer : ENUser
    {
        private String idCustomers;
        private String name;
        private String surname;
        private int telephone;
        private String adress;

        private CADCustomer cad;

        public String IdCustomers
        {
            get { return idCustomers; }
            set { idCustomers = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public int Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public String Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public ENCustomer() : base()
        {
            cad = new CADCustomer();
        }

        public ENCustomer(String idCustomers, String password, String Name, String surname, int telephone, String adress) : base(idCustomers, password)
        {
            this.init(idCustomers, name, surname, telephone, adress);
            cad = new CADCustomer();
        }

        public ENCustomer(ENCustomer customer) : base(customer.idCustomers, customer.Password)
        {
                this.init (customer.idCustomers, customer.name, customer.surname, customer.telephone, customer.adress);
                cad = new CADCustomer();
        }

        private void init (String idCustomers, String name, String surname, int telephone, String adress)
        {
            this.idCustomers = idCustomers;
            this.name = name;
            this.surname = surname;
            this.telephone = telephone;
            this.adress = adress;
        }

        public ENCustomer read(String idCustomers)
        {
            try
            {
                return cad.read(idCustomers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ENCustomer> readAll()
        {
            try
            {
                return cad.readAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}