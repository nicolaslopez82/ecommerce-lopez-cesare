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
    public partial class Venta : System.Web.UI.Page
    {
        public List<Productoss> carrito { get; set; }

        public decimal total { get; set; }

        public List<FormaPago> listaFormaPago { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = new List<Productoss>();
            carrito = (List<Productoss>)Session["carrito"];

            total = 0;

            foreach (Productoss pro in carrito)
            {
                total += pro.Precio;
            }

            listaFormaPago = FormaPagoNegocio.getInstance().listarFormaPago();

            dropFormaPago.DataSource = listaFormaPago;
            dropFormaPago.DataTextField = "Descripcion";
            dropFormaPago.DataValueField = "ID";
            dropFormaPago.DataBind();

        }


        protected void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            //Para Detalle de Venta
            int ID_Venta = 0;
            List<DetalleVenta> listaDetalle = new List<DetalleVenta>();
            DetalleVenta objDetalle = new DetalleVenta();
           
            //Para la venta
            Ventas objVenta = new Ventas();
            //  Este tiene que sacar del session el usuario
            objVenta.ID_Usuario = 1;
            //
            objVenta.ID_FormaPago = int.Parse(dropFormaPago.SelectedItem.Value);
            objVenta.DescripcionVenta = txtAclaracion.Text;
            objVenta.DireccionEnvio = txtDireccionEnvio.Text;

            if (int.Parse(dplEnvio.SelectedItem.Value) == 1)
            {
                total = total + 1000;
                objVenta.EstadoEnvio = true;
                objVenta.EstadoRetiro = false;
            }
            else
            {
                if(int.Parse(dplEnvio.SelectedItem.Value) == 2)
                objVenta.EstadoEnvio = false;
                objVenta.EstadoRetiro = true;

            }

            objVenta.Total = total;

            bool ok = VentaNegocio.getInstance().FinalizarVenta(objVenta);

           

            ID_Venta = DetalleVentaNegocio.getInstance().UltimoIdVenta();

            foreach (Productoss pro in carrito)
            {
                objDetalle.ID_Venta = new Ventas();
                objDetalle.ID_Venta.ID = ID_Venta;
                objDetalle.ID_Producto = new Productoss();
                objDetalle.ID_Producto.ID = pro.ID;
                objDetalle.Precio = pro.Precio;

                objDetalle.Cantidad = 1;

                listaDetalle.Add(objDetalle);

            }

            bool aux = DetalleVentaNegocio.getInstance().RegistrarDetalle(listaDetalle);

            Response.Redirect("VentaFinalizada.aspx");

        }
    }
}