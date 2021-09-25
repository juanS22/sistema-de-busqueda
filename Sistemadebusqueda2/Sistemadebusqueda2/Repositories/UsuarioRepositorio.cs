using Sistemadebusqueda2.Modelos;
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

        private readonly string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
        public bool ExisteNombreUsuario(string usuario)
        {
            bool respuesta = false;
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_check_nombre_usuario", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
            sql.Open();
            int resultadoQuery = (int)cmd.ExecuteScalar();
            if (resultadoQuery > 0)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public List<UsuarioListaModelo> ObtenerUsuarios()
        {

            var respuesta = new List<UsuarioListaModelo>();
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_mostrar_usuarios", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoUsuario = new UsuarioListaModelo()
                    {
                        id = (int)reader["id"],
                        Usuario = reader["Usuario"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        RolId = (int)reader["rolId"],
                        Pais = reader["Pais"].ToString()
                    };

                    respuesta.Add(nuevoUsuario);
                }
            }
                return respuesta;
        }

        public UsuarioActualizarModel ObtenerUsuarioPorId(int id)
        {

            var respuesta = new UsuarioActualizarModel();
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_obtener_usuario_por_id", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoUsuario = new UsuarioActualizarModel()
                    {
                        id = (int)reader["id"],
                        Usuario = reader["Usuario"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        RolId = (int)reader["rolId"],
                        Pais = reader["Pais"].ToString(),
                        Password = reader["password"].ToString()
                    };

                    respuesta = nuevoUsuario;
                }
            }
            return respuesta;
            }

            public void ActualizarUsuario(int id,string nombres, string apellidos, int rolid, string pais)
            {
                string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
                using SqlConnection sql = new SqlConnection(ConnectionString);
                using SqlCommand cmd = new SqlCommand("sp_actualiza_usuario", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@nombres", nombres));
                cmd.Parameters.Add(new SqlParameter("@apellidos", apellidos));
                cmd.Parameters.Add(new SqlParameter("@rolid", rolid));
                cmd.Parameters.Add(new SqlParameter("@pais", pais));
                sql.Open();
                cmd.ExecuteNonQuery();
            }


    }
}


