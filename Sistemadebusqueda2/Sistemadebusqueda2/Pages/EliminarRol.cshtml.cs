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
    public class EliminarRolModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        [BindProperty]
        public string Nombre { get; set; }
        public ActionResult OnGet(int id)
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            var repo = new RolRepositorio();
            var rol = repo.ObtenerRolPorId(id);
            this.id = rol.Id;
            this.Nombre = rol.Nombre;
            return Page();
        }

        public ActionResult OnPost()
        {
            var repo = new RolRepositorio();
            repo.EliminarRol(this.id);
            return RedirectToPage("./Roles");
        }
    }
}
