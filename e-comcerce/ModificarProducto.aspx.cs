using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDominio;
using CapaDAO;

namespace e_comcerce
{
    public partial class ModificarProducto : System.Web.UI.Page
    {
        public int id { get; set; }
        public List<Productoss> listaproducto { get; set; }

        public Productoss objProducto { get; set; }

        public Productoss aux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

          

            if (Request.QueryString["IdProducto"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["IdProducto"]);


            }
            listaproducto = (List<Productoss>)Session["listaproducto"];
            objProducto = listaproducto.Find(x => x.IdProducto == id);
            
            /*
            txtIDcategoria.Text = objProducto.ID_Categoria.ID.ToString();
            txtDescripcion.Text = objProducto.Descripcion;
            txtPrecio.Text = objProducto.Precio.ToString();
            txtStock.Text = objProducto.Stock.ToString();
            
            txtURL.Text = objProducto.URLimagen;
            */
            
           

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            aux = new Productoss();
            aux.IdCategoria = new Categoria();
            aux.IdProducto = objProducto.IdProducto;
           aux.IdCategoria.IdCategoria = Convert.ToInt32( txtIDcategoria.Text);
            aux.Descripcion = txtDescripcion.Text;
            aux.Precio = Convert.ToDecimal(txtPrecio.Text);
            aux.Stock = Convert.ToInt32(txtStock.Text);
            aux.UrlImagen = txtURL.Text;
            bool ok = ProductoNegocio.getInstance().ModificarProducto(aux);

            Response.Redirect("ProductosAdmin.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductosAdmin.aspx");
        }
    }
}