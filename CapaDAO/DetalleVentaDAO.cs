using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaDominio;
using CapaAccesoDatos;


namespace CapaDAO
{
   public class DetalleVentaDAO
    {
        #region "PATRON SINGLETON"
        private static DetalleVentaDAO daoDetalleVenta= null;
        private DetalleVentaDAO() { }
        public static DetalleVentaDAO getInstance()
        {
            if (daoDetalleVenta== null)
            {
                daoDetalleVenta= new DetalleVentaDAO();
            }
            return daoDetalleVenta;
        }
        #endregion

        public int UltimoIdVenta()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int ID=0;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_UltimoIdVenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ID = Convert.ToInt32(dr["ID"].ToString());
                }

               
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ID;
        }

        public bool RegistrarDetalle(List<DetalleVenta> listaDetalle)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            foreach (DetalleVenta item in listaDetalle)
            {
                try
                {
                    con = Conexion.getInstance().ConexionBD();
                    cmd = new SqlCommand("SP_RegistrarDetalle", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idventa", item.ID_Venta.ID);
                    cmd.Parameters.AddWithValue("@idproducto", item.ID_Producto.ID);
                    cmd.Parameters.AddWithValue("@precio", item.Precio);
                    cmd.Parameters.AddWithValue("@cantidad", item.Cantidad);


                    con.Open();

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0) response = true;
                }
                catch (Exception ex)
                {
                    response = false;
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
            return response;
        }

    }
}
