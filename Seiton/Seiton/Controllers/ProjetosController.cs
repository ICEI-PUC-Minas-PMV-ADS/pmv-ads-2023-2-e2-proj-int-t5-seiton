using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using Seiton.Models;
using System;
using System.Security.Claims;
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
            return View(await _context.Projetos.ToListAsync());
        }

        // GET: Projetos/Details
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
                string[] color = new string[] { "#4EAAFF", "#FF4167", "#FFB64F", "#696969", "#37C936" };

                for (int i = 0; i < names.Length; i++)
                {
                    var Coluna = new Colunas
                    {
                        nome_coluna = names[i],
                        cor_coluna = color[i],
                        quant_tarefas = 0,
                        IdProjeto = maxID
                    };

                    _context.Colunas.Add(Coluna);
                }
                    await _context.SaveChangesAsync();
                return RedirectToAction("Logado", "Logados", new { id = maxID });

            }
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

                return RedirectToAction("Logado", "Logados", new { id });
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
            return RedirectToAction("Logado", "Logados");
        }

        private bool ProjetoExists(int id)
        {
          return _context.Projetos.Any(e => e.Id == id);
        }
    }
}
