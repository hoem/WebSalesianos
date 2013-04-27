using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.EN;

namespace ClasesAlicanTeam.CAD
{
    public class CADObligatorySubject : CADSubject
    {
                

        public CADObligatorySubject()
        {
  
            init();
        }

        public  Boolean insert(ENObligatorySubject subject)
        {



            try
            {
                connect();


                SqlCommand cmd = new SqlCommand("INSERT INTO Obligatory_Subjects (Subjects, Courses) VALUES (@Subjects, @Course)", connection);
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

        public  Boolean update(ENObligatorySubject oldSubject, ENObligatorySubject newSubject)
        {


            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Subjects SET Obligatory_Subjects=@newSubjects, Courses=@newCourses WHERE Subjects=@oldSubjects AND Courses=@oldCourses)", connection);

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

        public  Boolean delete(ENObligatorySubject subject)
        {


            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Obligatory_Subjects WHERE Subjects=@Subjects AND Courses=@Courses", connection);

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

        public  List<ENObligatorySubject> readAll()
        {
            return null;
        }
    }
}

