using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;

namespace ClasesAlicanTeam.EN
{
    public class ENBusiness
    {
        protected CADBusiness cadBusiness;
        protected String cif;
        protected String name;
        protected String address;
        protected int telephone;
        protected String email;

        public ENBusiness()
        {
            cadBusiness = new CADBusiness();
        }

        public ENBusiness(String cif, String name, String address, int telephone, String email)
        {
            this.cif = cif;
            this.name = name;
            this.address = address;
            this.telephone = telephone;
            this.email = email;
            cadBusiness = new CADBusiness();
        }

        public String Cif
        {
            get { return cif; }
            set { cif = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public int Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public Boolean insert()
        {
            try
            {
                return cadBusiness.insert(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean update()
        {
            try
            {
                return cadBusiness.update(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean delete()
        {

            try
            {
                return cadBusiness.delete(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ENBusiness read(String cif)
        {
            return cadBusiness.read(cif);
        }

        public IList<ENBusiness> readAll()
        {
            return cadBusiness.readAll();
        }

    }
}
