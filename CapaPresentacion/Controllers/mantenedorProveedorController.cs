using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDominio;
using CapaLogica;
using System.IO;

namespace CapaPresentacion.Controllers
{
    public class MantenedorProveedorController : Controller
    {
        // GET: mantenedorProveedor
        public ActionResult Listar()
        {
            try
            {
                List<entProveedor> lista = logProveedor.Instancia.ListarProveedor();
                return View(lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(entProveedor p)
        {
            try
            {
                Boolean inserto = logProveedor.Instancia.InsertarProveedor(p);
                if (inserto)
                {

                    return RedirectToAction("Listar");
                }
                else
                {
                    return View(p);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("Nuevo", new { msjException = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("errores", "Error", new { mensajerror = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Editar(int idProveedor)
        {
            try
            {
                entProveedor p = logProveedor.Instancia.DevolverProveedor(idProveedor);
                return View(p);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Editar(entProveedor p)
        {
            try
            {
                Boolean edito = logProveedor.Instancia.EditarProveedor(p);
                if (edito)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View(p);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int idProveedor)
        {
            try
            {
                entProveedor p = logProveedor.Instancia.DevolverProveedor(idProveedor);
                return View(p);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(entProveedor p)
        {
            try
            {
                Boolean elimino = logProveedor.Instancia.EliminarProveedor(p);
                if (elimino)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View(p);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerro = ex.Message });
            }
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