using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;

namespace ClasesAlicanTeam.EN
{
    public class ENYear
    {
        private int year;
        private CADYear cadYear;


        public ENYear()
        {
            cadYear = new CADYear();
        }

        public ENYear(int year)
        {
            this.year = year;
            cadYear = new CADYear();
        }

        public bool insert()
        {
            return cadYear.insert(this);
        }

        public bool delete()
        {
            return cadYear.delete(this);
        }

        public ENYear read()
        {
            return cadYear.read(this.year);
        }

        public List<ENYear> readAll()
        {
            return cadYear.readAll();
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
    }
}
