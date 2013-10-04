using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class AsignacionProduccion
    {
        #region -- Atributos --

        int idAsignacion, duracion, cantidad;
        DateTime fechaHora;
        Empleado legajoEjecutor, legajoEncargadoAsignacion;
        EstadoAsignacion idEstado;

        #endregion

        #region -- Propiedades --

        public int IdAsignacion
        {
            get { return idAsignacion; }
            set { idAsignacion = value; }
        }

        public int Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public Empleado LegajoEjecutor
        {
            get { return legajoEjecutor; }
            set { legajoEjecutor = value; }
        }

        public Empleado LegajoEncargadoAsignacion
        {
            get { return legajoEncargadoAsignacion; }
            set { legajoEncargadoAsignacion = value; }
        }

        public EstadoAsignacion IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }

        #endregion

        #region -- Constructores --

        public AsignacionProduccion()
        { }

        public AsignacionProduccion(int pidAsignacion, int pduracion, int pcantidad, DateTime pfechaHora, 
            Empleado plegajoE, Empleado plegajoEA, EstadoAsignacion pidEstado)
        {
            idAsignacion = pidAsignacion;
            duracion = pduracion;
            cantidad = pcantidad;
            fechaHora = pfechaHora;
            legajoEjecutor = plegajoE;
            legajoEncargadoAsignacion = plegajoEA;
            idEstado = pidEstado;
        }

        #endregion

    }
}