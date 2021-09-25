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
    public class ActualizarPaisModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }
        public ActionResult OnGet(int id)
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            var repo = new PaisesRepositorio();
            var Pais = repo.ObtenerPaisesPorId(id);
            this.Id = Pais.Id;
            this.Nombre = Pais.Nombre;

            return Page();
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var repo = new PaisesRepositorio();
                repo.ActualizarPais(this.Id, this.Nombre);
                return RedirectToPage("./Paises");
            }

            return Page();
        }
    }
}
