﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaAccesoDatos;
using System.Data.SqlClient;

namespace CapaDAO
{
   public class ProductoDAO
    {
        #region "PATRON SINGLETON"
        private static ProductoDAO daoProducto= null;
        private ProductoDAO() { }
        public static ProductoDAO getInstance()
        {
            if (daoProducto == null)
            {
               daoProducto = new ProductoDAO();
            }
            return daoProducto;
        }
        #endregion


        public bool registrarProducto(Productoss objProducto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_AgregarProducto", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria",objProducto.ID_Categoria.ID);
                cmd.Parameters.AddWithValue("@Descripcion", objProducto.Descripcion);
                cmd.Parameters.AddWithValue("@stock", objProducto.Stock);
                cmd.Parameters.AddWithValue("@precio", objProducto.Precio);
                cmd.Parameters.AddWithValue("@urlImagen", objProducto.URLimagen);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;


            }
            catch (Exception ex)
            {
                response = false;
                throw ex ;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        /*
        public List<Productoss> ListaProducto()
        {
            List<Productoss> Lista = new List<Productoss>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListaProducto", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Productoss obj = new Productoss();
                    obj.ID = (int)dr["ID"];
                    
                    obj.ID_Categoria.ID = (int)dr["ID_Categoria"];
                    obj.Descripcion = (string)dr["Descripcion"];
                    obj.Stock = (int)dr["Stock"];
                    obj.Precio = (decimal)dr["Precio"];
                    obj.URLimagen = (string)dr["UrlImagen"];

                    Lista.Add(obj);


                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }
        */

        public List<Productoss> Lista()
        {
            List<Productoss> Lista = new List<Productoss>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();

                cmd = new SqlCommand("SP_ListaProducto", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                

                    while (dr.Read())
                    {
                        Productoss obj = new Productoss();
                        obj.ID = Convert.ToInt32(dr["ID"].ToString()) ;
                        obj.ID_Categoria = new Categoria();
                        obj.ID_Categoria.ID = Convert.ToInt32( dr["ID_Categoria"].ToString());

                        obj.Descripcion = dr["Descripcion"].ToString();
                        obj.Stock = Convert.ToInt32( dr["Stock"].ToString());
                        obj.Precio = Convert.ToDecimal (dr["Precio"].ToString());
                        obj.URLimagen = dr["UrlImagen"].ToString();

                        Lista.Add(obj);
                    }

                    
                }


            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }

        public bool ModificarProducto(Productoss objProducto)
        {

            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ModificarProducto", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@id", objProducto.ID);
                cmd.Parameters.AddWithValue("@idCategoria", objProducto.ID_Categoria.ID);
                cmd.Parameters.AddWithValue("@Descripcion", objProducto.Descripcion);
                cmd.Parameters.AddWithValue("@stock", objProducto.Stock);
                cmd.Parameters.AddWithValue("@precio", objProducto.Precio);
                cmd.Parameters.AddWithValue("@urlImagen", objProducto.URLimagen);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception ex) 
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public bool EliminarProducto(int ID_Producto)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_EliminarProducto", con);
                cmd.Parameters.AddWithValue("@ID", ID_Producto);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }


    }
}
