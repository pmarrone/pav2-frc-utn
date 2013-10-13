using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class PedidoProduccion
    {
        #region -- Atributos --
        int idPedidoProd, cantTareas;
        float montoTotal;
        DateTime fechaHora;
        Cliente idCliente;
        Empleado legajo;

        #endregion

        #region -- Propiedades --

        public int IdPedidoProd
        {
            get { return idPedidoProd; }
            set { idPedidoProd = value; }
        }

        public int CantTareas
        {
            get { return cantTareas; }
            set { cantTareas = value; }
        }

        public float MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public Cliente IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public Empleado Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }
        
        #endregion

        #region -- Constructores --

        public PedidoProduccion()
        { }

        public PedidoProduccion(int pidPedidoProd, int pcantTareas, float pmontoTotal, DateTime pfechaHora, Cliente pidCliente, Empleado plegajo)
        {
            idPedidoProd = pidPedidoProd;
            cantTareas = pcantTareas;
            montoTotal = pmontoTotal;
            fechaHora = pfechaHora;
            idCliente = pidCliente;
            legajo = plegajo;
        }


        #endregion

    }
}