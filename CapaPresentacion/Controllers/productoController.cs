﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class productoController : Controller
    {
        // GET: producto
        public ActionResult agregar()
        {
            return View();
        }
    }
}