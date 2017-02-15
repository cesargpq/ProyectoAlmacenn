using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using System.Data;
using System.Data.SqlClient;

namespace CapaPersistencia
{
    public class daoProveedor
    {
        #region singleton
        private static readonly daoProveedor _instancia = new daoProveedor();
        public static daoProveedor Instancia
        {
            get { return daoProveedor._instancia; }
        }
        #endregion singleton

        #region Almacen
        public List<entProveedor> ListarProveedor()
        {
            SqlCommand cmd = null;
            List<entProveedor> lista = new List<entProveedor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor p = new entProveedor();
                    p.idProveedor = Convert.ToInt16(dr["idProveedor"]);
                    p.nombre = dr["nombre"].ToString();
                    p.ruc = dr["ruc"].ToString();
                    p.descripcion = dr["descripcion"].ToString();
                    p.telefono = dr["telefono"].ToString();
                    p.email = dr["email"].ToString();
                    p.razonSocial = dr["razonSocial"].ToString();
                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarProveedor(entProveedor p)
        {
            SqlCommand cmd = null;
            Boolean Inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spInsertarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombre", p.nombre);
                cmd.Parameters.AddWithValue("@prmstrRuc", p.ruc);
                cmd.Parameters.AddWithValue("@prmstrDescripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@prmstrTelefono", p.telefono);
                cmd.Parameters.AddWithValue("@prmstrEmail", p.email);
                cmd.Parameters.AddWithValue("@prmstrRazonSocial", p.razonSocial);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { Inserto = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Inserto;
        }

        public entProveedor DevolverProveedor(int idProveedor)
        {
            SqlCommand cmd = null;
            entProveedor p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spDevolverProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintIdProveedor", idProveedor);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    p = new entProveedor();
                    p.idProveedor = Convert.ToInt16(dr["idProveedor"]);
                    p.nombre = dr["nombre"].ToString();
                    p.ruc = dr["ruc"].ToString();
                    p.descripcion = dr["descripcion"].ToString();
                    p.telefono = dr["telefono"].ToString();
                    p.email = dr["email"].ToString();
                    p.razonSocial = dr["razonSocial"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return p;
        }

        public Boolean EditarProveedor(entProveedor p)
        {
            SqlCommand cmd = null;
            Boolean Edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spEditarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintIdProveedor", p.idProveedor);
                cmd.Parameters.AddWithValue("@prmstrNombre", p.nombre);
                cmd.Parameters.AddWithValue("@prmstrRuc", p.ruc);
                cmd.Parameters.AddWithValue("@prmstrDescripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@prmstrTelefono", p.telefono);
                cmd.Parameters.AddWithValue("@prmstrEmail", p.email);
                cmd.Parameters.AddWithValue("@prmstrRazonSocial", p.razonSocial);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { Edito = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Edito;
        }

        public Boolean EliminarProveedor(entProveedor p)
        {
            SqlCommand cmd = null;
            Boolean Edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spEliminarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintIdProveedor", p.idProveedor);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { Edito = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Edito;
        }
        #endregion Almacen
    }
}
