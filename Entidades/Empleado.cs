using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class Empleado
    {

        #region -- Atributos --

        Int64? legajo;
        Int64? dni;
        DateTime? fechaNac;
        DateTime? fechaAlta;
        DateTime? fechaBaja;
        string apellido;
        String nombre;
        Usuario usuario;

        #endregion

        #region -- Propiedades --

        public Int64? Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public Int64? Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public DateTime? FechaBaja
        {
            get { return fechaBaja; }
            set { fechaBaja = value; }
        }

        public DateTime? FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        public DateTime? FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        #endregion

        #region -- Constructores --

        public Empleado()
        { }

        #endregion

    }


}