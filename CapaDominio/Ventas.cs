using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
   public class Ventas
    {
        public int ID { get; set; }

        public DateTime  FechaVenta{ get; set; }

        public int ID_Usuario { get; set; }

        public int ID_FormaPago { get; set; }

        public string DescripcionVenta { get; set; }

        public string DireccionEnvio { get; set; }

        public bool EstadoEnvio { get; set; }

        public bool Estado { get; set; }

        public decimal Total { get; set; }

        public bool EstadoRetiro { get; set; }

    }
}
