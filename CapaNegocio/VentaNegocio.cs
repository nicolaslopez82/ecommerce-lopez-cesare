﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaDAO;

namespace CapaNegocio
{
 public   class VentaNegocio
    {

        #region "PATRON SINGLETON"
        private static VentaNegocio objVenta= null;
        private VentaNegocio() { }
        public static VentaNegocio getInstance()
        {
            if (objVenta== null)
            {
                objVenta = new VentaNegocio();
            }
            return objVenta;
        }
        #endregion

        public bool FinalizarVenta(Ventas objVenta)
        {
            try
            {
                return VentaDAO.getInstance().FinalizarVenta(objVenta); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
