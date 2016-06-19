using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace Lib_Utilitarios
{
   public class Conexion
    {
        public SqlConnection getConexion()
        {
            string cad_conex = @"server=MIKE-PC\SA; database=DBPRESTAMO; uid=sa; pwd=sql";
            SqlConnection con = new SqlConnection(cad_conex);

            return con;
        }
    }
}
