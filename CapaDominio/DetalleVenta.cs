using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
  public  class DetalleVenta
    {
        public Ventas ID_Venta { get; set; }

        public Productoss ID_Producto { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public bool Estado { get; set; }
    }
}
