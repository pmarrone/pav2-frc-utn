using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PatriaFabricaMuebles.Entidades;

namespace PatriaFabricaMuebles.DAO
{
    public class UsuarioDAO
    {
        //public static String CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MueblesDB"].ConnectionString;

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

            DataSet ds = EmpleadoDAO.GetRolEmpleado(usuario);

            //switch (usuario.ToLower())
            //{
            //    case "admin":
            return new string[] { ds.Tables[0].Rows[0]["descripcion"].ToString() }; //permite ingresar a la pagina de registro de usuarios, es a modo ejemplo
            //    case "empleado":
            //        return new string[] { "empleados" }; //solo ingresa a la pagina default
            //    default:
            //        return new string[] { "clientes" }; //solo ingresa a la pagina default
            //}
        }

        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pCU_ClientesBE">CU_ClientesBE</param>
        /// <returns>void</returns>
        /// <Date>2011-07-15T15:15:05</Date>
        /// <Author>hcmoreno</Author>
        public static int Insert(Usuario pUsuario)
        {
            SqlConnection connection = null;

            SqlCommand cmd = new SqlCommand();
            try
            {






                connection = new SqlConnection(ConnectionStringManager.ConnectionString);

                String sql = "insert into Usuarios(id_usuario, id_rol,hashed_password, id_cliente, legajo) OUTPUT Inserted.legajo "
                    + "values(@id_usuario, @id_rol,@hashed_password, @id_cliente, @legajo)";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_usuario", pUsuario.Id_usuario);
                cmd.Parameters.AddWithValue("@id_rol", pUsuario.Id_rol);
                cmd.Parameters.AddWithValue("@hashed_password", pUsuario.Hashed_password);
                cmd.Parameters.AddWithValue("@id_cliente", pUsuario.Id_cliente != null ? pUsuario.Id_cliente : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@legajo", pUsuario.Legajo);


                connection.Open();
                int idMagico = (int)cmd.ExecuteScalar();
                return idMagico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <returns>void</returns>
        /// <Date></Date>
        /// <Author>hcmoreno</Author>
        public static void Update(Usuario pUsuario)
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                //strCnn = CONNECTION_STRING;
                connection = new SqlConnection(ConnectionStringManager.ConnectionString);

                String sql = "update Usuarios set id_usuario =@id_usuario,id_rol = @id_rol,hashed_password = @hashed_password, id_cliente = @id_cliente, legajo = @legajo "
                    + "where id_usuario=@id_usuario";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_usuario", pUsuario.Id_usuario);
                cmd.Parameters.AddWithValue("@id_rol", pUsuario.Id_rol);
                cmd.Parameters.AddWithValue("@hashed_password", pUsuario.Hashed_password);
                cmd.Parameters.AddWithValue("@id_cliente", pUsuario.Id_cliente != null ? pUsuario.Id_cliente : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@legajo", pUsuario.Legajo);

                connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <returns>void</returns>
        /// <Date></Date>
        /// <Author>hcmoreno</Author>
        public static void Delete(string id_usuario)
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection = new SqlConnection(ConnectionStringManager.ConnectionString);
                String sql = "delete from usuarios where id_usuario=@id_usuario";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }


    }
}
