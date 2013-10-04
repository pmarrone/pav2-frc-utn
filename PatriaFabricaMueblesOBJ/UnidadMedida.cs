using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class UnidadMedida
    {
        #region -- Atributos --
        int udMedida;
        string nombre;
        
        #endregion

        #region -- Propiedades --

        public int UdMedida
        {
            get { return udMedida; }
            set { udMedida = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion

        #region -- Constructores --

        public UnidadMedida()
        { }

        public UnidadMedida(int pudMedida, string pnombre)
        {
            udMedida = pudMedida;
            nombre = pnombre;
        }
        
        #endregion
    }
}