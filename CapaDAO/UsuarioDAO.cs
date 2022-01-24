using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDominio;
using CapaAccesoDatos;

namespace CapaDAO
{
    public class UsuarioDAO
    {

        #region "PATRON SINGLETON"
        private static UsuarioDAO daoUsuario = null;
        private static string Patron = "e-comerce";
        private UsuarioDAO() { }
        public static UsuarioDAO getInstance()
        {
            if (daoUsuario == null)
            {
                daoUsuario = new UsuarioDAO();
            }
            return daoUsuario;
        }
        #endregion

        public Usuario AccesoSistema(String user, String pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Usuario objUsuario = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ValidarUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", user);
                cmd.Parameters.AddWithValue("@clave", pass);
                cmd.Parameters.AddWithValue("@patron", Patron);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.ID = Convert.ToInt32(dr["idUsuario"].ToString());
                    objUsuario.Email = dr["usuario"].ToString();
                    objUsuario.Clave = dr["contrasenia"].ToString();                    
                    objUsuario.Estado = true;
                }
            }
            catch (Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;
        }

        public Usuario BuscarUsuarioPorEmail(String email)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Usuario objUsuario = new Usuario();

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_BuscarUsuarioPorEmail", con);
                cmd.Parameters.AddWithValue("@prmEmail", email);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objUsuario.ID = Convert.ToInt32(dr["idUsuario"].ToString());                    
                    objUsuario.Email = dr["email"].ToString();
                    objUsuario.Clave = dr["clave"].ToString();
                    objUsuario.Estado = Convert.ToBoolean(dr["estado"]);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return objUsuario;
        }        

        public bool BuscarSiExisteUsuarioPorEmail(String email)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            Usuario objUsuario = new Usuario();
            int nResult = 0;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_BuscarSiExisteUsuarioPorEmail", con);
                cmd.Parameters.AddWithValue("@prmUsuario", email);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                nResult = (int)cmd.ExecuteScalar();
                if (nResult == 1) { return true; }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return false;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_AgregarUsuario", con);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.ID);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@patron", Patron);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception e)
            {
                response = false;
                throw e;
            }
            finally
            {
                con.Close();
            }

            return response;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> Lista = new List<Usuario>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ListarUsuarios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.ID = Convert.ToInt32(dr["idUsuario"].ToString());
                    objUsuario.Email = dr["email"].ToString();
                    objUsuario.Clave = dr["clave"].ToString();
                    objUsuario.Estado = Convert.ToBoolean(dr["nroDocumento"]);                    

                    Lista.Add(objUsuario);
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

        public bool Actualizar(Usuario objUsuario)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_ActualizarDatosUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", objUsuario.ID);
                cmd.Parameters.AddWithValue("@prmEmail", objUsuario.Email);
                cmd.Parameters.AddWithValue("@prmClave", objUsuario.Clave);
                cmd.Parameters.AddWithValue("@prmEstado", objUsuario.Estado);                
                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public bool Eliminar(int idUsuario)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("SP_EliminarUsuario", conexion);
                cmd.Parameters.AddWithValue("@prmIdUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }
    }
}
