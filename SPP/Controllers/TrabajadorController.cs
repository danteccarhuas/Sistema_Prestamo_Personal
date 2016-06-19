using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lib_Negocio;
using Lib_Entidad;

namespace SPP.Controllers
{
    public class TrabajadorController : Controller
    {
        // GET: Trabajador
        public ActionResult mantener_trabajador()
        {

            return View();
        }

        public ActionResult RegistrarTrabajador(tb_trabajador bean)
        {
            BB_tb_trabajador dao = new BB_tb_trabajador();
            //return View();
            return Json(new { result = dao.UpdateTrabajador(bean, 1) });
        }

        public ActionResult ListaTrabajador()
        {
            BB_tb_trabajador dao = new BB_tb_trabajador();
            //return View();
            return Json(new { result = dao.ListarTrabajador() });
        }
    }
}