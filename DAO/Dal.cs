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
        
        static string cadena = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public static void ExecuteReader(string sqlTextOrProcedureName, object[] parameters, Action<SqlDataReader> metodoLectura)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cn = new SqlConnection(cadena);
                cn.Open();
                cmd = new SqlCommand(sqlTextOrProcedureName, cn);
                dr = cmd.ExecuteReader();
                metodoLectura(dr);
            }
            catch (Exception ex)
            {
                throw;
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
        public static int ExecuteNonQuery(string sqlTextOrProcedureName, object[] parameters)
        {
            return 0;
        }

       

    }
}
