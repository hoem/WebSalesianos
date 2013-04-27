using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;


namespace ClasesAlicanTeam.EN
{
    public class ENDistributor : ENBusiness
    {
        private CADDistributor cadDistributor;


        public ENDistributor() : base()
        {
            cadDistributor = new CADDistributor();
        }

        public ENDistributor(String cif, String name, String address, int telephone, String email)
            : base(cif,name,address,telephone,email)
        {
            
            cadDistributor = new CADDistributor();
        }

        public ENDistributor(ENDistributor distributor)
            : base(distributor.cif, distributor.Name,distributor.Address,distributor.Telephone,distributor.Email)
        {
                
                cadDistributor = new CADDistributor();
        }

        public Boolean insert()
        {
            try
            {

                return cadBusiness.insert(this) && cadDistributor.insert(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean update()
        {
            return cadBusiness.update(this);
        }

        public Boolean delete()
        {
            return cadDistributor.delete(this) && cadBusiness.delete(this);
        }

        public ENDistributor read(String cif)
        {
            return cadDistributor.read(cif);
        }

        public IList<ENDistributor> readAll()
        {
            return cadDistributor.readAll();
        }

    }
}
