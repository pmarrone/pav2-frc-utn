using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class Mueble
    {
        #region -- Atributos --

        int idMueble;
        TipoMueble idTipoMueble;
        string denominacion, caracteristicas;
        float costo, precioVta;

        #endregion
        
        #region -- Propiedades --

        public int IdMueble
        {
            get { return idMueble; }
            set { idMueble = value; }
        }

        public TipoMueble IdTipoMueble
        {
            get { return idTipoMueble; }
            set { idTipoMueble = value; }
        }
 
        public string Denominacion
        {
            get { return denominacion; }
            set { denominacion = value; }
        }

        public string Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }
        }
 
        public float Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public float PrecioVta
        {
            get { return precioVta; }
            set { precioVta = value; }
        }
        
        #endregion


        #region -- Constructores --

        public Mueble()
        { }

        public Mueble(int pidMueble, TipoMueble pidTipoM, string pdenom, string pcaract, float pcosto, float ppcioVta)
        {
            idMueble = pidMueble;
            idTipoMueble = pidTipoM;
            denominacion = pdenom;
            caracteristicas = pcaract;
            costo = pcosto;
            precioVta = ppcioVta;
        }

        #endregion

    }
}