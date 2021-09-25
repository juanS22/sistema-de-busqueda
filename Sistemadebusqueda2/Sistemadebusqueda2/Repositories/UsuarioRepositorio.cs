using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemadebusqueda2.Repositories
{
    public class UsuarioRepositorio
    {
        public void InsertarUsuario(string nombres, string apellidos, int rolid, string pais, string usuario, string password)
        {
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_insertar_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombres", nombres));
            cmd.Parameters.Add(new SqlParameter("@apellidos", apellidos));
            cmd.Parameters.Add(new SqlParameter("@rolid", rolid));
            cmd.Parameters.Add(new SqlParameter("@pais", pais));
            cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            sql.Open();
            cmd.ExecuteNonQuery();

        }

  
    }
}
