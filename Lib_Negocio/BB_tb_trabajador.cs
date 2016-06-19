using System;
using System.Collections.Generic;
using Lib_Entidad;
using Lib_Data;


namespace Lib_Negocio
{
    public class BB_tb_trabajador
    {
        public string UpdateTrabajador(tb_trabajador bean, int evaluar)
        {
            DA_tb_trabajador dao = new DA_tb_trabajador();
            return dao.UpdateTrabajador(bean, evaluar);
        }

        public tb_trabajador BuscarTrabajador(string idUsuario)
        {
            DA_tb_trabajador dao = new DA_tb_trabajador();
            return dao.BuscarTrabajador(idUsuario);
        }
        public List<tb_trabajador> ListarTrabajador()
        {
            DA_tb_trabajador dao = new DA_tb_trabajador();
            return dao.ListarTrabajador();
        }
    }
}
