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
            //return View();
            return Json(new { result = dao.UpdateCliente(bean, 1) });
        }

        public ActionResult ListarCliente()
        {
            BB_tb_cliente dao = new BB_tb_cliente();
            //return View();
            return Json(new { result = dao.ListarCliente() });
        }
    }
}