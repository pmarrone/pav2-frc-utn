using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatriaFabricaMuebles.Entidades;
using System.Data.SqlClient;

namespace PatriaFabricaMuebles.DAO
{
    public class MaterialDAO
    {
        private static List<SqlParameter> LoadParameters(Material item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id_material", item.IdMaterial));
            parameters.Add(new SqlParameter("denominacion", item.Denominacion));
            parameters.Add(new SqlParameter("caracteristicas", item.Caracteristicas));
            parameters.Add(new SqlParameter("stockMinimo", item.StockMin));
            parameters.Add(new SqlParameter("stockReal", item.StockReal));
            parameters.Add(new SqlParameter("stockAsignado", item.StockAsign));
            parameters.Add(new SqlParameter("idUnidadMedida", (item.UdMedida == null ? null : item.UdMedida.UdMedida)));
            return parameters;
        }

        private static Material ExtractData(SqlDataReader reader)
        {
            Material material = new Material();

            material.IdMaterial = (int?)reader["id_material"];
            material.Denominacion = (string)reader["denominacion"];
            material.Caracteristicas = (string)reader["caracteristicas"];
            material.StockMin = (Decimal)reader["stock_minimo"];
            material.StockReal = (Decimal)reader["stock_real"];
            material.StockAsign = (Decimal)reader["stock_asignado"];
            int? idUnidadMedida = (int?)reader["id_ud_medida"];
            if (idUnidadMedida != null)
            {
                material.UdMedida = UnidadMedidaDAO.GetById(idUnidadMedida.Value);
            }

            return material;
        }

        public static int? Insert(Material item)
        {
            String query = "INSERT INTO [Muebles].[dbo].[Materiales] "
            + "([denominacion] ,[caracteristicas], [stock_minimo],[stock_real],[stock_asignado],[id_ud_medida]) "
            + "OUTPUT Inserted.id_material "
            + "VALUES "
            + "(@denominacion "
            + ",@caracteristicas "
            + ",@stockMinimo "
            + ",@stockReal "
            + ",@stockAsignado "
            + ",@idUnidadMedida) ";
            return (int?)Dal.ExecuteScalar(query, LoadParameters(item));
        }

        public static int Delete(Material item)
        {
            string query = "DELETE FROM [Muebles].[dbo].[Materiales] "
            + "WHERE id_material = @id_material ";
            return Dal.ExecuteNonQuery(query, LoadParameters(item));
        }

        public static int Update(Material item)
        {
            string query = "UPDATE [Muebles].[dbo].[Materiales] "
                + "SET [denominacion] = @denominacion "
                + ",[caracteristicas] = @caracteristicas "
                + ",[stock_minimo] = @stockMinimo "
                + ",[stock_real] = @stockReal "
                + ",[stock_asignado] = @stockAsignado "
                + ",[id_ud_medida] =  @idUnidadMedida "
                + "WHERE id_material = @id_material ";
            return Dal.ExecuteNonQuery(query, LoadParameters(item));
        }

        public static Material GetById(int id)
        {
            Material material = new Material();
            material.IdMaterial = id;
            return GetById(material);
        }
        public static Material GetById(Material item)
        {
            string query = "SELECT [id_material] "
                + ",[denominacion] "
                + ",[caracteristicas] "
                + ",[stock_minimo] "
                + ",[stock_real] "
                + ",[stock_asignado] "
                + ",[id_ud_medida] "
                + "FROM [Muebles].[dbo].[Materiales] "
                + "WHERE id_material = @id_material ";
            Material material = null;
            Dal.ExecuteReader(query, LoadParameters(item), delegate(SqlDataReader reader)
            {
                if (reader.Read())
                {
                    material = ExtractData(reader);
                }
            });
            return material;
        }



        public static List<Material> GetAll()
        {
            string query = "SELECT [id_material] "
                + ",[denominacion] "
                + ",[caracteristicas] "
                + ",[stock_minimo] "
                + ",[stock_real] "
                + ",[stock_asignado] "
                + ",[id_ud_medida] "
                + "FROM [Muebles].[dbo].[Materiales] ";
            List<Material> materiales = new List<Material>();
            Dal.ExecuteReader(query, null, delegate(SqlDataReader reader)
            {
                while (reader.Read())
                {
                    materiales.Add(ExtractData(reader));
                }
            });
            return materiales;
        }

    }
}
