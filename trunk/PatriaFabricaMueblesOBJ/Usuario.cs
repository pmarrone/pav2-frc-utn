using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class Usuario
    {
#region -- Atributos --

        int idUsuario;
        int idRol;

#endregion

#region -- Propiedades --

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }
#endregion

#region -- Constructores --

        public Usuario()
        { }

        public Usuario(int pidUsuario, int pidRol)
        {
            idUsuario = pidUsuario;
            idRol = pidRol;
        }

#endregion


    }
}