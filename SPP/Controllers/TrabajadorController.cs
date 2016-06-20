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
            return Json(new { result = dao.UpdateTrabajador(bean, 1) });
        }

        
        public ActionResult ListaTrabajador(tb_trabajador bean)
        {
            BB_tb_trabajador dao = new BB_tb_trabajador();
            bean.idTrabajador = bean.idTrabajador == null ? "" : bean.idTrabajador;
            bean.nombres = bean.nombres == null ? "" : bean.nombres;
            bean.dni = bean.dni == null ? "" : bean.dni;
            return Json(new { result = dao.ListarTrabajador(bean) });
        }

       /* public JsonResult TotalRegistrosTrabajador(tb_trabajador bean)
        {
            BB_tb_trabajador dao = new BB_tb_trabajador();
            bean.idTrabajador = bean.idTrabajador == null ? "" : bean.idTrabajador;
            bean.nombres = bean.nombres == null ? "" : bean.nombres;
            bean.dni = bean.dni == null ? "" : bean.dni;
            return Json(new { result = dao.TotalRegistroTrabajador(bean),JsonRequestBehavior.AllowGet});
        }*/
    }
}