using System;
using System.Collections.Generic;
namespace Lib_Entidad
{
    public class tb_menu
    {
        public int idMenu { get; set; }

        public string descripcion_menu { get; set; }
        public string icon_left { get; set; }
        public string icon_right { get; set; }

        public List<tb_submenu> tb_submenu { get; set; }
    }
}
