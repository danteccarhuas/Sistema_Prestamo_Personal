using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lib_Entidad;
using Lib_Negocio;
namespace SPP.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Loguin()
        {
            return View();
        }

        public ActionResult Intranet(tb_usuario bean)
        {
            BB_Seguridad dao = new BB_Seguridad();
            tb_trabajador obj= dao.Loguear(bean);
            Session["menu"] = obj.tb_usuario.tb_menu;
            return Json(new { success = true, resultado = 1 });
        }

        public ActionResult MenuPrincipal(){
            return View();
        }
    }
}