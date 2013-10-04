using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using PatriaFabricaMueblesOBJ;
using System.Configuration;
using System.Collections.Generic;

namespace UTN.FabricaMuebles.BackEnd.DataAccessComponents
{
    /// <summary>
    /// 
    /// </summary>
    /// <Date></Date>
    /// <Author>hcmoreno</Author>
    public class EmpleadoDAC
    {
        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pCU_ClientesBE">CU_ClientesBE</param>
        /// <returns>void</returns>
        /// <Date>2011-07-15T15:15:05</Date>
        /// <Author>hcmoreno</Author>
        public static void Insert(Empleado pEmpleado)
        {
            SqlConnection connection = null;
            String connectionString;

            SqlCommand cmd = new SqlCommand();
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString;
                connection = new SqlConnection(connectionString);

                String sql = "insert into empleados(dni,id_cargo,fecha_ingreso, nombres,id_usuario, apellidos) "
                    + "values(@dni,@id_cargo,@fecha_ingreso, @nombres,@id_usuario, @apellidos)";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("@legajo", pEmpleadoBE.legajo); tipo identity
                cmd.Parameters.AddWithValue("@dni", pEmpleado.NroDoc);
                cmd.Parameters.AddWithValue("@id_cargo", pEmpleado.IdCargo);
                cmd.Parameters.AddWithValue("@fecha_ingreso", pEmpleado.FechaAlta);
                cmd.Parameters.AddWithValue("@nombres", pEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@id_usuario", pEmpleado.IdUsuario);
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
                strCnn = ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString;
                connection = new SqlConnection(strCnn);

                String sql = "update empleados set dni =@dni,id_cargo = @id_cargo,fecha_ingreso = @fecha_ingreso, nombres = @nombres,id_usuario = @id_usuario, "
                    + "apellidos = @apellidos where legajo=@legajo";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@legajo", pEmpleado.Legajo);
                cmd.Parameters.AddWithValue("@dni", pEmpleado.NroDoc);
                cmd.Parameters.AddWithValue("@id_cargo", pEmpleado.IdCargo);
                cmd.Parameters.AddWithValue("@fecha_ingreso", pEmpleado.FechaAlta);
                cmd.Parameters.AddWithValue("@nombres", pEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@id_usuario", pEmpleado.IdUsuario);
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
                strCnn = ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString;
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
            String strCnn;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                strCnn = ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString;
                connection = new SqlConnection(strCnn);

                String sql = "select legajo,dni,id_cargo,fecha_ingreso,nombres,id_usuario,apellidos from empleados";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                connection.Open();


                List<Empleado> empleados = new List<Empleado>();
                while (reader.Read())
                {
                    Empleado oEmpleado = new Empleado();
                    oEmpleado.Legajo = (Int32)reader["legajo"];
                    oEmpleado.Nombre = (String)reader["nombres"];
                    oEmpleado.Apellido = (String)reader["apellidos"];
                    oEmpleado.FechaAlta = (DateTime)reader["fecha_ingreso"];
                    oEmpleado.IdCargo = (Int32)reader["id_cargo"];
                    oEmpleado.IdUsuario = (Int32)reader["id_usuario"];
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

    }
}