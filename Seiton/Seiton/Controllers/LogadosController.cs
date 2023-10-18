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

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var FkUsuarioId = (from p in _context.Projetos
                               where p.IdUsuario == userId
                               select p.nome_projeto)
                                 .ToList();


            return View(FkUsuarioId);
        }

    }
}
