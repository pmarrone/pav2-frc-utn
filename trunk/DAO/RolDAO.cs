using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using PatriaFabricaMuebles.Entidades;

namespace PatriaFabricaMuebles.DAO
{
    public class RolDAO
    {
        public static String CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MueblesDB"].ConnectionString;
        /// <summary>
        /// Insert
        /// </summary>      
        /// <Author>hcmoreno</Author>
        public static int Insert(Rol pRol)
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);


                String sql = "insert into roles(id_rol,descripcion) OUTPUT Inserted.id_rol "
                    + "values(@id_rol, @descripcion)";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_rol", pRol.IdRol);
                cmd.Parameters.AddWithValue("@descripcion", pRol.Descrip);        


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
        public static void Update(Rol pRol)
        {
            SqlConnection connection = null;
            String strCnn;
            SqlCommand cmd = new SqlCommand();

            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);

                String sql = "update roles set descripcion = @descripcion "
                    + "where id_rol=@id_rol";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_rol", pRol.IdRol);
                cmd.Parameters.AddWithValue("@descripcion", pRol.Descrip);  


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
        public static void Delete(Rol pRol)
        {
            SqlConnection connection = null;
            String strCnn;
            SqlCommand cmd = new SqlCommand();
            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);

                String sql = "delete from roles where id_rol=@id_rol";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_rol", pRol.IdRol);
              
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
        public static List<Rol> GetAll()
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select id_rol, descripcion from roles";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                connection.Open();
                reader = cmd.ExecuteReader();

                List<Rol> roles = new List<Rol>();
                while (reader.Read())
                {
                    Rol oRol = new Rol();
                    oRol.IdRol = (Int32)reader["id_rol"];
                    oRol.Descrip = (String)reader["descripcion"];
                 
                    roles.Add(oRol);
                }

                return roles;
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


        public static Rol GetById(int id)
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select id_rol, descripcion from roles where id_rol = @id_rol";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_rol", id);
      

                connection.Open();
                reader = cmd.ExecuteReader();

                Rol Rol = null;
                if (reader.Read())
                {
                    Rol = new Rol();
                    Rol.IdRol = (Int32)reader["id_rol"];
                    Rol.Descrip = (String)reader["descripcion"];             
                }
                return Rol;
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
