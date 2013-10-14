using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using PatriaFabricaMuebles.Entidades;

namespace PatriaFabricaMuebles.DAO
{
    public class ClienteDAO
    {
        public static String CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MueblesDB"].ConnectionString;
        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pCU_ClientesBE">CU_ClientesBE</param>
        /// <returns>void</returns>
        /// <Date>2011-07-15T15:15:05</Date>
        /// <Author>hcmoreno</Author>
        public static int Insert(Cliente pCliente)
        {
            SqlConnection connection = null;

            SqlCommand cmd = new SqlCommand();
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);


                String sql = "insert into clientes(id_Cliente,telefono,nombres, apellidos) OUTPUT Inserted.Id_Cliente "
                    + "values(@id_Cliente, @telefono,@nombres, @apellidos)";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_Cliente", pCliente.IdCliente);
                cmd.Parameters.AddWithValue("@telefono", pCliente.Telefono);
                cmd.Parameters.AddWithValue("@nombres", pCliente.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", pCliente.Apellidos);
               

                connection.Open();
                int id = (int)cmd.ExecuteScalar();
                return id;
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
        public static void Update(Cliente pCliente)
        {
            SqlConnection connection = null;
            String strCnn;
            SqlCommand cmd = new SqlCommand();

            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);

                String sql = "update clientes set telefono =@telefono, nombres = @nombres, apellidos = @apellidos "
                    + "where id_Cliente=@id_Cliente";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_Cliente", pCliente.IdCliente);
                cmd.Parameters.AddWithValue("@telefono", pCliente.Telefono);
                cmd.Parameters.AddWithValue("@nombres", pCliente.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", pCliente.Apellidos);
                

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
        public static void Delete(Cliente pCliente)
        {
            SqlConnection connection = null;
            String strCnn;
            SqlCommand cmd = new SqlCommand();
            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);

                String sql = "delete from clientes where id_Cliente=@id_Cliente";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_Cliente", pCliente.IdCliente);

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
        /// GetAll
        /// </summary>
        /// <Author>hcmoreno</Author>
        public static List<Cliente> GetAll()
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select id_Cliente, telefono, nombres, apellidos from clientes";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                connection.Open();
                reader = cmd.ExecuteReader();

                List<Cliente> clientes = new List<Cliente>();
                while (reader.Read())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.IdCliente = (Int32)reader["id_Cliente"];
                    oCliente.Nombres = (String)reader["nombres"];
                    oCliente.Apellidos = (String)reader["apellidos"];
                    oCliente.Telefono = Convert.ToInt32(reader["telefono"]);                

                    clientes.Add(oCliente);
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
                reader.Close();
            }
        }


        public static Cliente GetById(int id)
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select id_Cliente, telefono, nombres, nombres, apellidos from clientes where id_Cliente = @id_Cliente";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_Cliente", id);

                connection.Open();
                reader = cmd.ExecuteReader();

                Cliente Cliente = null;
                if (reader.Read())
                {
                    Cliente = new Cliente();
                    Cliente.IdCliente = (Int32)reader["id_Cliente"];
                    Cliente.Nombres = (String)reader["nombres"];
                    Cliente.Apellidos = (String)reader["apellidos"];
                    Cliente.Telefono = Convert.ToInt32(reader["telefono"]);                    
                }
                return Cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
                reader.Close();
            }
        }
    }
}
