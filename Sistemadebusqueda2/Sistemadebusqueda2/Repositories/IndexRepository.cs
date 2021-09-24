using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemadebusqueda2.Repositories
{
    public class IndexRepository
    {
        private readonly string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";

        public bool ValidarUsuario(string usuario, string password)
        {
            bool respuesta = false;
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_check_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            sql.Open();
            int resultadoQuery = (int)cmd.ExecuteScalar();
            if (resultadoQuery > 0)
            {
                respuesta = true;
            }

            return respuesta;
        }

    }
}
