using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class MantenedorProveedorController : Controller
    {
        // GET: mantenedorProveedor
        public ActionResult IndexMantProv()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Listar(FormCollection frm)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(FormCollection frm)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(FormCollection frm)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Eliminar(FormCollection frm)
        {
            return View();
        }

        [HttpGet]
        public ActionResult InfoProv()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(FormCollection frm)
        {
            return View();
        }
    }
}