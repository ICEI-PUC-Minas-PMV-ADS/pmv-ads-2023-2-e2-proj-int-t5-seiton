using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seiton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var appDBContext = _context.Projetos.Include(p => p.Usuario);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Projetos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projetos == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos
                .Include(p => p.Usuario)
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario");
            return View();
        }

        // POST: Projetos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome_projeto,quant_colunas,IdUsuario")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", projeto.IdUsuario);
            return View(projeto);
        }

        // GET: Projetos/Edit
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", projeto.IdUsuario);
            return View(projeto);
        }

        // POST: Projetos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome_projeto,quant_colunas,IdUsuario")] Projeto projeto)
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", projeto.IdUsuario);
            return View(projeto);
        }

        // GET: Projetos/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projetos == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetos/Delete
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
