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
    public class daoProducto
    {
        #region singleton
        private static readonly daoProducto _instancia = new daoProducto();
        public static daoProducto Instancia
        {
            get { return daoProducto._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<entProducto> ListarProductos()
        {
            SqlCommand cmd = null;
            List<entProducto> lista = new List<entProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListaProductos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProducto p = new entProducto();
                    p.idProducto = Convert.ToInt16(dr["idProducto"]);
                    p.nombre = dr["nombre"].ToString();
                    p.marca = dr["marca"].ToString();
                    p.descripcion = dr["descripcion"].ToString();
                    p.precio = Convert.ToDouble(dr["precio"]);
                    p.fechaVencimiento = Convert.ToDateTime(dr["fechaVencimiento"]).ToString("dd/MM/yyyy");
                    p.estado = Convert.ToBoolean(dr["estado"]);

                    entCategoria c = new entCategoria();
                    c.idCategoria = Convert.ToInt16(dr["idCategoria"]);
                    c.descripcion = dr["descripcionCA"].ToString();
                    c.nombre = dr["nombreCA"].ToString();
                    c.estado = Convert.ToBoolean(dr["estadoCA"]);
                    p.categoria = c;
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

        /*public Boolean InsertarProducto(entProducto p)
        {
            SqlCommand cmd = null;
            Boolean Inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spInsertarArticulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombre", p.nombre);
                cmd.Parameters.AddWithValue("@prmstrMarca", p.marca);
                cmd.Parameters.AddWithValue("@prmstrDescripcion", p.descripcion);
                cmd.Parameters.AddWithValue("@prmdblPrecio", p.precio);
                cmd.Parameters.AddWithValue("@prmdateFechaVencimiento", p.fechaVencimiento);
                cmd.Parameters.AddWithValue("@prmintIdCategoria", p.categoria.idCategoria);
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

        public entProducto DevolverProducto(int idProducto)
        {
            SqlCommand cmd = null;
            entArticulo a = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spDevolverArticulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidArticulo", idProducto);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    a = new entArticulo();
                    a.idArticulo = Convert.ToInt16(dr["idArticulo"]);
                    a.Nombre = dr["Nombre"].ToString();
                    a.Detalle = dr["Detalle"].ToString();
                    a.Imagen = dr["Imagen"].ToString();
                    a.DImagen = dr["DImagen"].ToString();
                    a.Activo = Convert.ToBoolean(dr["Activo"]);
                    a.Stock = Convert.ToInt16(dr["Stock"]);
                    a.Precio = Convert.ToDouble(dr["Precio"]);
                    entTipoArticulo ti = new entTipoArticulo();
                    ti.idTipoArticulo = Convert.ToInt16(dr["idTipoArticulo"]);
                    ti.Descripcion = dr["DTipoArticulo"].ToString();
                    a.TipoArticulo = ti;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return a;
        }

        public Boolean EditarProducto(entArticulo a)
        {
            SqlCommand cmd = null;
            Boolean Edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spEditarArticulo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintIdArticulo", a.idArticulo);
                cmd.Parameters.AddWithValue("@prmstrNombre", a.Nombre);
                cmd.Parameters.AddWithValue("@prmstrDetalle", a.Detalle);
                cmd.Parameters.AddWithValue("@prmstrImagen", a.Imagen);
                cmd.Parameters.AddWithValue("@prmstrDImagen", a.DImagen);
                cmd.Parameters.AddWithValue("@prmdblPrecio", a.Precio);
                cmd.Parameters.AddWithValue("@prmdblStock", a.Stock);
                cmd.Parameters.AddWithValue("@prmbolActivo", a.Activo ? 1 : 0);
                cmd.Parameters.AddWithValue("@prmintTipoArticulo", a.TipoArticulo.idTipoArticulo);
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
        }*/

        #endregion metodos


    }
}
