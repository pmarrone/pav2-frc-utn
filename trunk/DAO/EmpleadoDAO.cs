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
    /// <summary>
    /// 
    /// </summary>
    /// <Date></Date>
    /// <Author>hcmoreno</Author>
    public class EmpleadoDAO
    {
        public static String CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MueblesDB"].ConnectionString;
        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pCU_ClientesBE">CU_ClientesBE</param>
        /// <returns>void</returns>
        /// <Date>2011-07-15T15:15:05</Date>
        /// <Author>hcmoreno</Author>
        public static int Insert(Empleado pEmpleado)
        {
            SqlConnection connection = null;

            SqlCommand cmd = new SqlCommand();
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "insert into empleados(legajo, dni,fecha_ingreso, nombres, apellidos) OUTPUT Inserted.legajo "
                    + "values(@legajo, @dni,@fecha_ingreso, @nombres, @apellidos)";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@legajo", pEmpleado.Legajo);
                cmd.Parameters.AddWithValue("@dni", pEmpleado.NroDoc);
                cmd.Parameters.AddWithValue("@fecha_ingreso", pEmpleado.FechaAlta);
                cmd.Parameters.AddWithValue("@nombres", pEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", pEmpleado.Apellido);

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
        public static void Update(Empleado pEmpleado)
        {
            SqlConnection connection = null;
            String strCnn;
            SqlCommand cmd = new SqlCommand();

            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);

                String sql = "update empleados set dni =@dni, fecha_ingreso = @fecha_ingreso, nombres = @nombres, "
                    + "apellidos = @apellidos where legajo=@legajo";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@legajo", pEmpleado.Legajo);
                cmd.Parameters.AddWithValue("@dni", pEmpleado.NroDoc);
                cmd.Parameters.AddWithValue("@fecha_ingreso", pEmpleado.FechaAlta);
                cmd.Parameters.AddWithValue("@nombres", pEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", pEmpleado.Apellido);

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
        public static void Delete(Empleado pEmpleado)
        {
            SqlConnection connection = null;
            String strCnn;
            SqlCommand cmd = new SqlCommand();
            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);

                String sql = "delete from empleados where legajo=@legajo";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@legajo", pEmpleado.Legajo);

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
        public static List<Empleado> GetAll()
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select legajo, dni, fecha_ingreso, nombres, apellidos from empleados";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                connection.Open();
                reader = cmd.ExecuteReader();

                List<Empleado> empleados = new List<Empleado>();
                while (reader.Read())
                {
                    Empleado oEmpleado = new Empleado();
                    oEmpleado.Legajo = (Int32)reader["legajo"];
                    oEmpleado.Nombre = (String)reader["nombres"];
                    oEmpleado.Apellido = (String)reader["apellidos"];
                    oEmpleado.FechaAlta = (DateTime)reader["fecha_ingreso"];
                    oEmpleado.NroDoc = Convert.ToInt32(reader["dni"]);

                    empleados.Add(oEmpleado);
                }

                return empleados;
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


        public static Empleado GetById(int id)
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();
            
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select legajo, dni, fecha_ingreso, nombres, apellidos from empleados where legajo = @legajo";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@legajo", id);

                connection.Open();
                reader = cmd.ExecuteReader();
                
                Empleado empleado = null;
                if (reader.Read())               
                {
                    empleado = new Empleado();
                    empleado.Legajo = (Int32)reader["legajo"];
                    empleado.Nombre = (String)reader["nombres"];
                    empleado.Apellido = (String)reader["apellidos"];
                    empleado.FechaAlta = (DateTime)reader["fecha_ingreso"];
                    empleado.NroDoc = Convert.ToInt32(reader["dni"]);
                }
                return empleado;
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