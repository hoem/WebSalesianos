using ClasesAlicanTeam.EN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.CAD
{
    public class CADCourse : ICAD
    {

        public CADCourse()
        {
            init();
        }

        public  Boolean insert(ENCourse course)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(sqlConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Courses (Courses) " + "VALUES (@courses)", connection);
                cmd.Parameters.Add(new SqlParameter("@courses", course.Courses));
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
                connection.Close();
            }
        }

        public  Boolean update(ENCourse course)
        {
            throw new NotImplementedException();
        }

        public  Boolean delete(ENCourse course)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(sqlConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Courses WHERE Courses=@courses", connection);
                cmd.Parameters.Add(new SqlParameter("@courses", course.Courses));
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
                connection.Close();
            }
        }

        public  ENCourse read(String Courses)
        {
            try
            {
                connect();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Courses WHERE Courses=@Courses", connection);
                cmd.Parameters.Add(new SqlParameter("@Courses", Courses));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENCourse course = new ENCourse();
                course.Courses = dr["Courses"].ToString();

                dr.Close();

                return course;
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

        public  List<ENCourse> readAll()
        {

            try
            {
                List<ENCourse> lista = new List<ENCourse>();
                connect();
                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Courses", connection);
                adaptador.Fill(ds, "Courses");

                dt = ds.Tables["Courses"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENCourse course = new ENCourse();
                    course.Courses = dt.Rows[i][0].ToString();
                    lista.Add(course);
                }

                return lista;
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
