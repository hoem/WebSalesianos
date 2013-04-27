using ClasesAlicanTeam.EN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.CAD
{
    public class CADLineCustomerOrder : ICAD
    {

        public CADLineCustomerOrder()
        {
            init();
        }

        public  Boolean insert(ENLineCustomerOrder lineCustomerOrder)
        {

            try
            {

                connect();

                SqlCommand cmd = new SqlCommand("INSERT INTO Order_Lines_Customers (idLines_Customers, COrder, idNews, Quantity) VALUES (@idLines_Customers, @COrder, @ideNews, @Quantity)", connection);

                cmd.Parameters.Add(new SqlParameter("@idLines_Customers", lineCustomerOrder.IdLines_Customers));
                cmd.Parameters.Add(new SqlParameter("@COrder", lineCustomerOrder.CustomerOrder.COrder));
               // cmd.Parameters.Add(new SqlParameter("@idNews", lineCustomerOrder.NewBook.IdNews)); falta implementar en ENNewBook
                cmd.Parameters.Add(new SqlParameter("@Quantity", lineCustomerOrder.Quantity));
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

        public  Boolean delete(ENLineCustomerOrder lineCustomerOrder)
        {

            SqlConnection connection = null;

            try
            {

                connect();
                
                SqlCommand cmd = new SqlCommand("DELETE FROM Order_Lines_Customers WHERE idLines_Customers = @idLinesCustomers AND COrder=@COrder", connection);

                cmd.Parameters.Add(new SqlParameter("@COrder", lineCustomerOrder.CustomerOrder.COrder));
                cmd.Parameters.Add(new SqlParameter("@idLines_Customers", lineCustomerOrder.IdLines_Customers));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
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

        public  ENLineCustomerOrder read(object x)
        {
            return null;
        }

        public  List<ENLineCustomerOrder> readAll()
        {
            return null;
        }

    }
}
