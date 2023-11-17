using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seiton.Models;

namespace Seiton.Controllers
{
    public class ColunasController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly AppDBContext _context;

        public ColunasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Colunas
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Colunas.Include(c => c.Projeto);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Colunas/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colunas == null)
            {
                return NotFound();
            }

            var colunas = await _context.Colunas.FindAsync(id);
            if (colunas == null)
            {
                return NotFound();
            }

            ViewData["IdProjeto"] = new SelectList(_context.Projetos, "Id", "nome_projeto", colunas.IdProjeto);
            return View(colunas);
        }

        // POST: Colunas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome_coluna,cor_coluna,quant_tarefas,IdProjeto")] Colunas colunas)
        {
            if (id != colunas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colunas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColunasExists(colunas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Logado", "Logados", new { id = colunas.IdProjeto });
            }
            ViewData["IdProjeto"] = new SelectList(_context.Projetos, "Id", "nome_projeto", colunas.IdProjeto);
            return View(colunas);
        }

        private bool ColunasExists(int id)
        {
          return _context.Colunas.Any(e => e.Id == id);
        }
    }
}
