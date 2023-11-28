using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Seiton.Models;
using SQLitePCL;

namespace Seiton.Controllers
{
    public class TarefasController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly AppDBContext _context;

        public TarefasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Tarefas.Include(t => t.Colunas);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Tarefas/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .Include(t => t.Colunas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["IdColuna"] = new SelectList(_context.Colunas, "Id", "Id");
            return View();
        }

        // POST: Tarefas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome_tarefas,descricao,prioridade,responsavel,IdColuna")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {


                string caminho = HttpContext.Request.Path;
                var iProjeto = int.Parse(caminho.Split('/').LastOrDefault());

                var primeiroId = (from c in _context.Colunas
                                    where c.IdProjeto == iProjeto
                                    orderby c.Id
                                    select c.Id)
                                    .FirstOrDefault();

                tarefas.IdColuna = primeiroId;
                _context.Add(tarefas);

                await _context.SaveChangesAsync();

                return RedirectToAction("Logado", "Logados", new { id = iProjeto });

            }
            ViewData["IdColuna"] = new SelectList(_context.Colunas, "Id", "Id", tarefas.IdColuna);
            return View(tarefas);
        }

        // GET: Tarefas/Edit
        public async Task<IActionResult> Edit(int? id)
        {

            var IdColunaT = (from c in _context.Tarefas
                             where c.Id == id
                             select c.IdColuna)
                             .ToList();

            var Projeto = 0;

            foreach (var idColuna in IdColunaT)
            {
                var IdProjeto = (from c in _context.Colunas
                                 where c.Id == idColuna
                                 select c.IdProjeto)
                              .ToList();
                foreach (var idProjeto in IdProjeto)
                {
                    Projeto = idProjeto;
                }
            }

            var NomeColuna = (from c in _context.Colunas
                              where c.IdProjeto == Projeto
                              select c.nome_coluna)
                              .ToList();


            var IdColuna = (from c in _context.Colunas
                            where c.IdProjeto == Projeto
                            select c.Id)
                              .ToList();

            

            var cont = 0;
            foreach (var (Nc, Idc) in NomeColuna.Zip(IdColuna, (v1, v2) => (v1, v2)))
            {
                cont++;
                switch (cont)
                {
                    case 1:
                        ViewBag.NomeColuna1 = Nc;
                        ViewBag.IdColuna1 = Idc;
                        break;
                    case 2:
                        ViewBag.NomeColuna2 = Nc;
                        ViewBag.IdColuna2 = Idc;
                        break;
                    case 3:
                        ViewBag.NomeColuna3 = Nc;
                        ViewBag.IdColuna3 = Idc;
                        break;
                    case 4:
                        ViewBag.NomeColuna4 = Nc;
                        ViewBag.IdColuna4 = Idc;
                        break;
                    case 5:
                        ViewBag.NomeColuna5 = Nc;
                        ViewBag.IdColuna5 = Idc;
                        break;
                }

            }


            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas == null)
            {
                return NotFound();
            }
            ViewData["IdColuna"] = new SelectList(_context.Colunas, "Id", "Id", tarefas.IdColuna);
            return View(tarefas);
        }

        // POST: Tarefas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome_tarefas,descricao,prioridade,responsavel,IdColuna")] Tarefas tarefas)
        {

            var IdColunaT = (from c in _context.Tarefas
                             where c.Id == id
                             select c.IdColuna)
                             .ToList();

            var Projeto = 0;

            foreach (var idColuna in IdColunaT)
            {
                var IdProjeto = (from c in _context.Colunas
                                 where c.Id == idColuna
                                 select c.IdProjeto)
                              .ToList();
                foreach (var idProjeto in IdProjeto)
                {
                    Projeto = idProjeto;
                }
            }


            if (id != tarefas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefasExists(tarefas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Logado", "Logados", new { id = Projeto });
            }
            ViewData["IdColuna"] = new SelectList(_context.Colunas, "Id", "Id", tarefas.IdColuna);
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .Include(t => t.Colunas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var IdColunaT = (from c in _context.Tarefas
                             where c.Id == id
                             select c.IdColuna)
                             .ToList();

            var Projeto = 0;

            foreach (var idColuna in IdColunaT)
            {
                var IdProjeto = (from c in _context.Colunas
                                 where c.Id == idColuna
                                 select c.IdProjeto)
                              .ToList();
                foreach (var idProjeto in IdProjeto)
                {
                    Projeto = idProjeto;
                }
            }

            if (_context.Tarefas == null)
            {
                return Problem("Entity set 'AppDBContext.Tarefas'  is null.");
            }
            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas != null)
            {
                _context.Tarefas.Remove(tarefas);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToAction("Logado", "Logados", new { id = Projeto });
        }

        private bool TarefasExists(int id)
        {
          return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
