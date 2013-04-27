using ClasesAlicanTeam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.EN
{
    public class ENSubject
    {
        protected ENCourse course;
        protected CADSubject cadSubject;
        protected String name;

        public ENSubject()
        {
            course = new ENCourse();
            cadSubject = new CADSubject();
        }

        public ENSubject(String name, ENCourse course)
        {
            cadSubject = new CADSubject();
            this.name = name;
            this.course = course;
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
                return cadSubject.insert(this);
            } catch(Exception ex)
            {
                throw ex;
            }

        }

        public Boolean update(ENSubject oldSubject, ENSubject newSubject)
        {
            try
            {
                return cadSubject.update(oldSubject, newSubject);
            } catch(Exception ex) 
            {

                throw ex;
            }
        }

        public Boolean delete()
        {
            try
            {
                return cadSubject.delete(this);
            } catch (Exception ex) 
            {
                throw ex;

            }
        }
    }
}
