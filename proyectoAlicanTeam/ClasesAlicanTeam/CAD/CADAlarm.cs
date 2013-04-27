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
    public class CADAlarm : ICAD
    {
        

        public CADAlarm()
        {
            init();
        }

        public  Boolean insert(ENAlarm alarm)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("INSERT INTO Alarms (Message) " + "VALUES (@Message)", connection);

                //cmd.Parameters.Add(new SqlParameter("@idAlarms", alarm.IdAlarms));
                cmd.Parameters.Add(new SqlParameter("@Message", alarm.Message));
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

        public  Boolean update(ENAlarm alarm)
        {

            try
            {

                connect();
                SqlCommand cmd = new SqlCommand("UPDATE Alarms SET idAlarms=@idAlarms, Message=@Message WHERE idAlarms=@idAlarms)", connection);

                cmd.Parameters.Add(new SqlParameter("@idAlarms", alarm.IdAlarms));
                cmd.Parameters.Add(new SqlParameter("@Message", alarm.Message));                

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

        public  Boolean delete(ENAlarm alarm)
        {

            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("DELETE FROM Alarms WHERE idAlarms=@idAlarms", connection);

                cmd.Parameters.Add(new SqlParameter("@idAlarms", alarm.IdAlarms));
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

        public  ENAlarm read(int idAlarms)
        {

            try
            {

                connect();


                SqlCommand cmd = new SqlCommand("SELECT * FROM Alarms WHERE idAlarms=@idAlarms", connection);
                cmd.Parameters.Add(new SqlParameter("@idAlarms", idAlarms));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                ENAlarm alarm = new ENAlarm();
                alarm.IdAlarms = Convert.ToInt32(dr["idAlarms"]); //devuelve un objeto EN que tendra todos sus datos
                alarm.Message = dr["Message"].ToString();
                
                dr.Close();

                return alarm;
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

        public  List<ENAlarm> readAll()
        {


            try
            {
                List<ENAlarm> lista = new List<ENAlarm>();
                connect();

                DataTable dt = new DataTable();
                SqlDataAdapter adaptador;
                DataSet ds = new DataSet();

                adaptador = new SqlDataAdapter("SELECT * FROM Alarms", connection);
                adaptador.Fill(ds, "Alarms");

                dt = ds.Tables["Alarms"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ENAlarm alarm = new ENAlarm();
                    alarm.IdAlarms = Convert.ToInt32(dt.Rows[i][0]);
                    alarm.Message = dt.Rows[i][1].ToString();
                    lista.Add(alarm);
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

  