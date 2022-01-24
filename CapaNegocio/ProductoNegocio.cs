using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaDAO;
using CapaDominio;

namespace CapaNegocio
{
    public class ProductoNegocio
    {

        #region "PATRON SINGLETON"
        private static ProductoNegocio objProducto= null;
        private ProductoNegocio() { }
        public static ProductoNegocio getInstance()
        {
            if (objProducto == null)
            {
                objProducto = new ProductoNegocio();
            }
            return objProducto;
        }
        #endregion

        public bool RegistrarProducto(Productoss objProducto)
        {
            try
            {
                ProductoDAO.getInstance().registrarProducto(objProducto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public List<Productoss> listaProductos()
        {
            try
            {
              return  ProductoDAO.getInstance().Lista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ModificarProducto(Productoss objproducto)
        {
            try
            {
                return ProductoDAO.getInstance().ModificarProducto(objproducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EliminarProducto(int ID_Producto)
        {
            try
            {
                return ProductoDAO.getInstance().EliminarProducto(ID_Producto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
