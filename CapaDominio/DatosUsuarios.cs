using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
   public class DatosUsuarios
    {
        public Usuario ID{ get; set; }

        public string Nombre{ get; set; }

        public string Apellido { get; set; }

        public string Documento { get; set; }

        public string Domicilio{ get; set; }

        public string Celular{ get; set; }

        public bool Estado { get; set; }
    }
}
