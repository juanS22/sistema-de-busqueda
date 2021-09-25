using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistemadebusqueda2.Repositories;

namespace Sistemadebusqueda2.Pages
{
    public class EliminarPaisModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Nombre { get; set; }
        public ActionResult OnGet(int id)
        {
            
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            var repo = new PaisesRepositorio();
            var pais = repo.ObtenerPaisesPorId(id);
            this.Id = pais.Id;
            this.Nombre = pais.Nombre;
            return Page();
        }

        public ActionResult OnPost()
        {

            var repo = new PaisesRepositorio();
            repo.EliminarPais(this.Id);
            return RedirectToPage("./Paises");
        }
    }
}
