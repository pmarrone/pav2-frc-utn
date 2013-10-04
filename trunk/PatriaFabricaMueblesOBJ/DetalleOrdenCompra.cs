using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class DetalleOrdenCompra
    {

        #region -- Atributos --

        int idDetOrdenCpra, cantidad;
        OrdenCompra idOrdenCpra;
        Material idMaterial;
        float precioUnit;

        #endregion

        #region -- Propiedades --

        public int IdDetOrdenCpra
        {
            get { return idDetOrdenCpra; }
            set { idDetOrdenCpra = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public OrdenCompra IdOrdenCpra
        {
            get { return idOrdenCpra; }
            set { idOrdenCpra = value; }
        }

        public Material IdMaterial
        {
            get { return idMaterial; }
            set { idMaterial = value; }
        }

        public float PrecioUnit
        {
            get { return precioUnit; }
            set { precioUnit = value; }
        }

        #endregion

        #region -- Constructores --

        public DetalleOrdenCompra()
        { }

        public DetalleOrdenCompra(int pidDetOC, int pcant, OrdenCompra pidOCpra, Material pidMaterial, float ppcioU)
        {
            idDetOrdenCpra = pidDetOC;
            cantidad = pcant;
            idMaterial = pidMaterial;
            precioUnit = ppcioU;
        }
        
        #endregion

    }
}