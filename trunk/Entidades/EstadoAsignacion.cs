using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class EstadoAsignacion
    {

#region -- Atributos --
        
        int idEstado;
        string descrip;

#endregion

#region -- Propiedades --
        public int IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }

        public string Descrip
        {
            get { return descrip; }
            set { descrip = value; }
        }

#endregion

#region -- Constructores --

        public EstadoAsignacion()
        { }

        public EstadoAsignacion(int pidEstado, string pdescrip)
        {
            idEstado = pidEstado;
            descrip = pdescrip;
        }

#endregion

    }
}