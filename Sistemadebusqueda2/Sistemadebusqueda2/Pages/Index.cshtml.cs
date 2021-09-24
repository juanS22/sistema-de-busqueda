using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Sistemadebusqueda2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemadebusqueda2.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage ="El campo usuario es requerido")]
        public string Usuario { get; set; }
        [Display(Name="Contraseña")]
        [BindProperty]
        [Required(ErrorMessage ="El campo contraseña es requerido")]
        public string Password { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var usuario = this.Usuario;
                var pass = this.Password;
                var repo = new IndexRepository();
                bool resultadoValidacion = repo.ValidarUsuario(usuario, pass);

                if (resultadoValidacion == true)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El usuario o la contraseña no son validos");
                    return Page();
                }
                    

            }
            else
            {
                return Page();
            }
            

        }
    }
}
