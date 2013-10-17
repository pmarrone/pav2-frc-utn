using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using PatriaFabricaMuebles.Entidades;


namespace PatriaFabricaMuebles.DAO
{
    public class MuebleDAO
    {
        public static String CONNECTION_STRING = ConfigurationManager.ConnectionStrings["MueblesDB"].ConnectionString;
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="pmueble">objeto tipo mueble</param>
        /// <returns>int</returns>
        /// <Date>2013-10-13</Date>
        /// <Author>fmartina</Author>
        public static int Insert(Mueble pMueble)
        {

            try
            {
                pMueble.IdMueble = InsertMueble(pMueble);
                InsertMateriales(pMueble);
                return pMueble.IdMueble;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public static List<MaterialMueble> GetByIdMueble(Mueble item)
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;

            connection = new SqlConnection(MuebleDAO.CONNECTION_STRING);

            string query = "SELECT m.id_material "
                + ",m.denominacion "
                + ",m.caracteristicas "
                + ",m.stock_minimo "
                + ",m.stock_real "
                + ",m.stock_asignado "
                + ",m.id_ud_medida "
                + ",mm.cantidad "
                + "From Materiales m, Materiales_Muebles mm  "
                + "WHERE mm.idMueble = @idMueble ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@idMueble", item.IdMueble);

            connection.Open();
            reader = cmd.ExecuteReader();

            List<MaterialMueble> materialMueble = new List<MaterialMueble>();

            if (reader.Read())
            {
                MaterialDAO matDao = new MaterialDAO();
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
                MaterialMueble mm = new MaterialMueble();
                mm.Cantidad = (Int32)reader["cantidad"];
                mm.MaterialM = material;
                materialMueble.Add(mm);
            }

            return materialMueble;
        }


