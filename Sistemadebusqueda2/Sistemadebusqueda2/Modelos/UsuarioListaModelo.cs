using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemadebusqueda2.Modelos
{
    public class UsuarioListaModelo
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int RolId { get; set; }
        public string Pais { get; set; }
    }
}
