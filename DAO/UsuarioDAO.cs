using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PatriaFabricaMuebles.DAO
{
    public class UsuarioDAO
    {
        public static Boolean ValidarUsuario(string id_usuario, string password)
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection = new SqlConnection(ConnectionStringManager.ConnectionString);
                String sql = "select * from Usuarios where id_usuario = @id_usuario and hashed_password = @hashed_password";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                //XXX: Falta hashear el password
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                cmd.Parameters.AddWithValue("@hashed_password", password);

                connection.Open();
                reader = cmd.ExecuteReader();

                return reader.HasRows;
            }
            catch
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
                reader.Close();
            }
        }

        public static string[] ObtenerRoles(string usuario)
        {
            switch (usuario.ToLower())
            {
                case "admin":
                    return new string[] { "administradores" }; //permite ingresar a la pagina de registro de usuarios, es a modo ejemplo
                case "empleado":
                    return new string[] { "empleados" }; //solo ingresa a la pagina default
                default:
                    return new string[] { "clientes" }; //solo ingresa a la pagina default
            }
        }


    }
}
