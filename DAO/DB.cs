using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace PatriaFabricaMuebles.DAO
{
    public static class DB
    {
        public static SqlConnection Conectar(string StrCon)
        {
            SqlConnection con = new SqlConnection(StrCon);
            con.Open();
            return con;
        }

        public static SqlCommand ArmaCommand(string strSQL, List<SqlParameter> param, SqlConnection con)
        {
            SqlCommand com = new SqlCommand(strSQL, con);
            com.CommandType = CommandType.Text;

            foreach (SqlParameter sp in param)
            {
                com.Parameters.Add(sp);
            }
            return com;
        }
        public static SqlDataReader GenerarReader(string strSQL, List<SqlParameter> param, SqlConnection con)
        {
            SqlCommand com = ArmaCommand(strSQL, param, con);
            return com.ExecuteReader();
        }

        public static DataTable GenerarTable(String strSQL, List<SqlParameter> lista, SqlConnection con)
        {
            DataTable dt = new DataTable();
            dt.Load(GenerarReader(strSQL, lista, con));
            return dt;
        }

        public static int EjecutarCommand(String strSQL, List<SqlParameter> lista, 
            SqlConnection con)
        {
            SqlCommand com = ArmaCommand(strSQL, lista, con);
            return com.ExecuteNonQuery();
        }
        public static int EjecutarCommand(String strSQL, List<SqlParameter> lista, 
            SqlConnection con, SqlTransaction tran)
        {
            SqlCommand com = ArmaCommand(strSQL, lista, con);
            com.Transaction = tran;
            return com.ExecuteNonQuery();
        }

    }
}