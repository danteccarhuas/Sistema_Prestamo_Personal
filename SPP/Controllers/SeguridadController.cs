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
            tb_trabajador obj = dao.Loguear(bean);
            if(obj==null){
                String error= "error";
                //ViewBag.loguear = Session["loguear"] as String;
                Session["loguear"] = error.ToString();
                return RedirectToAction("Loguin");
            }

            Session["Menu"] = obj.tb_usuario.tb_menu;
            Session["Trabajador"] = obj;
            ViewBag.Menu = Session["Menu"] as List<tb_menu>;
            ViewBag.Menu = Session["Trabajador"] as tb_trabajador;
            return View();

            //ViewBag.DatosUsuario = Session["DatosUsuario"] as tb_trabajador;
                //Session["Datos_Menu"] = obj;
            //return Json(new { success = true, resultado = 1 });
        }

        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Loguin");
        }

    }
}