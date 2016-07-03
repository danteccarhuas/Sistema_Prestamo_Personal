using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lib_Entidad;
using Lib_Negocio;

namespace SPP.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult mantener_cliente()
        {
            return View();
        }

        public ActionResult RegistrarCliente(tb_cliente bean)
        {
            BB_tb_cliente dao = new BB_tb_cliente();
            return Json(new { result = dao.UpdateCliente(bean, 1) });
        }

        public ActionResult ModificarCliente(tb_cliente bean)
        {
            BB_tb_cliente dao = new BB_tb_cliente();
            Request.AcceptTypes.Contains("application/json");
            return Json(new { success = true, resultado = dao.UpdateCliente(bean, 2) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarCliente(tb_cliente bean)
        {
            BB_tb_cliente dao = new BB_tb_cliente();
            bean.idCliente = bean.idCliente == null ? "" : bean.idCliente;
            bean.nombres = bean.nombres == null ? "" : bean.dni;
            Request.AcceptTypes.Contains("application/json");
            return Json(new { success = true, resultado = dao.ListarCliente(bean) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TotalRegistrosCliente(tb_cliente bean)
        {
            BB_tb_cliente dao = new BB_tb_cliente();
            bean.idCliente = bean.idCliente == null ? "" : bean.idCliente;
            bean.nombres = bean.nombres == null ? "" : bean.nombres;
            bean.dni = bean.dni == null ? "" : bean.dni;
            Request.AcceptTypes.Contains("application/json");
            return Json(new { success = true, resultado = dao.TotalRegistroCliente(bean) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RecuperarCliente(String idCliente)
        {
            BB_tb_cliente dao = new BB_tb_cliente();
            Request.AcceptTypes.Contains("application/json");
            return Json(new { success = true, resultado = dao.BuscarCliente(idCliente) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DarBajaCliente(tb_cliente bean)
        {
            BB_tb_cliente dao = new BB_tb_cliente();
            Request.AcceptTypes.Contains("application/json");
            return Json(new { success = true, resultado = dao.UpdateCliente(bean, 3) }, JsonRequestBehavior.AllowGet);
        }


    }
}