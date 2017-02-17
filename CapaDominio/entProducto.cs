using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class entProducto
    {
        public int idProducto { get; set; }
        public String nombre { get; set; }        
        public String marca { get; set; }
        public String descripcion { get; set; }
        public double precio { get; set; }
        public String fechaVencimiento { get; set; }
        public Boolean estado { get; set; }

        public entCategoria categoria { get; set; }

        
    }
}
