using Lib_Entidad;
using Lib_Data;
namespace Lib_Negocio
{
    public class BB_Seguridad
    {
        public tb_trabajador Loguear(tb_usuario bean)
        {
            DA_Seguridad dao = new DA_Seguridad();
            return dao.Loguear(bean);
        }
    }
}
