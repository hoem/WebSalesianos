using ClasesAlicanTeam.EN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.CAD
{
    public class CADCustomerOrder : ICAD
    {

        public  CADCustomerOrder()
        {
            init();
        }

        public  Boolean insert(ENCustomerOrder customerOrder)
        {

       

            try
            {

                connect();

                SqlCommand cmd = new SqlCommand("INSERT INTO Customers_Orders (COrder, idCustomers, DataOrder) VALUES (@COrder, @idCostumers, @DataOrder)", connection);

                cmd.Parameters.Add(new SqlParameter("@idCorder", customerOrder.COrder));
                cmd.Parameters.Add(new SqlParameter("@idCostumers", customerOrder.Customer.IdCustomers));
                cmd.Parameters.Add(new SqlParameter("@DataOrder", customerOrder.DataOrder));
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

        public  Boolean delete(ENCustomerOrder customerOrder)
        {

            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Customers_Orders WHERE COrder=@COrder", connection);

                cmd.Parameters.Add(new SqlParameter("@COrder", customerOrder.COrder));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    SqlCommand cmdlines = new SqlCommand("DELETE FROM Order_Lines_Customers WHERE COrder=@COrder", connection);
                    cmdlines.Parameters.Add(new SqlParameter("@COrder", customerOrder.COrder));
                    if (cmdlines.ExecuteNonQuery() >= 0)
                        return true;
                    else
                        return false;
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

        public  ENCustomer read(object x)
        {
            return null;
        }

        public  List<object> readAll()
        {
            return null;
        }
    }
}
