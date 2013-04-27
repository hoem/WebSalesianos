using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.EN;

namespace ClasesAlicanTeam.CAD
{
    public class CADYear : ICAD
    {
        public CADYear()
        {
            init();
        }
        public  bool insert(ENYear newYear)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO Year (Year) VALUES (@Year)", connection);

                cmd.Parameters.Add(new SqlParameter("@Year", newYear));
                
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
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

        public  bool delete(ENYear oldYear)
        {
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Years SET years= @years", connection);

                cmd.Parameters.Add(new SqlParameter("@years", oldYear.Year));

                if (cmd.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
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

        public  Boolean update(object x)
        {
            return true;
        }

        public ENYear read(int id)
        {

            try
            {

                connect();


                SqlCommand cmd = new SqlCommand("SELECT * FROM Years WHERE years=@years)", connection);
                cmd.Parameters.Add(new SqlParameter("@years", id));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENYear resultado = new ENYear();
                resultado.Year = int.Parse(dr["years"].ToString()); //devuelve un objeto EN que tendra todos sus datos
               

                dr.Close();

                return resultado;
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

        public  List<ENYear> readAll()
        {
            List<ENYear> years = new List<ENYear>();
            try
            {
                connect();
                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Years", connection);
                adaptador.Fill(ds, "Years");

                dt = ds.Tables["Years"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENYear resultado = new ENYear();
                    resultado.Year = int.Parse(dt.Rows[i][0].ToString());
                    
                    years.Add(resultado);
                }

                return years;
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
    }
}
