using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDominio;
using CapaLogica;

namespace CapaPresentacion.Controllers
{
    public class MantenedorProductoController : Controller
    {
        // GET: producto
        [HttpGet]
        public ActionResult Listar()
        {
            List<entProducto> lista = logProducto.Instancia.ListarProductos();
            return View(lista);
        }

        /*public ActionResult Nuevo()
        {
            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Eliminar()
        {
            return View();
        }

        public ActionResult Buscar()
        {
            return View();
        }*/
    }
}