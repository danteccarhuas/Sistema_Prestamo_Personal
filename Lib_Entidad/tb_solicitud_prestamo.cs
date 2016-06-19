using System;
using System.Collections.Generic;

namespace Lib_Entidad
{
    public class tb_solicitud_prestamo
    {
        public int idSolicitud_pres { get; set; }
        public DateTime fecha_registro { get; set; }

        public decimal monto_Total { get; set; }

        public decimal tasa { get; set; }

        public int cantidad_meses { get; set; }

        public tb_trabajador tb_trabajador { get; set; }

        public tb_cliente tb_cliente { get; set; }

        public List<tb_cuotas> list_tb_cuotas { get; set; }

    }
}
