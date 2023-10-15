using Microsoft.AspNetCore.Mvc;
using Seiton.Models;

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
            var idUsuario = 2;

            var idProjectUsuario = (from u in _context.Unioes
                                    where u.IdUsuario == idUsuario
                                    select u.IdProjeto)
                                      .ToList();

            return View(idProjectUsuario);
        }

    }
}
