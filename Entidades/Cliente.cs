using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class Cliente
    {
        #region -- Atributos --

        int idCliente, telefono;
        string nombres, apellidos;
        Usuario idUsuario;

        #endregion

        #region -- Propiedades --
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public Usuario IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        #endregion

        #region -- Constructores --

        public Cliente()
        { }

        public Cliente(int pidCliente, int ptelefono, string pnombres, string papellidos, Usuario pidUsuario)
        {
            idCliente = pidCliente;
            telefono = ptelefono;
            nombres = pnombres;
            apellidos = papellidos;
            idUsuario = pidUsuario;
        }
        
        #endregion


    }
}