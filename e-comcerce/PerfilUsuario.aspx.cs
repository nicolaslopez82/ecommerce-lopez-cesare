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
            

            //TODO Checkear este if.
            if (!Page.IsPostBack)
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
            lblError.Text = "";
            lblErrorContrasenia.Text = "";

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (PerfilNombre.Text == "" ||
                PerfilApellido.Text == "" ||
                PerfilDNI.Text == "" ||
                PerfilDomicilio.Text == "" ||
                PerfilCelular.Text == "" )
            {
                lblError.Text = "Ningun campo puede quedar vacio.";
            }
            else 
            {
                Usuario usuarioAGuardar = new Usuario(PerfilEmail.Text, PerfilNombre.Text, PerfilApellido.Text,
                                                      PerfilDNI.Text, PerfilDomicilio.Text, PerfilCelular.Text);

                bool usuarioModificado = UsuarioNegocio.getInstance().ActualizarDatosUsuario(usuarioAGuardar);

                if (usuarioModificado == true)
                {
                    Response.Write("<script>alert('Usuario Modificado Correctamente.')</script>");
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Usuario No Modificado.')</script>");
                }
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Response.Redirect("Default.aspx", false);
        }

        protected void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {
        }

        private void LimpiarCampos() {
            PerfilNombre.Text = "";
            PerfilApellido.Text = "";
            PerfilDNI.Text = "";
            PerfilDomicilio.Text = "";
            PerfilCelular.Text = "";
            PerfilEmail.Text = "";
        }
    }
}