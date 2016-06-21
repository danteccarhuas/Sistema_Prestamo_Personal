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

        public tb_trabajador BuscarTrabajador(string idTrabajador)
        {
            DA_tb_trabajador dao = new DA_tb_trabajador();
            return dao.BuscarTrabajador(idTrabajador);
        }
        public List<tb_trabajador> ListarTrabajador(tb_trabajador bean)
        {
            DA_tb_trabajador dao = new DA_tb_trabajador();
            return dao.ListarTrabajador(bean);
        }

        public int TotalRegistroTrabajador(tb_trabajador bean)
        {
            DA_tb_trabajador dao = new DA_tb_trabajador();
            return dao.TotalRegistroTrabajador(bean);
        }
    }
}
