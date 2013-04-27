using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ClasesAlicanTeam.EN;
using System.Data;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.CAD
{
    public class CADYearsHasBooks : ICAD
    {


        public CADYearsHasBooks()
        {
            init();
        }

        public  Boolean insert(ENYearHasBooks fila)
        {

            try
            {

                connect();


                SqlCommand cmd = new SqlCommand("INSERT INTO Books_Has_Years (Years, Books) VALUES (@Year, @book)", connection);
                cmd.Parameters.Add(new SqlParameter("@Year", fila.Book.IDBook));
                cmd.Parameters.Add(new SqlParameter("@book", fila.Year.Year));


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

        public  bool update(ENYearHasBooks newFila, ENYearHasBooks oldFila)
        {

            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Books_Has_Years SET years=@newYears, books=@newBooks WHERE years=@oldYears AND books = @oldBooks)", connection);

                cmd.Parameters.Add(new SqlParameter("@newYears", newFila.Year.Year));
                cmd.Parameters.Add(new SqlParameter("@newBooks", newFila.Book.IDBook));
                cmd.Parameters.Add(new SqlParameter("@oldYears", oldFila.Year.Year));
                cmd.Parameters.Add(new SqlParameter("@oldBooks", oldFila.Book.IDBook));

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

        public  bool delete(ENYearHasBooks fila)
        {

            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Books_Has_Years WHERE Years=@Years AND Books=@Books", connection);

                cmd.Parameters.Add(new SqlParameter("@Years", fila.Year.Year));
                cmd.Parameters.Add(new SqlParameter("@Books", fila.Book.IDBook));
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

        public  object read(object x)
        {
            return true;
        }

        public  List<object> readAll()
        {
            return null;
        }


        public List<ENYear> readBook(ENBook oldBook)
        {
            List<ENYear> years = new List<ENYear>();


            try
            {



                connect();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Books_Has_Years WHERE books=@idbooks)", connection);

                cmd.Parameters.Add(new SqlParameter("@idbooks", oldBook.IDBook));
                SqlDataReader dr = cmd.ExecuteReader();
                
                
                while (dr.Read())
                {
                    ENYear fila = new ENYear();
                    fila.Year = dr.GetInt16(0);
                    years.Add(fila);
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

        public List<ENBook> readYear(ENYear oldYear)
        {
            List<ENBook> books = new List<ENBook>();



            try
            {


                connect();



                SqlCommand cmd = new SqlCommand("SELECT * FROM Books_Has_Years WHERE years=@years)", connection);
                cmd.Parameters.Add(new SqlParameter("@years", oldYear.Year));
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    ENBook fila = new ENBook();
                    fila.IDBook = dr.GetString(0);
                    books.Add(fila);
                }


                return books;
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
