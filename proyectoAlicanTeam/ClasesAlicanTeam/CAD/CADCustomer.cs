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
    public class CADCustomer : CADUser
    {
        private String sqlConnectionString;

        public CADCustomer()
        {
            init();
        }

        public  Boolean insert(ENCustomer customer)
        {
            return true;
        }

        public  Boolean update(ENCustomer customer)
        {
            return false;
        }

        public  Boolean delete(ENCustomer customer)
        {
            return true;
        }

        public  ENCustomer read(String idCustomers)
        {
            

            try
            {
                connect();


                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE idCustomers=@idCustomers)", connection);
                cmd.Parameters.Add(new SqlParameter("@idCustomers", idCustomers));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENCustomer customer = new ENCustomer();
                customer.IdCustomers = dr["idCustomers"].ToString();
                customer.Name = dr["Name"].ToString();
                customer.Surname = dr["Surname"].ToString();
                customer.Telephone = Convert.ToInt32(dr["Telephone"]);
                customer.Adress = dr["Adress"].ToString();

                dr.Close();

                return customer;
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

        public  List<ENCustomer> readAll()
        {

            
            
            try
            {
                List<ENCustomer> lista = new List<ENCustomer>();

                connect();

                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Customers", connection);
                adaptador.Fill(ds, "Customers");

                dt = ds.Tables["Customers"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENCustomer customer = new ENCustomer();
                    customer.IdCustomers = dt.Rows[i][0].ToString();
                    customer.Name = dt.Rows[i][1].ToString();
                    customer.Surname = dt.Rows[i][2].ToString();
                    customer.Telephone = Convert.ToInt32(dt.Rows[i][3]);
                    customer.Adress = dt.Rows[i][4].ToString();
                    lista.Add(customer);
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
