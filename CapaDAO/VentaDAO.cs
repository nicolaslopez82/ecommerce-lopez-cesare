using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaDominio;
using System.Data.SqlClient;

namespace CapaDAO
{
   public class VentaDAO
    {

        #region "PATRON SINGLETON"
        private static VentaDAO daoVenta = null;
        private VentaDAO() { }
        public static VentaDAO getInstance()
        {
            if (daoVenta == null)
            {
                daoVenta = new VentaDAO();
            }
            return daoVenta;
        }
        #endregion

        public bool FinalizarVenta(Ventas objVenta)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_FinalizarVenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUsuario", objVenta.IdUsuario);
                cmd.Parameters.AddWithValue("@idPago", objVenta.IdFormaPago);
                cmd.Parameters.AddWithValue("@descripcion", objVenta.DescripcionVenta);
                cmd.Parameters.AddWithValue("@direccion", objVenta.DireccionEnvio);
                cmd.Parameters.AddWithValue("@estadoretiro", objVenta.EstadoRetiro);
                cmd.Parameters.AddWithValue("@estadoenvio", objVenta.EstadoEnvio);
                cmd.Parameters.AddWithValue("@total", objVenta.Total);
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
            return response;
        }

    }
}
