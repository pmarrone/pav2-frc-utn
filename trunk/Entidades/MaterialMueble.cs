using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class MaterialMueble
    {
        #region -- Atributos --

        Material idMaterial;
        Mueble idMueble;
        int cantidad;

        #endregion

        #region -- Propiedades --

        public Material IdMaterial
        {
            get { return idMaterial; }
            set { idMaterial = value; }
        }

        public Mueble IdMueble
        {
            get { return idMueble; }
            set { idMueble = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        #endregion

        #region -- Constructores --

        public MaterialMueble()
        { }

        public MaterialMueble(Material pidMat, Mueble pidMue, int pcant)
        {
            idMaterial = pidMat;
            idMueble = pidMue;
            cantidad = pcant;
        }

        #endregion
    }
}