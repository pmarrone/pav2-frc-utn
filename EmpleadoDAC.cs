using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

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
    public static  void Insert(EmpleadoBE pEmpleado)
    {
	  SqlConnection connection = null;
	  String strCnn;
      
			
      try
      {              
	      strCnn=ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString ;
	      connection = new SqlConnection(strCnn);
		  
		  String sql="insert into empleados(dni,id_cargo,fecha_ingreso, nombres,id_usuario, apellidos) 
		  values(@dni,@id_cargo,@fecha_ingreso, @nombres,@id_usuario, @apellidos)";
                
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = sql;
			cmd.Connection = connection;
			cmd.commandtype = commandtype.text
			
			//cmd.Parameters.AddWithValue("@legajo", pEmpleadoBE.legajo); tipo identity
			cmd.Parameters.AddWithValue("@dni", pEmpleadoBE.dni);
			cmd.Parameters.AddWithValue("@id_cargo", pEmpleadoBE.id_cargo); 
			cmd.Parameters.AddWithValue("@fecha_ingreso", pEmpleadoBE.fecha_ingreso);
			cmd.Parameters.AddWithValue("@nombres", pEmpleadoBE.nombres); 
			cmd.Parameters.AddWithValue("@id_usuario", pEmpleadoBE.id_usuario);
			cmd.Parameters.AddWithValue("@apellidos", pEmpleadoBE.apellidos);
            
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
    public static  void Update(EmpleadoBE pEmpleado)
    {
     SqlConnection connection = null;
	 String strCnn;
      
			
      try
      {              
	      strCnn=ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString ;
	      connection = new SqlConnection(strCnn);
		  
		  String sql="update empleados set dni =@dni,id_cargo = @id_cargo,fecha_ingreso = @fecha_ingreso, nombres = @nombres,id_usuario = @id_usuario, 
		  apellidos = @apellidos where legajo=@legajo";
                
			SqlCommand cmd = new SqlCommand(); 
			cmd.CommandText = sql;
			cmd.Connection = connection;
			cmd.commandtype = commandtype.text
			
			cmd.Parameters.AddWithValue("@legajo", pEmpleadoBE.legajo); 
			cmd.Parameters.AddWithValue("@dni", pEmpleadoBE.dni);
			cmd.Parameters.AddWithValue("@id_cargo", pEmpleadoBE.id_cargo); 
			cmd.Parameters.AddWithValue("@fecha_ingreso", pEmpleadoBE.fecha_ingreso);
			cmd.Parameters.AddWithValue("@nombres", pEmpleadoBE.nombres); 
			cmd.Parameters.AddWithValue("@id_usuario", pEmpleadoBE.id_usuario);
			cmd.Parameters.AddWithValue("@apellidos", pEmpleadoBE.apellidos);
            
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
    public static  void Delete(EmpleadoBE pEmpleado)
    {
      SqlConnection connection = null;
	  String strCnn;
      
			
      try
      {              
		strCnn=ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString ;
		connection = new SqlConnection(strCnn);

		String sql="delete from empleados where legajo=@legajo";
			
		SqlCommand cmd = new SqlCommand(); 
		cmd.CommandText = sql;
		cmd.Connection = connection;
		cmd.commandtype = commandtype.text

		cmd.Parameters.AddWithValue("@legajo", pEmpleadoBE.legajo); 

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
    public static  List<EmpleadoBE> GetAll()
    {
      SqlConnection connection = null;
	  String strCnn;
			
      try
      {                                              
			strCnn=ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString ;
			connection = new SqlConnection(strCnn);

			String sql="select legajo,dni,id_cargo,fecha_ingreso,nombres,id_usuario,apellidos from empleados where ....";

			SqlCommand cmd = new SqlCommand(); 
			cmd.CommandText = sql;
			cmd.Connection = connection;
			cmd.commandtype = commandtype.text

			connection.Open();
			SqlDataReader reader  = cmd.ExecuteReader()
			
			List<EmpleadoBE> empleados = new List<EmpleadoBE>();
			while (reader.Read())
			{
				EmpleadoBE oEmpleado= new EmpleadoBE();
				oEmpleado.legajo = Convert.ToInt32(reader["legajo"]);
				oEmpleado.Nombre = Convert.ToString(reader["nombres"]);
				oEmpleado.Apellido = Convert.ToString(reader["apellidos"]);
				oEmpleado.FechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]);
				oEmpleado.IdCargo = Convert.ToInt32(reader["id_cargo"]);
				oEmpleado.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
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
/// <summary>
    /// GetByParam
    /// </summary>
    /// <Author>hcmoreno</Author>
    public static  List<EmpleadoBE> GetByParam(EmpleadoBE pEmpleadoBE)
    {
            SqlConnection connection = null;
	  String strCnn;
			
      try
      {                                              
			strCnn=ConfigurationManager.ConnectionStrings["ConexionAccess"].ConnectionString ;
			connection = new SqlConnection(strCnn);

			String sql="select legajo,dni,id_cargo,fecha_ingreso,nombres,id_usuario,apellidos from empleados where ....";

			SqlCommand cmd = new SqlCommand(); 
			cmd.CommandText = sql;
			cmd.Connection = connection;
			cmd.commandtype = commandtype.text

			cmd.Parameters.AddWithValue("@legajo", pEmpleadoBE.legajo);
			cmd.Parameters.AddWithValue("@dni", pEmpleadoBE.dni);
			cmd.Parameters.AddWithValue("@id_cargo", pEmpleadoBE.id_cargo); 
			cmd.Parameters.AddWithValue("@fecha_ingreso", pEmpleadoBE.fecha_ingreso);
			cmd.Parameters.AddWithValue("@nombres", pEmpleadoBE.nombres); 
			cmd.Parameters.AddWithValue("@id_usuario", pEmpleadoBE.id_usuario);
			cmd.Parameters.AddWithValue("@apellidos", pEmpleadoBE.apellidos);
			
			connection.Open();
			SqlDataReader reader  = cmd.ExecuteReader()
			
			List<EmpleadoBE> empleados = new List<EmpleadoBE>();
			while (reader.Read())
			{
				EmpleadoBE oEmpleado= new EmpleadoBE();
				oEmpleado.legajo = Convert.ToInt32(reader["legajo"]);
				oEmpleado.Nombre = Convert.ToString(reader["nombres"]);
				oEmpleado.Apellido = Convert.ToString(reader["apellidos"]);
				oEmpleado.FechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]);
				oEmpleado.IdCargo = Convert.ToInt32(reader["id_cargo"]);
				oEmpleado.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
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
	}
}