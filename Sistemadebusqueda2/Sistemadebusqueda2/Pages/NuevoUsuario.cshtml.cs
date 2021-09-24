using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        [Display(Name = "Contraseņa")]
        [Required(ErrorMessage = "El campo contraseņa es requerido")]
        [MinLength(8,ErrorMessage ="La contraseņa debe tener al menos 8 caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage ="La contraseņa debe tener al menos una mayuscula, minusculas y digitos")]
        public string Password { get; set; }
        [BindProperty]       
        [Display(Name = "Repetir Contraseņa")]
        [Required(ErrorMessage = "El campo repetir contraseņa es requerido")]
        [MinLength(8, ErrorMessage = "La contraseņa debe tener al menos 8 caracteres")]
        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contraseņa debe tener al menos una mayuscula, minusculas y digitos")]
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
                return Page();
            }

            return Page();
        }

     }
}
