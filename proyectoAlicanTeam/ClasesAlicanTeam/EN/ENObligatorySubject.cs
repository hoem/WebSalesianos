using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;

namespace ClasesAlicanTeam.EN
{

    public class ENObligatorySubject : ENSubject
    {
        private CADObligatorySubject cadObligatorySubject;
        

        public ENObligatorySubject() : base()
        {
            cadObligatorySubject = new CADObligatorySubject();
        }

        public ENObligatorySubject(String name, ENCourse course) : base(name, course)
        {
            cadObligatorySubject = new CADObligatorySubject();
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public ENCourse Course
        {
            get { return course; }
            set { course = value; }
        }
        public Boolean insert()
        {

            try
            {
                return cadSubject.insert(this) && cadObligatorySubject.insert(this);
            } catch(Exception ex)
            {
                throw ex;
            }

        }

        public Boolean update(ENObligatorySubject oldSubject, ENObligatorySubject newSubject)
        {
            try
            {
                return cadSubject.update(oldSubject, newSubject) && cadObligatorySubject.update(oldSubject, newSubject);
            } catch(Exception ex) 
            {

                throw ex;
            }
        }

        public Boolean delete()
        {
            try
            {
                return cadObligatorySubject.delete(this) && cadSubject.delete(this);
            } catch (Exception ex) 
            {
                throw ex;

            }
        }
    }
}

