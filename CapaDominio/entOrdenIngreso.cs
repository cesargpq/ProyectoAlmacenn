using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class entOrdenIngreso
    {
        public String idOrdenIngreso { get; set; }
        public entProveedor proveedor { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaRecepcion { get; set; }



    }
}
