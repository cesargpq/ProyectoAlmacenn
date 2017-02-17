using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaPersistencia;

namespace CapaLogica
{
    public class logProducto
    {
        #region singleton
        private static readonly logProducto _instancia = new logProducto();
        public static logProducto Instancia
        {
            get { return logProducto._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<entProducto> ListarProductos()
        {
            try
            {
                return daoProducto.Instancia.ListarProductos();
            }
            catch (Exception e) { throw e; }
        }

        /*public Boolean InsertarProducto(entProducto p)
        {
            try
            {
                if (p.precio == 0 || p.precio == null)
                {
                    throw new ApplicationException("Debe ingresar el precio del producto");
                }
                return daoProducto.Instancia.InsertarProducto(p);
            }
            catch (Exception e) { throw e; }
        }

        public entArticulo DevolverProducto(int idProducto)
        {
            try
            {
                return daoProducto.Instancia.DevolverProducto(idProducto);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarProducto(entArticulo a)
        {
            try
            {
                return daoProducto.Instancia.EditarProducto(a);
            }
            catch (Exception e) { throw e; }
        }*/

        #endregion metodos
    }
}
