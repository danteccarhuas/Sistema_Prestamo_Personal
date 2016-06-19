using System;
using System.Collections.Generic;
using Lib_Entidad;
using Lib_Data;

namespace Lib_Negocio
{
    public class BB_tb_cliente
    {
        public string UpdateCliente(tb_cliente bean, int evaluar)
        {
            DA_Cliente dao = new DA_Cliente();
            return dao.UpdateCliente(bean, evaluar);
        }

        public tb_cliente BuscarCliente(string idCliente)
        {
            DA_Cliente dao = new DA_Cliente();
            return dao.BuscarCliente(idCliente);
        }
        public List<tb_cliente> ListarCliente()
        {
            DA_Cliente dao = new DA_Cliente();
            return dao.ListarCliente();
        }
    }
}