        public void DeleteMueble(Mueble pMueble)
        {
            try
            {
                DeleteMaterial(pMueble);
                DeleteMueble(pMueble);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public static int InsertMueble(Mueble pMueble)
        {
            SqlConnection connection = null;

            SqlCommand cmd = new SqlCommand();
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "insert into Muebles( idTipoMueble, denominacion, caracteristicas, costo, precioVta) OUTPUT Inserted.idMueble "
                    + "values(@IdTipoMueble, @denominacion,@caracteristicas, @costo, @precioVta)";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@IdTipoMueble", pMueble.IdTipoMueble);
                cmd.Parameters.AddWithValue("@denominacion", pMueble.Denominacion);
                cmd.Parameters.AddWithValue("@caracteristicas", pMueble.Caracteristicas);
                cmd.Parameters.AddWithValue("@costo", pMueble.Costo);
                cmd.Parameters.AddWithValue("@precioVta", pMueble.PrecioVta);

                connection.Open();
                int idMagico = (int)cmd.ExecuteScalar();
                return idMagico;
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
        /// Insert
        /// </summary>
        /// <param name="pmueble">objeto tipo mueble</param>
        /// <returns>int</returns>
        /// <Date>2013-10-13</Date>
        /// <Author>fmartina</Author>
        public static void InsertMateriales(Mueble pMueble)
        {
            SqlConnection connection = null;

            foreach (MaterialMueble materialMueble in pMueble.MaterialMueble)
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    connection = new SqlConnection(CONNECTION_STRING);

                    String sql = "insert into Materiales_Muebles( idMueble, idMaterial, cantidad)values (@pIdMueble,@pIdMaterial,@pCantidad) ";


                    cmd.CommandText = sql;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@pIdMueble", pMueble.IdMueble);
                    cmd.Parameters.AddWithValue("@pIdMaterial", materialMueble.MaterialM.IdMaterial);
                    cmd.Parameters.AddWithValue("@pCantidad", materialMueble.Cantidad);

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
        }

        public void UpdateMueble(Mueble pMueble)
        {
            DeleteMaterial(pMueble);
            Update(pMueble);
            InsertMateriales(pMueble);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <returns>void</returns>
        /// <Date></Date>
        /// <Author>hcmoreno</Author>
        public static void Update(Mueble pMueble)
        {
            SqlConnection connection = null;
            String strCnn;
            SqlCommand cmd = new SqlCommand();

            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);


              
                String sql = "update Muebles set idTipoMueble =@idTipoMueble, denominacion = @denominacion, caracteristicas = @caracteristicas, "
                    + "costo = @costo where idMueble=@idMueble";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@idTipoMueble", pMueble.IdTipoMueble);
                cmd.Parameters.AddWithValue("@denominacion", pMueble.Denominacion);
                cmd.Parameters.AddWithValue("@caracteristicas", pMueble.Caracteristicas);
                cmd.Parameters.AddWithValue("@costo", pMueble.Costo);
                cmd.Parameters.AddWithValue("@precioVta", pMueble.PrecioVta);
                cmd.Parameters.AddWithValue("@idMueble", pMueble.IdMueble);

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
        public static void Delete(Mueble pMueble)
        {
            SqlConnection connection = null;
            String strCnn;
            SqlCommand cmd = new SqlCommand();

            SqlCommand cmdMaterial = new SqlCommand();
            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);


                String sql = "delete from Muebles where idMueble=@idMueble";
                cmdMaterial.CommandText = sql;
                cmdMaterial.Connection = connection;
                cmdMaterial.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@idMueble", pMueble.IdMueble);
                cmd.ExecuteNonQuery();
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
        /// <Author>fmmartina</Author>
        public static void DeleteMaterial(Mueble pMueble)
        {
            SqlConnection connection = null;
            String strCnn;

            SqlCommand cmdMaterial = new SqlCommand();
            try
            {
                strCnn = CONNECTION_STRING;
                connection = new SqlConnection(strCnn);


                String sqlMaterial = "delete from Materiales_Muebles where idMueble=@idMueble";
                cmdMaterial.CommandText = sqlMaterial;
                cmdMaterial.Connection = connection;
                cmdMaterial.CommandType = CommandType.Text;

                cmdMaterial.Parameters.AddWithValue("@idMueble", pMueble.IdMueble);


                connection.Open();
                cmdMaterial.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <Author>hcmoreno</Author>
        public static List<Mueble> GetAll()
        {
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select idMueble,denominacion, caracteristicas, costo, idtipomueble, preciovta from Muebles";


                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                connection.Open();
                reader = cmd.ExecuteReader();

                List<Mueble> Muebles = new List<Mueble>();
                while (reader.Read())
                {
                    Mueble oMueble = new Mueble();
                    oMueble.IdMueble = (Int32)reader["idMueble"];
                    oMueble.Denominacion = (String)reader["Denominacion"];
                    oMueble.Caracteristicas = (String)reader["Caracteristicas"];
                    oMueble.Costo = (float)reader["costo"];
                    oMueble.IdTipoMueble = Convert.ToInt32(reader["idTipoMueble"]);
                    oMueble.PrecioVta = (float)reader["PrecioVta"];
                    
                    
                    oMueble.MaterialMueble = GetByIdMueble(oMueble);

                    Muebles.Add(oMueble);
                }

                return Muebles;
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


        public static Mueble GetById(int id)
        {
            SqlDataReader reader = null;
            SqlConnection connection = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                connection = new SqlConnection(CONNECTION_STRING);

                String sql = "select idMueble,denominacion, caracteristicas, costo, idtipomueble, preciovta from Muebles where id = @idMueble";

                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idMueble", id);

                connection.Open();
                reader = cmd.ExecuteReader();

                Mueble Mueble = null;
                if (reader.Read())
                {
                    Mueble = new Mueble();
                    Mueble.IdMueble = (Int32)reader["idMueble"];
                    Mueble.Caracteristicas  = (String)reader["Caracteristicas"];
                    Mueble.Costo = (float)reader["costo"];
                    Mueble.Denominacion = (string )reader["Denominacion"];
                    Mueble.IdTipoMueble = Convert.ToInt32(reader["idTipoMueble"]);
                    Mueble.PrecioVta=(float )reader ["PrecioVta"];

                    List<MaterialMueble> materialmueble = GetByIdMueble(Mueble);
                    Mueble.MaterialMueble = materialmueble;
                }
                return Mueble;
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
