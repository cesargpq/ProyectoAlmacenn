using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using CapaDominio;

namespace CapaLogica
{
    public class logProveedor
    {
        #region singleton
        private static readonly logProveedor _instancia = new logProveedor();
        public static logProveedor Instancia
        {
            get { return logProveedor._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entProveedor> ListarProveedor()
        {
            try
            {
                return daoProveedor.Instancia.ListarProveedor();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarProveedor(entProveedor p)
        {
            try
            {
                return daoProveedor.Instancia.InsertarProveedor(p);
            }
            catch (Exception e) { throw e; }
        }

        public entProveedor DevolverProveedor(int idProveedor)
        {
            try
            {
                return daoProveedor.Instancia.DevolverProveedor(idProveedor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditarProveedor(entProveedor p)
        {
            try
            {
                return daoProveedor.Instancia.EditarProveedor(p);
            }
            catch (Exception e) { throw e; }
        }
        public Boolean EliminarProveedor(entProveedor p)
        {
            Boolean cambio;
            try
            {
                cambio = daoProveedor.Instancia.EliminarProveedor(p);

            }
            catch (Exception e)
            {

                throw e;
            }
            return cambio;
        }
        
        #endregion metodos
    }
}
