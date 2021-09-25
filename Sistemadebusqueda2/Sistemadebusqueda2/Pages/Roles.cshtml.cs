using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistemadebusqueda2.Modelos;
using Sistemadebusqueda2.Repositories;

namespace Sistemadebusqueda2.Pages
{
    public class RolesModel : PageModel
    {
        public List<RolListaModelo> Roles { get; set; }
        public ActionResult OnGet()
        {
            var idSession = HttpContext.Session.GetString("idSession");
            if (string.IsNullOrEmpty(idSession))
            {
                return RedirectToPage("./Index");
            }

            var repo = new RolRepositorio();
            this.Roles = repo.ObtenerRoles();
            return Page();
            }
        }
    }
