using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDominio;
using CapaLogica;
namespace CapaPresentacion.Controllers
{
    public class mantenedorAlmacenController : Controller
    {
        // GET: mantenedorAlmacen
        public ActionResult Listar()
        {
            try
            {
                List<entAlmacen> lista = logAlmacen.Instancia.ListarAlmacen();
                return View(lista);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message });
            }
        }
        public ActionResult Listar2()
        {
            try
            {
                List<entAlmacen> lista = logAlmacen.Instancia.ListarAlmacen();
                return View(lista);

            }
            catch (Exception e)
            {

               return RedirectToAction("Index","Error",new{menesajerror=e.Message});
            }
        }
        public ActionResult Listar3()
        {
            try
            {
                List<entAlmacen> lista = logAlmacen.Instancia.ListarAlmacen();
                return View(lista);

            }
            catch (Exception e)
            {

                return RedirectToAction("Index", "Error", new { menesajerror = e.Message });
            }
        }
        [HttpGet]
        public ActionResult Nuevo() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(entAlmacen a)
        {
            try
            {
               
                Boolean inserto = logAlmacen.Instancia.InsertarAlmacen(a);
                if (inserto)
                {
                 
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View(a);
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
        public ActionResult Editar(int idAlmacen) {
            try
            {


                entAlmacen a = logAlmacen.Instancia.DevolverAlmacen(idAlmacen);
                return View(a);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Editar(entAlmacen a)
        {
            try
            {
                Boolean edito = logAlmacen.Instancia.EditarAlmacen(a);
                if (edito)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View(a);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensajerror = ex.Message });
            }
        }

        public ActionResult Eliminar(int idAlmacen)
        {
            Boolean a = logAlmacen.Instancia.EliminarAlmacen(idAlmacen);
            if (a)
            {
                return RedirectToAction("Listar", "mantenedorAlmacen", null);
            }
            return View();
        }
       

    }
}