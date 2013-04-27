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
    public class CADDistributor : CADBusiness
    {
        

        public CADDistributor() : base()
        {
            
        }

        public  Boolean insert(ENDistributor distributor)
        {


            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO Distributors (CIF) VALUES (@CIF)", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", distributor.Cif));
                /*.Parameters.Add(new SqlParameter("@Name", business.Name));
                cmd.Parameters.Add(new SqlParameter("@Address", business.Address));
                cmd.Parameters.Add(new SqlParameter("@Telephone", business.Telephone));
                cmd.Parameters.Add(new SqlParameter("@Email", business.Email));*/
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

        public  Boolean update(ENDistributor distributor)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Distributors SET CIF=@CIF WHERE CIF=@CIF)", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", distributor.Cif));
                /*cmd.Parameters.Add(new SqlParameter("@Name", business.Name));
                cmd.Parameters.Add(new SqlParameter("@Address", business.Address));
                cmd.Parameters.Add(new SqlParameter("@Telephone", business.Telephone));
                cmd.Parameters.Add(new SqlParameter("@Email", business.Email));*/

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

        public  Boolean delete(ENDistributor distributor)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Publishing_House WHERE CIF=@CIF", connection);

                cmd.Parameters.Add(new SqlParameter("@CIF", distributor.Cif));
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

        public  ENDistributor read(String cif)
        {


            try
            {

                connect();


                SqlCommand cmd = new SqlCommand("SELECT * FROM Business WHERE CIF=@CIF)", connection);
                cmd.Parameters.Add(new SqlParameter("@CIF", cif));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENDistributor distributor = new ENDistributor();
                distributor.Cif = dr["CIF"].ToString(); //devuelve un objeto EN que tendra todos sus datos
                /*distributor.Name = dr["Name"].ToString();
                distributor.Address = dr["Address"].ToString();
                distributor.Telephone = Convert.ToInt32(dr["Telephone"]);
                distributor.Email = dr["Email"].ToString();*/

                ENBusiness business =  base.read(distributor.Cif);

                distributor.Address = business.Address;
                distributor.Email = business.Email;
                distributor.Name = business.Name;
                distributor.Telephone = business.Telephone;

                dr.Close();

                return distributor;

                
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

        public  List<ENDistributor> readAll()
        {


            try
            {
                List<ENDistributor> distributors = new List<ENDistributor>();
                List<ENBusiness> business = new List<ENBusiness>();
                List<ENDistributor> resultado = new List<ENDistributor>();
                connect();

                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Distributors", connection);
                adaptador.Fill(ds, "Distributor");

                dt = ds.Tables["Distributors"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENDistributor distributor = new ENDistributor();
                    distributor.Cif = dt.Rows[i][0].ToString();
                    distributors.Add(distributor);
                }

                business = base.readAll();

                int k = 0;
                for (int i = 0; i < business.Capacity; i++)
                {
                    for (int j = 0; j < distributors.Capacity; j++)
                    {
                        if (business[i].Cif == distributors[j].Cif)
                        {

                            resultado.Add(distributors[j]);
                            resultado[k].Email = business[j].Email;
                            resultado[k].Name = business[j].Name;
                            resultado[k].Telephone = business[j].Telephone;
                            resultado[k].Address = business[j].Address;

                            k++;
                        }
                    }

                }


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
    }
}

