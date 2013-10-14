using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PatriaFabricaMuebles.DAO
{


    public class Dal
    {

        static string cadena = ConfigurationManager.ConnectionStrings["MueblesDB"].ToString();

        public static void ExecuteReader(string sqlTextOrProcedureName, List<SqlParameter> parameters, Action<SqlDataReader> metodoLectura)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cn = new SqlConnection(cadena);
                cn.Open();
                cmd = new SqlCommand(sqlTextOrProcedureName, cn);
                LoadParameters(parameters, cmd);
                dr = cmd.ExecuteReader();
                metodoLectura(dr);
            }
            finally
            {
                if (dr != null)
                    dr.Dispose();
                if (cmd != null)
                    cmd.Dispose();
                if (cn != null && cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        private static void LoadParameters(List<SqlParameter> parameters, SqlCommand cmd)
            {
                if (parameters != null)
                {
                    //Elimina los parámetros cargados con null. 
                    //Los que quieran insertar null en BD deben venir con DBNull
                    parameters.RemoveAll((e) => { return e.Value == null; });
                    foreach (SqlParameter parameter in parameters)
                    {
                        
                        cmd.Parameters.Add(parameter);
                    }
                }
}
        public static int ExecuteNonQuery(string sqlTextOrProcedureName, List<SqlParameter> parameters)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = new SqlConnection(cadena);
                cn.Open();

                cmd = new SqlCommand(sqlTextOrProcedureName, cn);
                LoadParameters(parameters, cmd);
                return cmd.ExecuteNonQuery();
            }
            finally
            {

                if (cmd != null)
                    cmd.Dispose();
                if (cn != null && cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }

        public static object ExecuteScalar(string sqlTextOrProcedureName, List<SqlParameter> parameters)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            Object result = null;
            try
            {
                cn = new SqlConnection(cadena);
                cn.Open();
                cmd = new SqlCommand(sqlTextOrProcedureName, cn);
                LoadParameters(parameters, cmd);
                result = cmd.ExecuteScalar();
                return result;
            }
            finally
            {

                if (cmd != null)
                    cmd.Dispose();
                if (cn != null && cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
    }
}
