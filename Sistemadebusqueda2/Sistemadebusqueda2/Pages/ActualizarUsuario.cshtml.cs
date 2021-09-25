using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistemadebusqueda2.Repositories;

namespace Sistemadebusqueda2.Pages
{
    public class ActualizarUsuarioModel : PageModel
    { 
            [BindProperty]
            public int Id { get; set; }
            [BindProperty]
            [Display(Name = "Nombre de Usuario")]
            [Required(ErrorMessage = "El campo nombre de usuario es requerido")]
            public string NombreUsuario { get; set; }
            [BindProperty]
            [Required(ErrorMessage = "El campo nombres es requerido")]
            public string Nombres { get; set; }
            [BindProperty]
            [Required(ErrorMessage = "El campo apellidos es requerido")]
            public string Apellidos { get; set; }
            [BindProperty]
            [Display(Name = "Rol")]
            [Required(ErrorMessage = "El campo Rol es requerido")]
            public int? RolId { get; set; }
            [BindProperty]
            [Required(ErrorMessage = "El campo Pais es requerido")]
            public string pais { get; set; }
            [BindProperty]
            [Display(Name = "Contrase�a")]
            [Required(ErrorMessage = "El campo contrase�a es requerido")]
            [MinLength(8, ErrorMessage = "La contrase�a debe tener al menos 8 caracteres")]
            [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contrase�a debe tener al menos una mayuscula, minusculas y digitos")]
            public string Password { get; set; }
            [BindProperty]
            [Display(Name = "Repetir Contrase�a")]
            [Required(ErrorMessage = "El campo repetir contrase�a es requerido")]
            [MinLength(8, ErrorMessage = "La contrase�a debe tener al menos 8 caracteres")]
            [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contrase�a debe tener al menos una mayuscula, minusculas y digitos")]
            public string RePassword { get; set; }
            public ActionResult OnGet(int id)
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            var usuarioId = id;

            var repo = new UsuarioRepositorio();
            var usuario = repo.ObtenerUsuarioPorId(usuarioId);
            this.Id = usuario.id;
            this.Nombres = usuario.Nombres;
            this.Apellidos = usuario.Apellidos;
            this.NombreUsuario = usuario.Usuario;
            this.RolId = usuario.RolId;
            this.pais = usuario.Pais;
            this.Password = usuario.Password;
            return Page();
        }
    }
}
