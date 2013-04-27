using ClasesAlicanTeam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.EN
{
    public class ENCourse
    {
        private CADCourse cad;
        private String courses;

        /// <summary>
        /// Constructor por defecto que inicializa el objeto con sus campos vacíos.
        /// </summary>
        public ENCourse()
        {
            cad = new CADCourse();
        }

        /// <summary>
        /// Constructor sobrecargado que inicializa el objeto con los cursos que se le pasan por parámetro.
        /// </summary>
        /// <param name="courses">Nombre de los cursos.</param>
        public ENCourse(String courses)
        {
            this.courses = courses;
            cad = new CADCourse();
        }

        #region
        /// <summary>
        /// Devuelve y establece el nombre del curso.
        /// </summary>
        public String Courses
        {
            get { return courses; }
            set { courses = value; }
        }
        #endregion

        /// <summary>
        /// Inserta el curso que se le pasa por parámetro en la base de datos.
        /// </summary>
        /// <param name="course">ENCourse que se insertará en la base de datos.</param>
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
        /// Actualiza el curso que se le pasa por parámetro.
        /// </summary>
        /// <param name="course">ENCourse que se actualizará en la base de datos.</param>
        /// <returns>Retorna el valor true en caso de que se haya modificado en la base de datos, false en caso contrario</returns>
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
        /// Elimina de la base de datos el curso que se le pasa por parámentro.
        /// </summary>
        /// <param name="course">ENCourse que se eliminará en la base de datos.</param>
        /// <returns>Retorna el valor true en caso de que se haya eliminado de la base de datos, false en caso contrario.</returns>
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
        /// Busca el curso en la base de datos y lo devuelve.
        /// </summary>
        /// <param name="courses">String del curso a buscar en la base de datos.</param>
        /// <returns>ENCourse del curso encontrado en la base de datos.</returns>
        public ENCourse read(String courses)
        {
            try
            {
                return cad.read(courses);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Devuelve todos los cursos que existen en la base de datos.
        /// </summary>
        /// <returns>IList de ENCourse con todos los cursos almacenados en la base de datos.</returns>
        public List<ENCourse> readAll()
        {
            try
            {
                return cad.readAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
