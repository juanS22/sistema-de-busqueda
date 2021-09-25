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
    public class NuevoUsuarioModel : PageModel
    {
        [BindProperty]        
        [Display (Name ="Nombre de Usuario")]
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
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo contraseña es requerido")]
        [MinLength(8,ErrorMessage ="La contraseña debe tener al menos 8 caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage ="La contraseña debe tener al menos una mayuscula, minusculas y digitos")]
        public string Password { get; set; }
        [BindProperty]       
        [Display(Name = "Repetir Contraseña")]
        [Required(ErrorMessage = "El campo repetir contraseña es requerido")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contraseña debe tener al menos una mayuscula, minusculas y digitos")]
        public string RePassword { get; set; }
        public ActionResult OnGet()
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }


        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var password = this.Password;
                var repassword = this.RePassword;
                if (password != repassword)
                {
                    ModelState.AddModelError(string.Empty, "Las contraseñas no coinciden");
                    return Page();
                }

                var repo = new UsuarioRepositorio();
                repo.InsertarUsuario(this.Nombres, this.Apellidos, (int)this.RolId, this.pais, this.NombreUsuario, this.Password);

                return RedirectToPage("./Usuarios");
            }

            return Page();
        }

     }
}
