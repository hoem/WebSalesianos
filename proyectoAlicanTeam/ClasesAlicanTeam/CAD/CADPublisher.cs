using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.EN;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ClasesAlicanTeam.CAD
{
    public class CADPublisher : CADBusiness
    {
        public CADPublisher() : base()
        {
            
        }

        public  Boolean insert(ENPublisher publisher)
        {

            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO Publishing_House (CIF) VALUES (@CIF)", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", publisher.Cif));
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

            }
        }

        public  Boolean update(ENPublisher publisher)
        {

            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Publishing_House SET CIF=@CIF WHERE CIF=@CIF)", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", publisher.Cif));

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

        public  Boolean delete(ENPublisher publisher)
        {

            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Publishing_House WHERE CIF=@CIF", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", publisher.Cif));
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

        public  ENPublisher read(String cif)
        {

            try
            {

                connect();


                SqlCommand cmd = new SqlCommand("SELECT * FROM Publishing_House WHERE CIF=@CIF)", connection);
                cmd.Parameters.Add(new SqlParameter("@CIF", cif));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENPublisher publisher = new ENPublisher();
                publisher.Cif = dr["CIF"].ToString(); //devuelve un objeto EN que tendra todos sus datos
                /*publisher.Name = dr["Name"].ToString();
                publisher.Address = dr["Address"].ToString();
                publisher.Telephone = Convert.ToInt32(dr["Telephone"]);
                publisher.Email = dr["Email"].ToString();*/

                dr.Close();

                return publisher;
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

        public  List<ENPublisher> readAll()
        {

            try
            {
                List<ENPublisher> lista = new List<ENPublisher>();

                connect();

                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Publishing_House", connection);
                adaptador.Fill(ds, "Publishing_House");

                dt = ds.Tables["Publishing_House"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENPublisher publisher = new ENPublisher();
                    publisher.Cif = dt.Rows[i][0].ToString();
                   /*publisher.Name = dt.Rows[i][1].ToString();
                    publisher.Address = dt.Rows[i][2].ToString();
                    publisher.Telephone = Convert.ToInt32(dt.Rows[i][3]);
                    publisher.Email = dt.Rows[i][4].ToString();*/
                    lista.Add(publisher);
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
