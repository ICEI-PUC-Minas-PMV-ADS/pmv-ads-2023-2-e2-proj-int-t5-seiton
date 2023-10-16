using Microsoft.AspNetCore.Mvc;
using Seiton.Models;
using System.Security.Claims;

namespace Seiton.Controllers
{
    public class LogadosController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly AppDBContext _context;

        public LogadosController(AppDBContext context)
        {
            _context = context;
        }


        public ActionResult Logado()
        {
            ViewData["userId"] = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewData["userName"] = User.FindFirstValue(ClaimTypes.Name);
            
            var idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var idProjectUsuario = (from u in _context.Unioes
                                    where u.IdUsuario == idUsuario
                                    select u.IdProjeto)
                                      .ToList();

            return View(idProjectUsuario);
        }

    }
}
