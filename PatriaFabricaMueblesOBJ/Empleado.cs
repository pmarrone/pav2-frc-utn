using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class Empleado
    {

#region -- Atributos --

        int legajo, nroDoc;
        DateTime fechaNac, fechaAlta, fechaBaja;
        string apellido, nombre;
        int idCargo;
        TipoDoc tipoDoc;
        int idUsuario;



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

        public int IdCargo
        {
            get { return idCargo; }
            set { idCargo = value; }
        }

        public TipoDoc TipoDoc
        {
            get { return tipoDoc; }
            set { tipoDoc = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        
#endregion

#region -- Constructores --

        public Empleado()
        { }

        public Empleado(int plegajo, int pnroDoc, DateTime pfechaNac, DateTime pfechaAlta, DateTime pfechaBaja, string papellido, string pnombre, Cargo pidCargo, TipoDoc ptipoDoc, Usuario pidUsuario)
        {
            legajo = plegajo;
            nroDoc = pnroDoc;
            fechaNac = pfechaNac;
            fechaAlta = pfechaAlta;
            fechaBaja = pfechaBaja;
            apellido = papellido;
            nombre = pnombre;
            idCargo = pidCargo;
            tipoDoc = ptipoDoc;
            idUsuario = pidUsuario;
        }

#endregion

        }
        

    }