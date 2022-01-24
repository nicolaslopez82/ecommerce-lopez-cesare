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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Productoss> listaProductos { get; set; }

        private List<Productoss> carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaProductos = ProductoNegocio.getInstance().listaProductos();
                Session.Add("listaproducto", listaProductos);

                if (Session["carrito"] == null)
                {
                    carrito = new List<Productoss>();
                    Session.Add("carrito", carrito);
                }
            }

            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                carrito = (List<Productoss>)Session["carrito"];
                listaProductos = (List<Productoss>)Session["listaproducto"];
                carrito.Add(listaProductos.Find(x => x.ID == int.Parse(id)));
                Session.Add("carrito", carrito);

                

            }

        }
    }
}