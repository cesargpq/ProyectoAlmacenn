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
    public class daoAlmacen
    {
        #region singleton
        private static readonly daoAlmacen _instancia = new daoAlmacen();
        public static daoAlmacen Instancia
        {
            get { return daoAlmacen._instancia; }
        }
        #endregion singleton

        #region Almacen
        public List<entAlmacen> ListarAlmacen()
        {
            SqlCommand cmd = null;
            List<entAlmacen> lista = new List<entAlmacen>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarAlmacen", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entAlmacen a = new entAlmacen();
                    a.idAlmacen = Convert.ToInt16(dr["idAlmacen"]);
                    a.nombre = dr["nombre"].ToString();
                    a.descripcion = dr["descripcion"].ToString();
                    a.direccion = dr["direccion"].ToString();
                    a.telefono = dr["telefono"].ToString();
                    lista.Add(a);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarAlmacen(entAlmacen a)
        {
            SqlCommand cmd = null;
            Boolean Inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spInsertarAlmacen", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombre", a.nombre);
                cmd.Parameters.AddWithValue("@prmstrDescripcion", a.descripcion);
                cmd.Parameters.AddWithValue("@prmstrDireccion", a.direccion);
                cmd.Parameters.AddWithValue("@prmstrTelefono", a.telefono);
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
        public entAlmacen DevolverAlmacen(int idAlmacen)
        {
            SqlCommand cmd = null;
            entAlmacen a = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spDevolverAlmacen", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidAlmacen", idAlmacen);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    a = new entAlmacen();
                    a.idAlmacen = Convert.ToInt16(dr["idAlmacen"]);
                    a.nombre = dr["nombre"].ToString();
                    a.descripcion = dr["descripcion"].ToString();
                    a.direccion = dr["direccion"].ToString();
                    a.telefono = dr["telefono"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return a;
        }


        public Boolean EditarAlmacen(entAlmacen a)
        {
            SqlCommand cmd = null;
            Boolean Edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spEditarAlmacen", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidAlmacen", a.idAlmacen);
                cmd.Parameters.AddWithValue("@prmstrNombre", a.nombre);
                cmd.Parameters.AddWithValue("@prmstrDescripcion", a.descripcion);
                cmd.Parameters.AddWithValue("@prmstrDireccion", a.direccion);
                cmd.Parameters.AddWithValue("@prmstrTelefono", a.telefono);
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

        public Boolean EliminarAlmacen(int idAlmacen)
        {
            SqlCommand cmd = null;
            Boolean Edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spEliminarAlmacen", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidAlmacen", idAlmacen);
               /* cmd.Parameters.AddWithValue("@prmstrNombre", a.nombre);
                cmd.Parameters.AddWithValue("@prmstrDescripcion", a.descripcion);
                cmd.Parameters.AddWithValue("@prmstrDireccion", a.direccion);
                cmd.Parameters.AddWithValue("@prmstrTelefono", a.telefono);*/
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
