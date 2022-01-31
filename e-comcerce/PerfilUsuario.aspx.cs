using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;

namespace e_comcerce
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["userName"].ToString();
            Usuario usuario = UsuarioNegocio.getInstance().BuscarUsuarioPorEmail(email);
            
            PerfilNombre.Text = usuario.Nombre;
            PerfilApellido.Text = usuario.Apellido;
            PerfilDNI.Text = usuario.Documento;
            PerfilDomicilio.Text = usuario.Domicilio;
            PerfilCelular.Text = usuario.Celular;
            PerfilEmail.Text = usuario.Email;            
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
        }

        protected void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {
        }
    }
}