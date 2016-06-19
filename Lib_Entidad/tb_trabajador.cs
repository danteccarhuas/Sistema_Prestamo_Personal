﻿using System;

namespace Lib_Entidad
{
    public class tb_trabajador
    {
        public string idTrabajador { get; set; }

        public string nombres { get; set; }

        public string ape_paterno { get; set; }

        public string ape_materno { get; set; }

        public string dni { get; set; }

        public string direccion { get; set; }

        public string correo { get; set; }

        public string telefono { get; set; }

        public DateTime fecha_nacimiento { get; set; }

        public int idUsuario { get; set; }

        public tb_usuario tb_usuario { get; set; }
        public int estado { get; set; }
    }
}