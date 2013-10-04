using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class Rol
    {
        #region -- Atributos --

        int idRol;
        string descrip;

        #endregion

        #region -- Propiedades --

        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }

        public string Descrip
        {
            get { return descrip; }
            set { descrip = value; }
        }

        #endregion

        #region -- Constructores --
        public Rol()
        { }

        public Rol(int pidRol, string pdescrip)
        {
            idRol = pidRol;
            descrip = pdescrip;
        }

        #endregion

    }
}