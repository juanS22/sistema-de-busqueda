using Sistemadebusqueda2.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemadebusqueda2.Repositories
{
    public class RolRepositorio
    {
        public List<RolListaModelo> ObtenerRoles()
        {

            var respuesta = new List<RolListaModelo>();
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_mostrar_roles", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoRol = new RolListaModelo()
                    {
                        Id = (int)reader["id"],                        
                        Nombre = reader["Nombre"].ToString(),
                       
                      
                    };

                    respuesta.Add(nuevoRol);
                }
            }
            return respuesta;
        }

        public void InsertarRol(string nombre)
        {
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_insertar_rol", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            sql.Open();
            cmd.ExecuteNonQuery();

        }

        public RolListaModelo ObtenerRolPorId(int id)
        {

            var respuesta = new RolListaModelo();
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_obtiene_rol_por_id", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoRol = new RolListaModelo()
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["Nombre"].ToString(),


                    };

                    respuesta = nuevoRol;
                }
            }
            return respuesta;
        }

        public void ActualizarRol(int id, string nombre)
        {
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_actualizar_rol", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            sql.Open();
            cmd.ExecuteNonQuery();

        }

        public void EliminarRol(int id)
        {
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_eliminar_rol", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            cmd.ExecuteNonQuery();

        }
    }
}
