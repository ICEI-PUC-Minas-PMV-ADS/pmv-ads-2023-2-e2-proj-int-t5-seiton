using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using Seiton.Models;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SQLitePCL;

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
                _context.Add(projeto);
                await _context.SaveChangesAsync();

                // coletando id do usuário logado
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // coletando id do ultimo projeto criado na tabela de projetos
                var projectId = 
                    (from p in _context.Projetos
                        orderby p.Id descending
                        select p.Id)
                        .Take(1)
                        .ToList();
                // iterando sobre os elementos na tabela projetos
                foreach(var cont_project in projectId)
                {
                    // adicionando os dados na tabela unioes
                    var projects = new Uniao()
                    {
                        IdUsuario = userId,
                        IdProjeto = cont_project,
                    };

                    _context.Add(projects);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
