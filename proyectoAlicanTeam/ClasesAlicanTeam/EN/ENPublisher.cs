using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;

namespace ClasesAlicanTeam.EN
{
    public class ENPublisher : ENBusiness
    {
        
       private CADPublisher cadPublisher;

       public ENPublisher() : base()
        {
            cadPublisher = new CADPublisher();
        }

       public ENPublisher(String cif, String name, String address, int telephone, String email)
            : base(cif,name,address,telephone,email)
        {
            cadPublisher = new CADPublisher();
        }

       public ENPublisher(ENPublisher publisher)
            : base(publisher.cif, publisher.Name,publisher.Address,publisher.Telephone,publisher.Email)
        {
                cadPublisher = new CADPublisher();
        }

       public ENPublisher read(String cif)
        {
            return cadPublisher.read(cif);
        }

       public List<ENPublisher> readAll()
        {
            return cadPublisher.readAll();
        }
        
         
    }
}
