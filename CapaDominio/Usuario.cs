using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public enum TipoUsuario
    {        
        ADMIN = 1,
        COMPRADOR = 2
    }
    public class Usuario
    {
        public int ID { get; set; }

        public string  Email{ get; set; }
        public string Clave { get; set; }

        public bool Estado{ get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public Usuario() { }

        public Usuario(string email, string clave, bool estado, bool admin)
        {
            Email = email;
            Clave = clave;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.COMPRADOR;
        }
    }
}
