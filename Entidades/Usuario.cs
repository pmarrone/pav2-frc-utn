using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class Usuario
    {
        #region -- Atributos --

        string id_usuario;
        Int64 id_rol;
        string hashed_password;
        Int64? id_cliente;
        Int64? legajo;
        #endregion

        #region -- Propiedades --

        public string Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public Int64 Id_rol
        {
            get { return id_rol; }
            set { id_rol = value; }
        }

        public string Hashed_password
        {
            get { return hashed_password; }
            set { hashed_password = value; }
        }

        public Int64? Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        public Int64? Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }
        #endregion

        #region -- Constructores --

        public Usuario()
        { }

        public Usuario(string id_usuario, Int64 id_rol)
        {
            this.id_usuario = id_usuario;
            this.id_rol = id_rol;
        }

        #endregion


    }
}