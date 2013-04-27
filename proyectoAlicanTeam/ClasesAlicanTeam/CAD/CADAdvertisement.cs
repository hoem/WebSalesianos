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
    public class CADAdvertisement : ICAD
    {

        public CADAdvertisement()
        {
            init();
        } 

        public  Boolean insert(ENAdvertisement advertisement)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO Advertisements (idAdvertisements, idCostumers, Description, Picture) VALUES (@idAdvertisements, @idCostumers, @Description, @Picture)", connection);

                cmd.Parameters.Add(new SqlParameter("@idAdvertisements", advertisement.IdAdvertisement));
                cmd.Parameters.Add(new SqlParameter("@idCostumers", advertisement.Customer.IdCustomers));
                cmd.Parameters.Add(new SqlParameter("@Description", advertisement.Description));
                cmd.Parameters.Add(new SqlParameter("@Pictures", advertisement.Picture));
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

        public  Boolean update(ENAdvertisement advertisement)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Advertisements SET idAdvertisements=@idAdvertisements, idCostumers= @idCostumers, Description=@Description, Picture=@Picture WHERE idAdvertisements=@idAdvertisements)", connection);

                cmd.Parameters.Add(new SqlParameter("@idAdvertisements", advertisement.IdAdvertisement));
                cmd.Parameters.Add(new SqlParameter("@idCostumers", advertisement.Customer.IdCustomers));
                cmd.Parameters.Add(new SqlParameter("@idDescription", advertisement.Description));
                cmd.Parameters.Add(new SqlParameter("@idPictures", advertisement.Picture));
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

        public  Boolean delete(ENAdvertisement advertisement)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Advertisements WHERE idAdvertisements=@idAdvertisements", connection);

                cmd.Parameters.Add(new SqlParameter("@idAdvertisements", advertisement.IdAdvertisement));
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

        public  ENAdvertisement read(int idAdvertisement)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(sqlConnectionString);
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Advertisements WHERE idAdvertisements=@idAdvertisements", connection);
                cmd.Parameters.Add(new SqlParameter("@idAdvertisements", idAdvertisement));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENAdvertisement advertisement = new ENAdvertisement();
                advertisement.IdAdvertisement = Convert.ToInt32(dr["idAdvertisements"]);
                advertisement.Customer.IdCustomers = dr["idCustomers"].ToString();
                advertisement.Description = dr["Description"].ToString();
                //advertisement.Picture = dr["Picture"].ToString();

                dr.Close();

                return advertisement;
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

        public  List<ENAdvertisement> readAll()
        {


            try
            {
                List<ENAdvertisement> lista = new List<ENAdvertisement>();
                connect();

                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Advertisements", connection);
                adaptador.Fill(ds, "Advertisements");

                dt = ds.Tables["Advertisements"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENAdvertisement advertisement = new ENAdvertisement();
                    advertisement.IdAdvertisement = Convert.ToInt32(dt.Rows[i][0]);
                    advertisement.Customer.Account = dt.Rows[i][1].ToString();
                    advertisement.Description = dt.Rows[i][2].ToString();
                    advertisement.Picture = dt.Rows[i][3].ToString();
                    lista.Add(advertisement);
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
