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
        public static void Insert(Empleado pEmpleado)
        {
            SqlConnection connection = null;

            SqlCommand cmd = new SqlCommand();
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "insert into empleados(legajo, dni,FechaAlta, nombre, apellido,FechaNac,FechaBaja) "
                    + "values(@legajo, @dni,@FechaAlta, @nombre, @apellido,@FechaNac,@FechaBaja)";



                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@legajo", pEmpleado.Legajo);
                cmd.Parameters.AddWithValue("@dni", pEmpleado.Dni);
                cmd.Parameters.AddWithValue("@FechaAlta", String.Format("{0:yyyyMMdd HH:mm:ss}", pEmpleado.FechaAlta));
                cmd.Parameters.AddWithValue("@FechaNac", String.Format("{0:yyyyMMdd HH:mm:ss}", pEmpleado.FechaNac));
                cmd.Parameters.AddWithValue("@FechaBaja", String.Format("{0:yyyyMMdd HH:mm:ss}", pEmpleado.FechaBaja));
                cmd.Parameters.AddWithValue("@nombre", pEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@apellido", pEmpleado.Apellido);

                connection.Open();
                cmd.ExecuteScalar();


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

                String sql = "update empleados set dni =@dni,FechaNac = @FechaNac,FechaBaja = @FechaBaja, FechaAlta = @FechaAlta, nombre = @nombre, "

                    + "apellido = @apellido where legajo=@legajo";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@legajo", pEmpleado.Legajo);
                cmd.Parameters.AddWithValue("@dni", pEmpleado.Dni);
                cmd.Parameters.AddWithValue("@FechaAlta", pEmpleado.FechaAlta);
                cmd.Parameters.AddWithValue("@FechaNac", pEmpleado.FechaNac != null ? pEmpleado.FechaNac : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaBaja", pEmpleado.FechaBaja != null ? pEmpleado.FechaBaja : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@nombre", pEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@apellido", pEmpleado.Apellido);

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

                String sql = "select nombre, apellido, dni,FechaNac,legajo, FechaAlta,FechaBaja from empleados";


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
                    oEmpleado.Nombre = (String)reader["nombre"];
                    oEmpleado.Apellido = (String)reader["apellido"];
                    oEmpleado.FechaAlta = (DateTime)reader["FechaAlta"];
                    oEmpleado.FechaBaja = reader["FechaBaja"] == DBNull.Value ? Convert.ToDateTime("01/01/2014") : (DateTime)reader["FechaBaja"];
                    oEmpleado.FechaNac = reader["FechaNac"] == DBNull.Value ? Convert.ToDateTime("01/01/2014") : (DateTime)reader["FechaNac"];

                    oEmpleado.Dni = Convert.ToInt32(reader["dni"]);

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
                    empleado.Dni = Convert.ToInt32(reader["dni"]);
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

        /// <summary>
        /// GetAll
        /// </summary>
        /// <Author>hcmoreno</Author>
        public static DataSet GetAllwithUserAndRol()
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select r.descripcion,u.id_rol,u.id_usuario as nombreUser,u.hashed_password,e.legajo,e.dni,e.FechaAlta,e.nombre,e.apellido,e.FechaNac as FechaNac,e.FechaBaja " +
                                 "from Usuarios u,Empleados e,Roles r " +
                                 "where e.legajo=u.legajo and u.id_rol=r.id_rol";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;


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
        /// GetGetRolEmpleado
        /// </summary>
        /// <Author>hcmoreno</Author>
        public static DataSet GetRolEmpleado(string pUserName)
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select r.descripcion, " +
                             "u.id_rol, " +
                             "u.id_usuario as nombreUser, " +
                             "u.hashed_password, " +
                             "e.legajo, " +
                             "e.dni, " +
                             "e.FechaAlta, " +
                             "e.nombre, " +
                             "e.apellido, " +
                             "e.FechaNac as FechaNac, " +
                             "e.FechaBaja " +
                             "from Usuarios u,Empleados e,Roles r " +
                             "where e.legajo=u.legajo and " +
                             "u.id_rol=r.id_rol and " +
                             "(u.id_usuario=@id_usuario) ";
                //"(e.dni=@dni or @dni is null)  and" +
                //"(e.apellido=@apellido or @apellido is null) and " +
                //"(e.nombre=@nombre or @nombre is null)  ";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_usuario", pUserName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;


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
        /// GetGetRolEmpleado
        /// </summary>
        /// <Author>hcmoreno</Author>
        public static DataSet GetByParam(Empleado pEmpleado)
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select r.descripcion, " +
                             "u.id_rol, " +
                             "u.id_usuario as nombreUser, " +
                             "u.hashed_password, " +
                             "e.legajo, " +
                             "e.dni, " +
                             "e.FechaAlta, " +
                             "e.nombre, " +
                             "e.apellido, " +
                             "e.FechaNac as FechaNac, " +
                             "e.FechaBaja " +
                             "from Usuarios u,Empleados e,Roles r " +
                             "where e.legajo=u.legajo and " +
                             "u.id_rol=r.id_rol and " +
                             "(e.legajo=@legajo or @legajo is null) and " +
                             "(e.dni=@dni or @dni is null)  and" +
                             "(e.apellido=@apellido or @apellido is null) and " +
                             "(e.nombre=@nombre or @nombre is null)  ";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@legajo", pEmpleado.Legajo != null ? pEmpleado.Legajo : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@dni", pEmpleado.Dni != null ? pEmpleado.Dni : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@apellido", pEmpleado.Apellido != String.Empty ? pEmpleado.Apellido : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@nombre", pEmpleado.Nombre != String.Empty ? pEmpleado.Nombre : (object)DBNull.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;


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