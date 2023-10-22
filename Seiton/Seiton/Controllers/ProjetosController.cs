using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using Seiton.Models;
using System.Security.Claims;


namespace Seiton.Controllers
{
    public class ProjetosController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly AppDBContext _context;

        public ProjetosController(AppDBContext context)
        {
            _context = context;
        }


        // GET: Projetos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projetos.ToListAsync());
        }

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projetos == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetos/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Projetos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome_projeto,quant_colunas")] Projeto projeto)
        {
            
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                projeto.IdUsuario = userId;
                _context.Add(projeto);
                await _context.SaveChangesAsync();

                var maxID = _context.Projetos.Max(projeto => projeto.Id);


                string[] names = new string[] { "Backlog", "To do", "In progress", "Testing", "Done",};
                string[] color = new string[] { "Backlog", "To do", "In progress", "Testing", "Done", };

                foreach (string item in names)
                {
                    var Coluna = new Colunas
                    {
                        nome_coluna = item,
                        cor_coluna = "Vermelho",
                        quant_tarefas = 0,
                        IdProjeto = maxID
                    };


                    _context.Colunas.Add(Coluna);
                }
                    await _context.SaveChangesAsync();
                return RedirectToAction("Logado", "Logados");

            }
            return View(projeto);
        }

        // GET: Projetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projetos == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome_projeto,quant_colunas")] Projeto projeto)
        {
            if (id != projeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projetos == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projetos == null)
            {
                return Problem("Entity set 'AppDBContext.Projetos'  is null.");
            }
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
          return _context.Projetos.Any(e => e.Id == id);
        }
    }
}
