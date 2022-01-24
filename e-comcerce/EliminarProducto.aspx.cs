using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaDAO;
using CapaNegocio;

namespace e_comcerce
{
    public partial class EliminarProducto : System.Web.UI.Page
    {
        public int id { get; set; }
       public Productoss objProducto { get; set; }
        List<Productoss> ListaProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32( Request.QueryString["id"]);

                
            }
            ListaProducto = (List<Productoss>)Session["listaproducto"];
            objProducto = ListaProducto.Find(x => x.ID == id);

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = ProductoNegocio.getInstance().EliminarProducto(objProducto.ID);
            Response.Redirect("ProductosAdmin.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductosAdmin.aspx");
        }
    }
}