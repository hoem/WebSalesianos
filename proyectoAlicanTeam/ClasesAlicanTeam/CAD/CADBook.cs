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

    public class CADBook : ICAD
    {
        private String sqlConnectionString;

        public CADBook() 
        {
            init();
        }

        public  Boolean insert(ENBook book)
        {
            
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO Books (idbooks, subjects, courses, cif, years, name, quantity, description ) "
                    + "VALUES (@id,@subject,@course, @cif, @year, @name, @quantity, @description)", connection);
                
                cmd.Parameters.Add(new SqlParameter("@id", book.IDBook));
                cmd.Parameters.Add(new SqlParameter("@subject", book.Subject));
                cmd.Parameters.Add(new SqlParameter("@course", book.Course));
                cmd.Parameters.Add(new SqlParameter("@cif", book.CIF));
                cmd.Parameters.Add(new SqlParameter("@year", book.Years));
                cmd.Parameters.Add(new SqlParameter("@name", book.Name));
                cmd.Parameters.Add(new SqlParameter("@quantity", book.Quantity));
                cmd.Parameters.Add(new SqlParameter("@description", book.Description));
                
                if (cmd.ExecuteNonQuery() == 1)//este comando sirve para ejecutar la sentencia
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

        public  Boolean update(ENBook book)
        {
            
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Books SET subjects= @subjects, courses=@courses, cif=@cif, "+
                "years=@years, name=@name, quantity=@quantity, description=@description WHERE idBooks=@idbooks)", connection);
                
                cmd.Parameters.Add(new SqlParameter("@subjects", book.Subject));
                cmd.Parameters.Add(new SqlParameter("@courses", book.Course));
                cmd.Parameters.Add(new SqlParameter("@cif", book.CIF));
                cmd.Parameters.Add(new SqlParameter("@years", book.Years));
                cmd.Parameters.Add(new SqlParameter("@name", book.Name));
                cmd.Parameters.Add(new SqlParameter("@quantity", book.Quantity));
                cmd.Parameters.Add(new SqlParameter("@description", book.Description));
                cmd.Parameters.Add(new SqlParameter("@idbooks", book.IDBook));
                
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

        public  Boolean delete(ENBook book)
        {
            

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE idbooks=@idbooks", connection);
                cmd.Parameters.Add(new SqlParameter("@idbooks", book.IDBook));
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
                connection.Close();
            }
        }

        public  ENBook read(String id)
        {
            
            try
            {

                connect();


                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE idBooks=@id", connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENBook book = new ENBook();
                book.IDBook = dr["idBooks"].ToString(); //devuelve un objeto EN que tendra todos sus datos
                book.Subject.Name = dr["Subjects"].ToString();
                book.Course.Courses = dr["Courses"].ToString();
                book.CIF = dr["CIF"].ToString();
                //book.Years = new ENYear(int.Parse(dr["Years"].ToString()));
                book.Name = dr["Name"].ToString();
                //book.Quantity = int.Parse(dr["Quantity"].ToString());
                book.Description = dr["Description"].ToString();
                book.Image = dr["Picture"].ToString();

                dr.Close();

                return book;
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

        public  List<ENBook> readAll()
        {
            List<ENBook> libros = new List<ENBook>();
            
            try
            {
                connect();
                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Books", connection);
                adaptador.Fill(ds, "Books");

                dt = ds.Tables["Books"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENBook book = new ENBook();
                    book.IDBook = dt.Rows[i][0].ToString();
                    book.Subject.Name = dt.Rows[i][1].ToString();
                    book.Course.Courses = dt.Rows[i][2].ToString();
                    book.CIF = dt.Rows[i][3].ToString();

                    //book.Years =  new ENYear(int.Parse( dt.Rows[i][4].ToString()));
                    book.Name = dt.Rows[i][4].ToString();
                    //book.Quantity = int.Parse(dt.Rows[i][6].ToString());
                    book.Description = dt.Rows[i][5].ToString();
                    
                    libros.Add(book);
                }

                return libros;
            }catch(Exception ex){
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        
    }
}
