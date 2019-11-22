using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        SqlConnection conexion = new SqlConnection();
        public SqlConnection conectar()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            return conexion;
        }
    }
}
