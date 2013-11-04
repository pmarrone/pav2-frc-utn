using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class Rol
    {
        #region -- Atributos --

        int id_rol;
        string descripcion;

        #endregion

        #region -- Propiedades --

        public int Id_rol
        {
            get { return id_rol; }
            set { id_rol = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion

        #region -- Constructores --
        public Rol()
        { }

        public Rol(int pidRol, string pdescrip)
        {
            id_rol = pidRol;
            descripcion = pdescrip;
        }

        #endregion

    }
}