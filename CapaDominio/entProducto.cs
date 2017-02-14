using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class entProducto
    {
        public String nombre { get; set; }
        public int idProducto { get; set; }
        public String marca { get; set; }

        public entCategoria categoria { get; set; }
        public String descripcion { get; set; }
        public double precio { get; set; }
        public DateTime fechaVencimiento { get; set; }
    }
}
