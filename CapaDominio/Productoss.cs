using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
   public class Productoss
    {
        public int ID { get; set; }

        public Categoria ID_Categoria { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public decimal Precio { get; set; }

        public bool Estado { get; set; }

        public string URLimagen { get; set; }


    }
}
