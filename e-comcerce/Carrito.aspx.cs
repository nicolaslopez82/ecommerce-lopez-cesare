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
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Productoss> carrito { get; set; }

        public decimal total  { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            total = 0;
            carrito = new List<Productoss>();
            carrito = (List<Productoss>)Session["carrito"];

            foreach (Productoss pro in carrito)
            {
                total += pro.Precio;
            }

           
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();

                foreach (Productoss pro2 in carrito)
                {
                    if(pro2.ID== Convert.ToInt32(id))
                    {
                        total = total - pro2.Precio;
                    }
                }

                carrito.Remove(carrito.Find(x => x.ID == int.Parse(id)));
                Session.Add("carrito", carrito);

               



            }



        }

        protected void btnIniciarCompra_Click(object sender, EventArgs e)
        {

        }
    }
}