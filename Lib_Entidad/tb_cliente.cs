using System;

namespace Lib_Entidad
{
    public class tb_cliente
    {
        public string idCliente { get; set; }
        public string nombres { get; set; }
        public string ape_paterno { get; set; }
        public string ape_materno { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int estado { get; set; }
    }
}
