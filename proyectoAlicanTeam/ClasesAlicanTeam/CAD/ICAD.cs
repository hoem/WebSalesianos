using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.EN;

namespace ClasesAlicanTeam.CAD
{
    public  class ICAD
    {
        protected String sqlConnectionString;
        protected SqlConnection connection = null;

        public void init()
        {
            sqlConnectionString = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
        }

        public void connect()
        {
            
            try
            {
                connection = new SqlConnection(sqlConnectionString);
                connection.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public void disconnect()
        {
            connection.Close(); 
        }


    }
}
