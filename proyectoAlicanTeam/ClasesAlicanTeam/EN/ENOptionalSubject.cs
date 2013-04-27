using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;

namespace ClasesAlicanTeam.EN
{
    public class ENOptionalSubject : ENSubject
    {
        
        private CADOptionalSubject cadOptionalSubject;
        

        public ENOptionalSubject() : base()
        {
            cadOptionalSubject = new CADOptionalSubject();
        }

        public ENOptionalSubject(String name, ENCourse course) : base(name, course)
        {
            cadOptionalSubject = new CADOptionalSubject();
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
                return cadSubject.insert(this) && cadOptionalSubject.insert(this);
            } catch(Exception ex)
            {
                throw ex;
            }

        }

        public Boolean update(ENOptionalSubject subject)
        {
            try
            {
                return cadSubject.update(this, subject) && cadOptionalSubject.update(this, subject);
            } catch(Exception ex) 
            {

                throw ex;
            }
        }

        public Boolean delete()
        {
            try
            {
                return cadOptionalSubject.delete(this) && cadSubject.delete(this);
            } catch (Exception ex) 
            {
                throw ex;

            }
        }
    }
}
