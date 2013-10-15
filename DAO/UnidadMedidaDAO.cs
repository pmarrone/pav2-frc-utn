using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatriaFabricaMuebles.Entidades;
using System.Data.SqlClient;

namespace PatriaFabricaMuebles.DAO
{
    public class UnidadMedidaDAO
    {


        public static int? Insert(UnidadMedida item)
        {
            String query = "INSERT INTO [Muebles].[dbo].[Unidades_Medida] "
            + "([id_ud_medida] ,[nombre], [abreviatura]) "
            + "OUTPUT Inserted.id_ud_medida "
            + "VALUES "
            + "(,@id_ud_medida "
            + ",@nombre "
            + ",@abreviatura) ";
            
            return (int?)Dal.ExecuteScalar(query, LoadParameters(item));
        }

        private static List<SqlParameter> LoadParameters(UnidadMedida item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id_ud_medida", item.UdMedida));
            parameters.Add(new SqlParameter("nombre", item.Nombre));
            parameters.Add(new SqlParameter("abreviatura",  item.Abreviactura));
            return parameters;
        }

        public static int Delete(UnidadMedida item)
        {
            string query = "DELETE FROM [Muebles].[dbo].[Unidades_Medida] "
            + "WHERE id_ud_medida = @id_ud_medida ";
            return Dal.ExecuteNonQuery(query, LoadParameters(item));
        }

        public static int Update(UnidadMedida item)
        {
            string query = "UPDATE [Muebles].[dbo].[Unidades_Medida] "
                + "SET [nombre] = @nombre "
                + ",[abreviatura] = @abreviatura "
                + "WHERE id_ud_medida = @id_ud_medida ";
            return Dal.ExecuteNonQuery(query, LoadParameters(item));
        }

        public static UnidadMedida GetById(int id)
        {
            UnidadMedida item = new UnidadMedida();
            item.UdMedida = id;
            string query = "SELECT [id_ud_medida] "
                + ",[nombre] "
                + ",[abreviatura] "
                + "FROM [Muebles].[dbo].[Unidades_Medida] "
                + "WHERE id_ud_medida = @id_ud_medida ";
            UnidadMedida unidadMedida = null;
            Dal.ExecuteReader(query, LoadParameters(item), delegate(SqlDataReader reader)
            {
                if (reader.Read())
                {
                    unidadMedida = ExtractData(reader);
                }
            });
            return unidadMedida;
        }

        private static UnidadMedida ExtractData(SqlDataReader reader)
        {
            UnidadMedida unidadMedida = new UnidadMedida();
            unidadMedida.UdMedida = (int?)reader["id_ud_medida"];
            unidadMedida.Nombre = (string)reader["nombre"];
            unidadMedida.Abreviactura = (string)reader["abreviatura"];
           
            return unidadMedida;
        }

        public static List<UnidadMedida> GetAll()
        {
            string query = "SELECT [id_ud_medida] "
                + ",[nombre] "
                + ",[abreviatura] "
                + "FROM [Muebles].[dbo].[Unidades_Medida] ";
            List<UnidadMedida> unidadesMedida = new List<UnidadMedida>();
            Dal.ExecuteReader(query, null, delegate(SqlDataReader reader)
            {
                while (reader.Read())
                {
                    unidadesMedida.Add(ExtractData(reader));
                }
            });
            return unidadesMedida;
        }

    }
}
