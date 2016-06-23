using System;
using System.Collections.Generic;
namespace Lib_Entidad
{
    public class tb_usuario
    {
        public int idUsuario { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public tb_rol tb_rol { get; set; }
        public List<tb_menu> tb_menu { get; set; }
    }
}
