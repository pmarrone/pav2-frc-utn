using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Datos
{
    public static class DAOClientes
    {
        public static void Grabar(string strCon, Cliente cliente)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", cliente.IdCliente));
            paramList.Add(new SqlParameter("@sexo", cliente.Sexo));
            paramList.Add(new SqlParameter("@Nombre", cliente.Nombre));
            paramList.Add(new SqlParameter("@NumeroDocumento", cliente.NumeroDocumento));
            paramList.Add(new SqlParameter("@FechaNacimiento", cliente.FechaNacimiento));
                       
            String strSQL = "INSERT INTO CLIENTES (Nombre, Sexo, NumeroDocumento, FechaNacimiento) VALUES  (@Nombre, @sexo, @NumeroDocumento, @FechaNacimiento)";
            DB.EjecutarCommand(strSQL, paramList, DB.Conectar(strCon));
            
        }
        public static Cliente BuscarPorId(string strCon, int IdCliente)
        {
            //TODO ADO2) Implementar BuscarPorId

            SqlConnection con = DB.Conectar(strCon);

            string strSQL = "";
            strSQL = "SELECT idcliente, Nombre, NumeroDocumento, FechaNacimiento, sexo FROM Clientes where idCliente = @id";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", IdCliente));

            SqlDataReader dr = DB.GenerarReader(strSQL, paramList, con);
            Cliente Cli = new Cliente();
            if (dr.Read())
            {
                Cli.IdCliente = (int)dr["IdCliente"];
                Cli.Nombre = dr["Nombre"].ToString();
                Cli.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                Cli.Sexo = dr["sexo"].ToString();
                Cli.NumeroDocumento = int.Parse(dr["NumeroDocumento"].ToString());
                //Cli.Cuit = dr["Cuit"].ToString();
                //Cli.CreditoMaximo = (int)dr["Creditomaximo"];
                //Cli.TieneCasaPropia = (dr["tienecasa"].ToString() == "1" ? true : false);
            }
            con.Close();
            return Cli; 
        }
        public static int Eliminar(String strCon, int IdCliente)
        {
            //TODO ADO3) Implementar Eliminar
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@IdCliente", IdCliente));
  
            String strSQL = "DELETE FROM CLIENTES WHERE IdCliente = @IdCliente";
            return DB.EjecutarCommand(strSQL, paramList, DB.Conectar(strCon));
            //TODO ADO8) Controlar si se pudo borrar el registro, avisar con un mensaje apropiado si sucede (probarlo con dos ventanas que pretenda borrar el mismo registro)
            //TODO ADO9) Controlar si falla la eliminacion por una clave foranea, avisar con un mensaje apropiado (Provarlo con clientes que tengan movimientos en la tabla Ventas)
        }
        public static List<Cliente> ObtenerTodos(string strCon, string strOrden)
        {
            //TODO ADO1) Implementar ObtenerTodos

            // inicializar lista clientes vacia
            // Abrir base
            // preparar comando
            // Ejecutar DataReder
            // recorrer DataReader
            // Crear objeto cliente por cada registro
            // Agregar objeto cliente a la lista clientes
            // cerrar Datareader
            // cerrar Base

            // devolver lista clientes
            SqlConnection con = DB.Conectar(strCon);

            string strSQL = "";
            strSQL = "SELECT idcliente, Nombre, NumeroDocumento, FechaNacimiento, sexo FROM Clientes";
            if (strOrden != null)
                strSQL += " order by " + strOrden;

            List<SqlParameter> paramList = new List<SqlParameter>();

            SqlDataReader dr = DB.GenerarReader(strSQL, paramList, con);
            List<Cliente> ListClientes = new List<Cliente>();
            Cliente Cli;
            while (dr.Read())
            {
                Cli = new Cliente();
                Cli.IdCliente = (int)dr["IdCliente"];
                Cli.Nombre = dr["Nombre"].ToString();
                Cli.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                Cli.Sexo = dr["sexo"].ToString();
                Cli.NumeroDocumento = int.Parse(dr["NumeroDocumento"].ToString());
                //Cli.Cuit = dr["Cuit"].ToString();
                //Cli.CreditoMaximo = (int)dr["Creditomaximo"];
                //Cli.TieneCasaPropia = (dr["tienecasa"].ToString() == "1" ? true : false);
                ListClientes.Add(Cli);
                Cli = null;
            }
            con.Close();
            return ListClientes;

        }

        //TODO ADO10) Implementar un metodo Validar que se ejecute antes del grabar y verfique que a)el campo nombre tenga entre 10 y 40 caracteres y b) Que el Cuit sea un campo Obligatorio
    }
}