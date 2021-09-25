using Sistemadebusqueda2.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemadebusqueda2.Repositories
{
    public class PaisesRepositorio
    {
        public List<PaisesListaModelo> ObtenerPaises()
        {

            var respuesta = new List<PaisesListaModelo>();
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_mostrar_paises", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoPais = new PaisesListaModelo()
                    {
                        Id = (int)reader["id"],                       
                        Nombre = reader["Nombre"].ToString(),                      
                    };

                    respuesta.Add(nuevoPais);
                }
            }
            return respuesta;
        }

        public void InsertarPais(string nombre)
        {
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_insertar_pais", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));         
            sql.Open();
            cmd.ExecuteNonQuery();

        }

        public PaisesListaModelo ObtenerPaisesPorId(int id)
        {

            var respuesta = new PaisesListaModelo();
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_obtiene_pais_por_id", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var nuevoPais = new PaisesListaModelo()
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["Nombre"].ToString(),


                    };

                    respuesta = nuevoPais;
                }
            }
            return respuesta;
        }

        public void ActualizarPais(int id, string nombre)
        {
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_actualizar_pais", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            sql.Open();
            cmd.ExecuteNonQuery();
            }

        public void EliminarPais(int id)
        {
            string ConnectionString = "server=localhost;database=sb3600db;Integrated Security=true";
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("sp_eliminar_pais", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            sql.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
