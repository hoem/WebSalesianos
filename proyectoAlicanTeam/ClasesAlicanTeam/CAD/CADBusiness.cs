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
    public class CADBusiness : ICAD
    {

        public CADBusiness()
        {
            init();
        } 

        public  Boolean insert(ENBusiness business)
        {

            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO Business (CIF, Name, Address, Telephone,Email) VALUES (@CIF, @Name, @Address, @Telephone,@Email)", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", business.Cif));
                cmd.Parameters.Add(new SqlParameter("@Name", business.Name));
                cmd.Parameters.Add(new SqlParameter("@Address", business.Address));
                cmd.Parameters.Add(new SqlParameter("@Telephone", business.Telephone));
                cmd.Parameters.Add(new SqlParameter("@Email", business.Email));
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

        public  Boolean update(ENBusiness business)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Business SET CIF=@CIF, Name=@Name, Address=@Address, Telephone=@Telephone, Email=@Email WHERE CIF=@CIF)", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", business.Cif));
                cmd.Parameters.Add(new SqlParameter("@Name", business.Name));
                cmd.Parameters.Add(new SqlParameter("@Address", business.Address));
                cmd.Parameters.Add(new SqlParameter("@Telephone", business.Telephone));
                cmd.Parameters.Add(new SqlParameter("@Email", business.Email));

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

        public  Boolean delete(ENBusiness business)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Business WHERE CIF=@CIF", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", business.Cif));
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

        public  ENBusiness read(String cif)
        {

            try
            {

                connect();


                SqlCommand cmd = new SqlCommand("SELECT * FROM Business WHERE CIF=@CIF)", connection);
                cmd.Parameters.Add(new SqlParameter("@CIF", cif));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENBusiness business = new ENBusiness();
                business.Cif = dr["CIF"].ToString(); //devuelve un objeto EN que tendra todos sus datos
                business.Name = dr["Name"].ToString();
                business.Address = dr["Address"].ToString();
                business.Telephone = Convert.ToInt32(dr["Telephone"]);
                business.Email = dr["Email"].ToString();

                dr.Close();

                return business;
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

        public  List<ENBusiness> readAll()
        {


            try
            {
                List<ENBusiness> lista = new List<ENBusiness>();

                connect();

                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Business", connection);
                adaptador.Fill(ds, "Business");

                dt = ds.Tables["Business"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENBusiness business = new ENBusiness();
                    business.Cif = dt.Rows[i][0].ToString();
                    business.Name = dt.Rows[i][1].ToString();
                    business.Address = dt.Rows[i][2].ToString();
                    business.Telephone = Convert.ToInt32(dt.Rows[i][3]);
                    business.Email = dt.Rows[i][4].ToString();
                    lista.Add(business);
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
