using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class Permiso
    {

#region -- Atributos --

        int idPermiso;
        string descrip;

#endregion

#region -- Propiedades --

        public int IdPermiso
        {
            get { return idPermiso; }
            set { idPermiso = value; }
        }

        public string Descrip
        {
            get { return descrip; }
            set { descrip = value; }
        }

#endregion

#region -- Constructores --
        public Permiso()
        { }

        public Permiso(int pidPermiso, string pdescrip)
        {
            idPermiso = pidPermiso;
            descrip = pdescrip;
        }

#endregion

    }
}