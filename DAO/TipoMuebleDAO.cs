using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatriaFabricaMuebles.Entidades;
using System.Data.SqlClient;

namespace PatriaFabricaMuebles.DAO
{
    public class TipoMuebleDAO
    {
        private static List<SqlParameter> LoadParameters(TipoMueble tipoMueble)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id_tipo_mueble", tipoMueble.IdTipoMueble));
            parameters.Add(new SqlParameter("descripcion", tipoMueble.Descrip));
            return parameters;
        }

        private static TipoMueble ExtractData(SqlDataReader reader)
        {
            TipoMueble tipoMueble = new TipoMueble();
            tipoMueble.IdTipoMueble = (int?)reader["id_tipo_mueble"];
            tipoMueble.Descrip = (string)reader["descripcion"];

            return tipoMueble;
        }

        public static TipoMueble GetById(int id)
        {
            TipoMueble material = new TipoMueble();
            material.IdTipoMueble = id;
            return GetById(material);
        }
        public static TipoMueble GetById(TipoMueble item)
        {
            string query = "SELECT [id_tipo_mueble]"
                + " ,[descripcion]"
                + " FROM [Muebles].[dbo].[Tipos_Mueble]"
                + " WHERE id_tipo_mueble = @id_tipo_mueble ";
            TipoMueble tipoMueble = null;
            Dal.ExecuteReader(query, LoadParameters(item), delegate(SqlDataReader reader)
            {
                if (reader.Read())
                {
                    tipoMueble = ExtractData(reader);
                }
            });
            return tipoMueble;
        }

        public static List<TipoMueble> GetAll()
        {
            string query = "SELECT [id_tipo_mueble]"
                + " ,[descripcion]"
                + " FROM [Muebles].[dbo].[Tipos_Mueble]";
            List<TipoMueble> tiposMueble = new List<TipoMueble>();
            Dal.ExecuteReader(query, null, delegate(SqlDataReader reader)
            {
                while (reader.Read())
                {
                    tiposMueble.Add(ExtractData(reader));
                }
            });
            return tiposMueble;
        }

    }
}
