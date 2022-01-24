using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDAO;
using CapaDominio;
using CapaNegocio;

namespace e_comcerce
{
    public partial class RegistroProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Productoss obj = new Productoss();
            obj.ID_Categoria = new Categoria();
            obj.ID_Categoria.ID = Convert.ToInt32(txtCategoria.Text);
            obj.Descripcion = txtDescripcion.Text;
            obj.Stock = Convert.ToInt32(txtStock.Text);
            obj.Precio = Convert.ToInt32(txtPrecio.Text);
            obj.URLimagen = txtURL.Text;

            bool ok = ProductoNegocio.getInstance().RegistrarProducto(obj);

            Response.Redirect("Productos.aspx");
        }
    }
}