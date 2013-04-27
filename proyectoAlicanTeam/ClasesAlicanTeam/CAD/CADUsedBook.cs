using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.EN;
using System.Configuration;
namespace ClasesAlicanTeam.CAD
{
    public class CADUsedBook : ICAD
    {
        public CADUsedBook()
        {
            init();
        }

        public  Boolean insert(ENUsedBook usedBook)
        {
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO Used_Books (idUbooks, books, name,  quantity) "
                    + "VALUES (@idUbooks, @books, @name, @quantity)", connection);

                cmd.Parameters.Add(new SqlParameter("@idUbooks", usedBook.IdUBook));               
                cmd.Parameters.Add(new SqlParameter("@name", usedBook.Name));
                cmd.Parameters.Add(new SqlParameter("@quantity", usedBook.Quantity));
                cmd.Parameters.Add(new SqlParameter("@books", usedBook.UsedBook));

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

        public  Boolean update(ENUsedBook usedBook)
        {
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Used_Books SET books=@books, name=@name, " +
                "quantity=@quantity) WHERE idUBooks = @id", connection);
                cmd.Parameters.Add(new SqlParameter("@id", usedBook.IdUBook)); 
                cmd.Parameters.Add(new SqlParameter("@books", usedBook.Book));               
                cmd.Parameters.Add(new SqlParameter("@name", usedBook.Name));
                cmd.Parameters.Add(new SqlParameter("@quantity", usedBook.Quantity));
                

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

        public  Boolean delete(ENUsedBook usedBook)
        {
            try
            {
                connect();
                connection = new SqlConnection(sqlConnectionString);
                SqlCommand cmd = new SqlCommand("DELETE FROM Used_Books WHERE idUBooks=@idbooks", connection);
                cmd.Parameters.Add(new SqlParameter("@idbooks",usedBook.IdUBook));
                if (cmd.ExecuteNonQuery() == 1)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            finally
            {
                disconnect();
            }
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
