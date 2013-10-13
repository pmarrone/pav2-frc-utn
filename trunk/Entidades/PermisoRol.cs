using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class PermisoRol
    {
#region -- Atributos --

        int idRol;
        int idPermiso;
        
#endregion

#region -- Propiedades --

        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }

        public int IdPermiso
        {
            get { return idPermiso; }
            set { idPermiso = value; }
        }

#endregion

#region -- Constructores --

        public PermisoRol()
        { }

        public PermisoRol(int pidRol, int pidPermiso)
        {
            idRol = pidRol;
            idPermiso = pidPermiso;
        }

#endregion
    }
}