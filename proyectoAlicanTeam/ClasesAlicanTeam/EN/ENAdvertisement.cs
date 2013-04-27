using ClasesAlicanTeam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesAlicanTeam.EN
{
    public class ENAdvertisement
    {
        private CADAdvertisement cad;
        private int idAdvertisement;
        private ENCustomer customer;
        private String description;
        private String picture;

        /// <summary>
        /// Constructor por defecto que inicializa el objeto con sus campos vacíos.
        /// </summary>
        public ENAdvertisement()
        {
            cad = new CADAdvertisement();
            customer = new ENCustomer();
        }

        /// <summary>
        /// Constructor sobrecargado que inicializa el objeto asignando los campos que se le pasan por parámetro.
        /// </summary>
        /// <param name="idAdvertisement">Identificador del anuncio.</param>
        /// <param name="customer">ENCustomer que ha creado el anuncio.</param>
        /// <param name="description">Descripcion del anuncio.</param>
        /// <param name="picture">Ruta a la imagen del anuncio.</param>
        public ENAdvertisement(int idAdvertisement, ENCustomer customer, String description, String picture)
        {
            this.idAdvertisement = idAdvertisement;
            this.customer = customer;
            this.description = description;
            this.picture = picture;
            cad = new CADAdvertisement();
        }

        #region
        /// <summary>
        /// Devuelve y establece el identifiador del anuncio.
        /// </summary>
        public int IdAdvertisement
        {
            get { return idAdvertisement; }
            set { idAdvertisement = value; }
        }

        /// <summary>
        /// Devuelve y establece el ENCustomer del anuncio.
        /// </summary>
        public ENCustomer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        /// <summary>
        /// Devuelve y establece la descripcion del anuncio.
        /// </summary>
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Devuelve y establece la ruta a la imagen del anuncio.
        /// </summary>
        public String Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        #endregion

        /// <summary>
        /// Inserta el anuncio que se le pasa por parámetro en la base de datos.
        /// </summary>
        /// <param name="advertisement">ENAdvertisement que se insertará en la base de datos.</param>
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
        /// Actualiza el anuncio que se le pasa por parámetro.
        /// </summary>
        /// <param name="advertisement">ENAdvertisement que se actualizará en la base de datos.</param>
        /// <returns>Retorna el valor true en caso de que se haya actualizado, false en caso contrario.</returns>
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
        /// Elimina de la base de datos el anuncio que se le pasa por parámetro.
        /// </summary>
        /// <param name="advertisement">ENAdvertisement que se eliminará en la base de datos.</param>
        /// <returns>Retorna el valor true en caso de que se haya eliminado, false en caso contrario.</returns>
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
        /// Busca el anuncio en la base de datos y lo devuelve.
        /// </summary>
        /// <param name="idAdvertisement">Identificador del anuncio a buscar en la base de datos.</param>
        /// <returns>ENAdvertisement del anuncio encontrado en la base de datos.</returns>
        public ENAdvertisement read(int idAdvertisement)
        {
            try
            {
                return cad.read(idAdvertisement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Devuelve todos los anuncios que existen en la base de datos.
        /// </summary>
        /// <returns>IList de ENAdvertisement con todos los anuncios de la base de datos.</returns>
        public List<ENAdvertisement> readAll()
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
