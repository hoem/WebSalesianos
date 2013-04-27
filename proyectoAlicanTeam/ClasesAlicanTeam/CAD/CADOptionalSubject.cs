using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.EN;

namespace ClasesAlicanTeam.CAD
{
    public class CADOptionalSubject : CADSubject
    {
        
        public CADOptionalSubject()
        {
  
            init();
        }

        public  Boolean insert(ENOptionalSubject subject)
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

        public  Boolean update(ENOptionalSubject oldSubject, ENOptionalSubject newSubject)
        {


            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Subjects SET Subjects=@newSubjects, Courses=@newCourses WHERE Subjects=@oldSubjects AND Courses=@oldCourses)", connection);

                
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

        public  Boolean delete(ENOptionalSubject subject)
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

        public  Boolean read(int a)
        {
            return true;
        }

        public  List<ENOptionalSubject> readAll()
        {
            return null;
        }
    }
}
