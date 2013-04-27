using ClasesAlicanTeam.EN;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ClasesAlicanTeam.CAD
{
    public class CADSubject : ICAD
    {
        public CADSubject()
        {

            init();
        }

        public  Boolean insert(ENSubject subject)
        {


            try
            {

                connect();

                SqlCommand cmd = new SqlCommand("INSERT INTO Subjects (Subjects, Courses) VALUES (@Subjects, @Course)", connection);
                cmd.Parameters.Add(new SqlParameter("@Subjects", subject.Name));
                cmd.Parameters.Add(new SqlParameter("@Courses", subject.Course.Courses));

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

        public  Boolean update(ENSubject oldSubject, ENSubject newSubject)
        {


            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("UPDATE ON CASCADE Subjects SET Subjects=@newSubjects, Courses=@newCourses WHERE Subjects=@oldSubjects AND Courses=@oldCourses)", connection);

                cmd.Parameters.Add(new SqlParameter("@oldSubjects", oldSubject.Course.Courses ));
                cmd.Parameters.Add(new SqlParameter("@oldCourses", oldSubject.Course.Courses));
                cmd.Parameters.Add(new SqlParameter("@newSubjects", newSubject.Course.Courses));
                cmd.Parameters.Add(new SqlParameter("@newCourses", newSubject.Course.Courses));
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

        public  Boolean delete(ENSubject subject)
        {


            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Subjects WHERE Subjects=@Subjects AND Courses=@Courses", connection);

                cmd.Parameters.Add(new SqlParameter("@Subjects", subject.Name));
                cmd.Parameters.Add(new SqlParameter("@Courses", subject.Course.Courses));
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

        public  Object read(ENSubject subject)
        {
            return true;
        }

        public  List<object> readAll()
        {
            return null;
        }
    }
}
