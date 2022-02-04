using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
   public class Usuario
    {
        // COMPRADOR
        public int ID { get; set; }

        public string  Email{ get; set; }
        public string Clave { get; set; }

        public bool Estado{ get; set; }
    }
}
