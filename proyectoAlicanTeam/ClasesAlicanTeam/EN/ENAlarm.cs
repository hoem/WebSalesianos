using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;

namespace ClasesAlicanTeam.EN
{
    public class ENAlarm
    {
        private CADAlarm cad;
        private int idAlarms;
        private String message;

        /// <summary>
        /// Constructor por defecto que inicializa el objeto con sus campos vacíos.
        /// </summary>
        public ENAlarm()
        {
            cad = new CADAlarm();
        }

        /// <summary>
        /// Constructor sobrecargado que inicializa el objeto, con el id y mensaje que se la pasa por parámetro.
        /// </summary>
        /// <param name="idAlarms">Identificador de la alarma.</param>
        /// <param name="message">Mensaje de la alarma.</param>
        public ENAlarm(String message)
        {
            this.message = message;
            cad = new CADAlarm();
        }

        #region
        /// <summary>
        /// Devuelve y establece el identificador de la alarma.
        /// </summary>
        public int IdAlarms
        {
            get { return idAlarms; }
            set { idAlarms = value; }
        }

        /// <summary>
        /// Devuelve y establece el mensaje de la alarma.
        /// </summary>
        public String Message
        {
            get { return message; }
            set { message = value; }
        }
        #endregion

        /// <summary>
        /// Inserta la alarma que se le pasa por parámetro en la base de datos.
        /// </summary>
        /// <param name="alarm">ENAlarm que se insertará en la base de datos.</param>
        /// <returns>Retorna el valor true en caso de que se haya insertado en la base de datos, false en caso contrario.</returns>
        public Boolean insert()
        {
            try
            {
                return cad.insert(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza la alarma que se le pasa por parámetro en la base de datos.
        /// </summary>
        /// <param name="alarm">ENAlarm que se modificará en la base de datos.</param>
        /// <returns>Retorna el valor true en caso de que se haya modificado en la base de datos, false en caso contrario.</returns>
        public Boolean update()
        {
            try
            {
                return cad.update(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina la alarma que se le pasa por parámentro en la base de datos.
        /// </summary>
        /// <param name="alarm">ENAlarm que se eliminará en la base de datos.</param>
        /// <returns>Retorna el valor true en caso de que se haya eliminado en la base de datos, false en caso contrario.</returns>
        public Boolean delete()
        {
            try
            {
                return cad.delete(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca la alarma en la base de datos y lo devuelve.
        /// </summary>
        /// <param name="idAlarm">Identificador de la alarma a buscar.</param>
        /// <returns>ENAlarm de la alarma encontrada en la base de datos.</returns>
        public ENAlarm read(int idAlarm)
        {
            return cad.read(idAlarm);
        }

        /// <summary>
        /// Devuelve todas las alarmas que existen en la base de datos.
        /// </summary>
        /// <returns>IList de ENAlarm con todas las alarmas de la base de datos.</returns>
        public List<ENAlarm> readAll()
        {
            return cad.readAll();
        }
    }
}
