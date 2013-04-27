using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.CAD
{
    public class CADUser : ICAD
    {
        public CADUser()
        {
            init();
        }

        public Boolean loguin(String account, String password)
        {
            Boolean correcto = false;

            try
            {

                connect();


                SqlCommand cmd = new SqlCommand("SELECT Password FROM Users WHERE Account=@account AND Password=@password)", connection);
                cmd.Parameters.Add(new SqlParameter("@account", account));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                    correcto = true;
                dr.Close();
                return correcto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                
                    disconnect();

                
            }
        }

        public  object insert(object x)
        {
            return true;
        }

        public  object delete(object x)
        {
            return true;
        }

        public  object update(object x)
        {
            return true;
        }

        public  object read(object x)
        {
            return true;
        }

        public  List<object> readAll()
        {
            return null;
        }
    }
}
