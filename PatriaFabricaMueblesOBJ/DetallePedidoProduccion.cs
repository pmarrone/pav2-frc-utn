using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class DetallePedidoProduccion
    {
        #region -- Atributos --

        int idDetPedProd, cantidad;
        PedidoProduccion idPedidoProd;
        Mueble idMueble;

        #endregion

        #region -- Propiedades --

        public int IdDetPedProd
        {
            get { return idDetPedProd; }
            set { idDetPedProd = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public PedidoProduccion IdPedidoProd
        {
            get { return idPedidoProd; }
            set { idPedidoProd = value; }
        }
 
        public Mueble IdMueble
        {
            get { return idMueble; }
            set { idMueble = value; }
        }

        #endregion

        #region -- Constructores --

        public DetallePedidoProduccion()
        { }

        public DetallePedidoProduccion(int pidDetPedP, int pcant, PedidoProduccion pidPedProd, Mueble pidMue)
        {
            idDetPedProd = pidDetPedP;
            cantidad = pcant;
            idPedidoProd = pidPedProd;
            idMueble = pidMue;
        }

        #endregion
    }
}