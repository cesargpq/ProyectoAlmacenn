using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using CapaDominio;
namespace CapaLogica
{
    public class logAlmacen
    {
        #region singleton
        private static readonly logAlmacen _instancia = new logAlmacen();
        public static logAlmacen Instancia
        {
            get { return logAlmacen._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<entAlmacen> ListarAlmacen()
        {
            try
            {
                return daoAlmacen.Instancia.ListarAlmacen();
            }
            catch (Exception e) { throw e; }
        }
        public Boolean InsertarAlmacen(entAlmacen a)
        {
            try
            {
                /*if (a.direccion.Equals("") )
                {
                    throw new ApplicationException("Debe ingresar la direccion del almacén");
                }*/
                return daoAlmacen.Instancia.InsertarAlmacen(a);
            }
            catch (Exception e) { throw e; }
        }
        public entAlmacen DevolverAlmacen(int idAlmacen)
        {
            try
            {
                return daoAlmacen.Instancia.DevolverAlmacen(idAlmacen);
            }
            catch (Exception e) { throw e; }
        }
        public Boolean EditarAlmacen(entAlmacen a)
        {
            try
            {
                return daoAlmacen.Instancia.EditarAlmacen(a);
            }
            catch (Exception e) { throw e; }
        }
        public Boolean EliminarAlmacen(int idAlmacen)
        {
            Boolean aa;
            try
            {
                aa = daoAlmacen.Instancia.EliminarAlmacen(idAlmacen);

            }
            catch (Exception e)
            {

                throw e;
            }
            return aa;
        }
        #endregion metodos
    }
}
