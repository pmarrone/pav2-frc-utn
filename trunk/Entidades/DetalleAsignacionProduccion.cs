using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class DetalleAsignacionProduccion
    {
        #region -- Atributos --

        AsignacionProduccion idAsignacion;
        int idDetAsignacion, horasEstimadas;
        DetallePedidoProduccion idDetPedProd;

        #endregion

        #region -- Propiedades --

        public AsignacionProduccion IdAsignacion
        {
            get { return idAsignacion; }
            set { idAsignacion = value; }
        }

        public int IdDetAsignacion
        {
            get { return idDetAsignacion; }
            set { idDetAsignacion = value; }
        }

        public int HorasEstimadas
        {
            get { return horasEstimadas; }
            set { horasEstimadas = value; }
        }

        public DetallePedidoProduccion IdDetPedProd
        {
            get { return idDetPedProd; }
            set { idDetPedProd = value; }
        }


        #endregion

        #region -- Constructores --

        public DetalleAsignacionProduccion()
        { }

        public DetalleAsignacionProduccion(AsignacionProduccion pidAsign, int pidDetAsign, int phorasEst, DetallePedidoProduccion pidDetPedP)
        {
            idAsignacion = pidAsign;
            idDetAsignacion = pidDetAsign;
            horasEstimadas = phorasEst;
            idDetPedProd = pidDetPedP;
        }

        #endregion

    }
}