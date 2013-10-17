using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class Empleado
    {

        #region -- Atributos --

        int legajo;
        int nroDoc;
        DateTime fechaNac; 
        DateTime fechaAlta; 
        DateTime fechaBaja;
        string apellido; 
        String nombre;
        Usuario usuario;

        #endregion

        #region -- Propiedades --

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public int NroDoc
        {
            get { return nroDoc; }
            set { nroDoc = value; }
        }
        public DateTime FechaBaja
        {
            get { return fechaBaja; }
            set { fechaBaja = value; }
        }

        public DateTime FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        public DateTime FechaNac
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