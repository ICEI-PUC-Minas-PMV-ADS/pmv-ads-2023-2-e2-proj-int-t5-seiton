using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
        public ActionResult Logado(int id)
        {
            ViewData["userId"] = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewData["userName"] = User.FindFirstValue(ClaimTypes.Name);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Filtrando o nome do projeto pelo id do usuario
            var Nome_projeto = (from p in _context.Projetos
                               where p.IdUsuario == userId
                               select p.nome_projeto)
                                 .ToList();

            var ProjetoId = (from p in _context.Projetos
                                where p.IdUsuario == userId
                                select p.Id)
                                 .ToList();

            var NomeColuna = (from c in _context.Colunas
                              where c.IdProjeto == id
                              select c.nome_coluna)
                     .ToList();


            var viewModel = new ViewModel
            {
                Nome_projeto = Nome_projeto,
                ProjetoId = ProjetoId,
                NomeColuna = NomeColuna
            };


            return View(viewModel);
        }
    }

}
