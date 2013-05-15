using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesAlicanTeam.CAD;
using System.Data;

namespace ClasesAlicanTeam.EN
{

    public class ENObligatorySubject : ENSubject
    {
        private int idSubject;
        private int idCourse;

        #region//Getters & Setters

        /// <summary>
        /// 
        /// </summary>
        public int IdSubject
        {
            get
            {
                return this.idSubject;
            }
            set
            {
                this.idSubject = value;
            }
        }

        public int IdCourse
        {
            get
            {
                return this.idCourse;
            }
            set
            {
                this.idCourse = value;
            }
        }

        #endregion

        #region//Private Methods

        protected override DataRow ToDataRow
        {
            get
            {
                DataRow ret = cad.GetVoidRow;
                ret["ID"] = this.id;
                ret["idSubject"] = this.idSubject;
                ret["idCourse"] = this.idCourse;
                return ret;
            }
        }

        protected override void FromRow(DataRow Row)
        {
            ENSubject s = base.Read((int)Row["idSubject"]);
            this.id = s.Id;
            this.Name = s.Name;
            //this.IdCourse = s.IdCourse; //Se queja de que no existe!
            throw new NotImplementedException();
            this.idSubject = (int)Row["idSubject"];
            this.idSubject = (int)Row["idSubject"];
        }

        #endregion

        #region//Public Methods
        
        /// <summary>
        /// Constructor por defecto que inicializa el objeto con sus campos vacíos.
        /// </summary>
        public ENObligatorySubject()
            : base()
        {
            cad = new CADObligatorySubject();
            idSubject = 0;
            idCourse = 0;
            
        }

        /// <summary>
        /// Constructor sobrecargado que inicializa el objeto con los datos pasado por parámetro.
        /// </summary>
        /// <param name="idNewBook">Identificador de la clase ENBusiness padre del Distributor.</param>
        public ENObligatorySubject(int idSubject, int idCourse)
            : base()
        {

            cad = new CADObligatorySubject();
            this.idSubject = idSubject;
            this.idCourse = idCourse;
        }


        /// <summary>
        /// Busca la editorial nueva en la base de datos y lo devuelve
        /// </summary>
        /// <param name="id">Identificador del editorial a buscar.</param>
        /// <returns>ENPublisher de la editorial encontrado en la base de datos.</returns>
        public ENObligatorySubject Read(int id)
        {
            ENObligatorySubject ret = new ENObligatorySubject();
            List<object> param = new List<object>();
            param.Add((object)id);
            ret.FromRow(cad.Select(param));
            return ret;
        }

        /// <summary>
        /// Devuelve todos las editoriales nuevas que existen en la base de datos.
        /// </summary>
        /// <returns>Lista de ENPublisher con todos las editoriales nuevas de la base de datos.</returns>
        public List<ENObligatorySubject> ReadAll()
        {
            List<ENObligatorySubject> ret = new List<ENObligatorySubject>();
            DataTable tabla = cad.SelectAll();
            foreach (DataRow rows in tabla.Rows)
            {

                ENObligatorySubject nuevo = new ENObligatorySubject();
                nuevo.FromRow(rows);
                ret.Add(nuevo);

            }
            return ret;
        }

        #endregion
    }
}

