﻿using System;
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

        private List<Carro> carrito { get; set; }

        public decimal Total = 0;
        

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaProductos = ProductoNegocio.getInstance().listaProductos();
                Session.Add("listaproducto", listaProductos);

                if (Session["carrito"] == null)
                {
                    carrito = new List<Carro>();
                    Session.Add("carrito", carrito);
                }

                
            }

            if (Request.QueryString["IdProducto"] != null)
            {
                string IdProducto = Request.QueryString["IdProducto"].ToString();
                carrito = (List<Carro>)Session["carrito"];
                listaProductos = (List<Productoss>)Session["listaproducto"];
                 Carro objCarrito = new Carro();
                int aux = 0;

                int idAux = int.Parse(IdProducto);

                if (ProductoNegocio.getInstance().ValidarStock(idAux, 1)==true)
                {
                    foreach (Carro item2 in carrito)
                    {

                        if (int.Parse(IdProducto) == item2.Producto.IdProducto)
                        {

                            item2.Cantidad++;
                            aux = 1;
                            bool ok = ProductoNegocio.getInstance().BajaStock(idAux);
                        }
                    }

                    if (aux == 0)
                    {
                        foreach (Productoss item in listaProductos)
                        {


                            if (item.IdProducto == int.Parse(IdProducto))
                            {


                                objCarrito.Producto = new Productoss();
                                objCarrito.Producto = item;
                                objCarrito.Cantidad = 1;
                                objCarrito.id = 1;

                                bool ok = ProductoNegocio.getInstance().BajaStock(idAux);
                            }
                        }
                        carrito.Add(objCarrito);
                    }



                    Session.Add("carrito", carrito);
                    Response.Redirect("Productos.aspx");
                }
                else
                {
                    Response.Redirect("errorStock.aspx");
                }

                

               

                

            }



        }
    }
}